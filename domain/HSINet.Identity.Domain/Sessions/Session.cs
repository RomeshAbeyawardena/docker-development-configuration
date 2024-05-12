using HSINet.Shared.EntityAttributes;

namespace HSINet.Identity.Domain.Sessions;

public class Session : IIdentity
{
    public Guid? Id { get; set; }
    public Guid AuthorisationId { get; set; }
    public Guid ClientId { get; set; }
    public Guid? CSRFTokenId { get; set; }
    public string? Scopes { get; set; }
    public Guid ValidFrom { get; set; }
    public Guid ValidTo { get; set; }

    public AuthorisationCodes.Authorisation? Authorisation { get; set; }
    public Clients.Client? Client { get; set; }
    public CSRF.CSRFToken? CSRFToken { get; set; }
}
