using MediatR;

namespace HSINet.Identity.Api.AccessTokens.Post;

public class Command : IRequest<Domain.AccessTokens.AccessToken>
{
    public string? AuthorisationCode { get; init; }
    public string? ClientReference {get; init; }
    public string? ClientSecret { get; init; }
}
