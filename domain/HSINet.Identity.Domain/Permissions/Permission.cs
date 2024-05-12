using HSINet.Shared.EntityAttributes;

namespace HSINet.Identity.Domain.Permissions;

public class Permission : IIdentity
{
    public Guid? Id { get; set; }
    public required string Name { get; set; }
}
