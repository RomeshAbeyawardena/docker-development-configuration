using HSINet.Identity.Domain.CSRF;
using HSINet.Shared;
using HSINet.Shared.Transactional;
using MediatR;

namespace HSINet.Identity.Api.CSRF.Post;

public class Command : IRequest<CSRFToken>, IDbCommand<CSRFToken>
{
    public required CSRFToken Entity { get; init; }
    public UpsertOptions? Options { get; init; }
    public bool CommitChanges { get; init; }
}
