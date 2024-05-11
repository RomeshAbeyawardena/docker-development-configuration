using HSINet.Shared.Transactional;
using MediatR;

namespace HSINet.Identity.Api.Tokens.Post;

public class Handler(IMediator mediator, TimeProvider timeProvider) 
    : IRequestHandler<Request, Response>
{
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var client = await mediator.Send(
            new Clients.Query { 
                Reference = request.ClientId 
            }, cancellationToken) ?? throw new NullReferenceException("Client not found");

        if(!string.IsNullOrWhiteSpace(client.Secret) && client.Secret != request.ClientSecret)
        {
            throw new UnauthorizedAccessException("Client secret is invalid");
        }

        var utcNow = timeProvider.GetUtcNow();
        var accessToken = new Domain.AccessTokens.AccessToken {
            Expires = utcNow.AddSeconds(3600),
            Type = "Client",
            Key = "",
            RefreshToken = ""
        };

        client.ClientAccessTokens.Add(new Domain.Clients.ClientAccessToken
        {
            AccessToken = accessToken
        });

        utcNow = timeProvider.GetUtcNow();

        return new Response
        {
            AccessToken = accessToken.Key,
            Expires = accessToken.Expires.Subtract(utcNow).Seconds,
            TokenType = accessToken.Type,
            RefreshToken = accessToken.RefreshToken
        };
    }
}
