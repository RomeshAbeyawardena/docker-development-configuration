namespace HSINet.Identity.Domain.Clients;

public class Client
{
    public Guid Id { get; set; }
    public string? Secret { get; set; }
    public ICollection<ClientPermission> ClientPermissions { get; set; } = [];
    public ICollection<ClientAccessToken> ClientAccessTokens { get; set; } = [];
    
    public string HashClientSecret(string secret)
    {
        return string.Empty;
    }

    public bool HasPermission(string permission)
    {
        return false;
    }
}
