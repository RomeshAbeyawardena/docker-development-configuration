using HSINet.Shared.EntityAttributes;

namespace HSINet.Identity.Domain.AccessTokens;

public class AccessToken : IIdentity
{
    public Guid? Id { get; set; }
    public required string Key { get; set; }
    public string? RefreshToken { get; set; }
    public string? Type { get; set; }
    public DateTimeOffset Expires { get; set; }
}
