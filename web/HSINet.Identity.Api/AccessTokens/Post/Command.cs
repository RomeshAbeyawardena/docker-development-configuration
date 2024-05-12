using HSINet.Shared;
using HSINet.Shared.Transactional;
using MediatR;

namespace HSINet.Identity.Api.AccessTokens.Post;

public class Command : IDbCommand<Domain.AccessTokens.AccessToken>, 
    IRequest<Domain.AccessTokens.AccessToken>
{
    public string? AuthorisationCode { get; init; }
    public string? ClientReference {get; init; }
    public string? ClientSecret { get; init; }
    public required Domain.AccessTokens.AccessToken Entity { get; set; }
    public UpsertOptions? Options { get; init; }
    public bool CommitChanges { get; init; }
}
