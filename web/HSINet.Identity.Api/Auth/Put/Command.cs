using HSINet.Identity.Domain.AuthorisationCodes;
using HSINet.Shared;
using HSINet.Shared.Transactional;
using MediatR;

namespace HSINet.Identity.Api.Auth.Put;

public record Command : IRequest<Authorisation>, IDbCommand<Authorisation>
{
    public required Authorisation Entity { get; init; };
    public UpsertOptions? Options { get; }
    public bool CommitChanges { get; }
}
