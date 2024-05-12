using HSINet.Shared.EntityAttributes;

namespace HSINet.Identity.Domain.Clients;

public class ClientPermission : IIdentity
{
    public Guid? Id { get; set; }
    public Guid ClientId { get; set; }
    public Guid PermissionId { get; set; }
    public Client? Client { get; set; }
    public Permissions.Permission? Permission { get; set; }
}
