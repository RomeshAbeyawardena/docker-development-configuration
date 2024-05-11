namespace HSINet.Identity.Domain;

public class ApplicationSettings
{
    public string? TokenKey { get; set; }
    public string? EncryptionKey { get; set; }
    public IEnumerable<string> Issuers { get; set; } = [];
    public IEnumerable<string> Audiences { get; set; } = [];
    public long SessionValidityPeriodInMinutes { get; set; }
}
