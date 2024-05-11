namespace HSINet.Identity.Domain.Clients;

public class Client
{
    public ICollection<ClientAccessToken> ClientAccessTokens { get; set; } = [];
    public string? Secret { get; set; }

    public bool HasPermission(string permission)
    {
        return false;
    }
}
