namespace HSINet.Identity.Domain.AccessTokens;

public class AccessToken
{
    public string? RefreshToken { get; set; }
    public string? Type { get; set; }
    public DateTimeOffset Expires { get; set; }
    public string? Key { get; set; }
}
