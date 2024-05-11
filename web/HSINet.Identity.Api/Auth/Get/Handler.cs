using HSINet.Identity.Api.Auth.Put;
using HSINet.Identity.Api.CSRF.Get;
using HSINet.Identity.Domain.AuthorisationCodes;
using HSINet.Shared.Transactional;
using MediatR;
using MessagePack;

namespace HSINet.Identity.Api.Auth.Get;

public class Handler(IMediator mediator, TimeProvider timeProvider, IUnitOfWorkProvider unitOfWorkProvider, IHttpContextAccessor httpContextAccessor) 
    : IRequestHandler<AuthorisationRequest, AuthorisationResponse>
{
    private readonly IUnitOfWork unitOfWork = unitOfWorkProvider.GetUnitOfWork("Identity.Api") 
        ?? throw new NullReferenceException("Identity API backend not configured");
    public async Task<AuthorisationResponse> Handle(AuthorisationRequest request, CancellationToken cancellationToken)
    {
        var token = await mediator.Send(new Query { Token = request.CsrfToken }, cancellationToken);
        var utcNow = timeProvider.GetUtcNow();

        if (token == null || token.ValidFromUtc > utcNow || token.ValidToUtc < utcNow)
        {
            throw new InvalidOperationException("CSRF token is invalid or expired.");
        }

        token.ValidToUtc = utcNow.AddHours(-24); // Expire the token

        var client = await mediator.Send(new Clients.Query { 
            Reference = request.ClientId }, cancellationToken);

        if (client == null)
        {
            throw new InvalidOperationException("Client not found.");
        }

        if (!client.HasPermission("EXTERNAL_AUTH"))
        {
            throw new UnauthorizedAccessException("Client does not have permission to perform this operation.");
        }

        if (!request.Scopes.All(client.HasPermission))
        {
            throw new UnauthorizedAccessException("One or more requested scopes are unauthorized.");
        }

        if (!Enum.TryParse<ResponseType>(request.ResponseType, out var responseType))
        {
            throw new InvalidCastException("Response type is not valid");
        }

        var auth = new Authorisation
        {
            Code = Guid.NewGuid().ToString("X"),
            Expires = utcNow.AddSeconds(3600),
            ValidFrom = utcNow,
        };

        foreach(var permission in client.ClientPermissions
            .Where(cp => request.Scopes.Contains(cp.Permission?.Name))
            .Select(cp => cp.Permission))
        {
            auth.Permissions.Add(new AuthorisationPermission
            {
                PermissionId = permission.Id
            });
        }
        auth = await mediator.Send(new Command { 
            Entity = auth
        }, cancellationToken);

        var context = httpContextAccessor.HttpContext;
        if(responseType == ResponseType.Cookie)
        {
            if(context == null)
            {
                throw new NullReferenceException("This was not initiated as a web request");
            }

            utcNow = timeProvider.GetUtcNow();

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = utcNow.AddMinutes(30) // Set an appropriate expiry
            };


            context.Response.Cookies.Append("authentication-token", auth.Code!, cookieOptions);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AuthorisationResponse
        {
            Code = responseType == ResponseType.Code ? auth.Code : string.Empty,
            State = Convert.ToBase64String(MessagePackSerializer.Serialize(auth, cancellationToken: cancellationToken)),
            StateFormat = "MessagePack"
        };
    }

}
