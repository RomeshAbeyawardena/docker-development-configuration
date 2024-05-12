using HSINet.Shared.EntityAttributes;

namespace HSINet.Identity.Domain.Clients;

public class ClientAccessToken : IIdentity
{
    public Guid? Id { get; set; }
    public Guid ClientId { get; set; }
    public Guid AccessTokenId { get; set; }
    public virtual Client? Client { get; set; }
    public virtual AccessTokens.AccessToken? AccessToken { get; set; }
}
