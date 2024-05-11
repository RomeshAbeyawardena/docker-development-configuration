namespace HSINet.Identity.Domain.AuthorisationCodes;

public class AuthorisationPermission
{
    public Guid Id { get; set; }
    public Guid AuthorisationId { get; set; }
    public Guid PermissionId { get; set; }
    public Authorisation? Authorisation { get; set; }
    public Permissions.Permission? Permission { get; set; }
}
