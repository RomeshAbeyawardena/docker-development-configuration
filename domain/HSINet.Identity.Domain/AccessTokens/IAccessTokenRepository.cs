using HSINet.Shared.Transactional;

namespace HSINet.Identity.Domain.AccessTokens;

public interface IAccessTokenRepository : IRepository<AccessToken>
{
    IEnumerable<AccessToken> GetAccessTokens(Filter filter, CancellationToken cancellationToken);
}
