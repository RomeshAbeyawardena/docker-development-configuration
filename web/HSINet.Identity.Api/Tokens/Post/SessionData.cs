namespace HSINet.Identity.Api.Tokens.Post;

public class SessionData
{
    public Domain.AuthorisationCodes.Authorisation? Authorisation { get; init; }
    public Domain.Clients.Client? Client { get; init; }
    public IEnumerable<string> Scopes { get; init; } = [];
    public string? CSRFToken { get; init; }
}
