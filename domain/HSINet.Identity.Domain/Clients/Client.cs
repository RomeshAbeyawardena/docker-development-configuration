namespace HSINet.Identity.Domain.Clients;

public class Client
{
    public ICollection<ClientAccessToken> ClientAccessTokens { get; set; } = [];
    public string? Secret { get; set; }

    public string HashClientSecret(string secret)
    {
        return string.Empty;
    }

    public bool HasPermission(string permission)
    {
        return false;
    }
}
