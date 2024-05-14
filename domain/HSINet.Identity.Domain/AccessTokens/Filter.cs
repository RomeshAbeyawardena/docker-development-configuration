using HSINet.Shared.Transactional;

namespace HSINet.Identity.Domain.AccessTokens;

public record Filter : IDbQuery<AccessToken>
{
    public Guid? AccessTokenId { get; init; }
    public string? Name { get; init; }
    public string? RefreshToken { get; init; }
    public string? Type { get; init; }
    public DateTimeOffset? ValidFrom { get; init; }
    public DateTimeOffset? ValidTo { get; init; }
    public bool AsNoTracking { get; init; }
}
