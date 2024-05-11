namespace HSINet.Identity.Domain.Clients;

public class ClientAccessToken
{
    public Guid ClientId { get; set; }
    public Guid AccessTokenId { get; set; }
    public virtual Client? Client { get; set; }
    public virtual AccessTokens.AccessToken? AccessToken { get; set; }
}
