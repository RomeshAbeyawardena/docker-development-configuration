using HSINet.Identity.Api.CSRF.Get;
using HSINet.Shared.Transactional;
using MediatR;

namespace HSINet.Identity.Api.Auth.Get;

public class Handler(IMediator mediator, TimeProvider timeProvider, IUnitOfWorkProvider unitOfWorkProvider) 
    : IRequestHandler<AuthorisationRequest, AuthorisationResponse>
{
    private readonly IUnitOfWork unitOfWork = unitOfWorkProvider.GetUnitOfWork("Identity.Api") ?? throw new NullReferenceException("Identity API backend not configured");
    public async Task<AuthorisationResponse> Handle(AuthorisationRequest request, CancellationToken cancellationToken)
    {
        var token = await mediator.Send(new Query { Token = request.CsrfToken }, cancellationToken);

        var utcNow = timeProvider.GetUtcNow();

        if (token != null 
                && token.ValidFromUtc >= utcNow 
                && token.ValidToUtc >= utcNow)
        {
            //expire the token
            token.ValidToUtc = utcNow.AddHours(-24);
        }
        else throw new InvalidOperationException("CSRF token is invalid");

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new AuthorisationResponse();
    }
}
