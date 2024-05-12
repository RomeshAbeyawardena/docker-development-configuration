using HSINet.Shared.EntityAttributes;

namespace HSINet.Identity.Domain.AuthorisationCodes;

public class Authorisation : IIdentity
{
    public Guid? Id { get; set; }
    public string? Code { get; set; }
    public DateTimeOffset ValidFrom { get; set; }
    public DateTimeOffset Expires { get; set; }
    public ICollection<AuthorisationPermission> Permissions { get; set; } = [];
}
