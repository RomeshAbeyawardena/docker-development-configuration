using HSINet.Shared.EntityAttributes;

namespace HSINet.Identity.Domain.CSRF;

public class CSRFToken : IIdentity
{
    public Guid? Id { get; set; }
    public required string Token { get; set; }
    public DateTimeOffset ValidFromUtc { get; set; }
    public DateTimeOffset ValidToUtc { get; set; }
}
