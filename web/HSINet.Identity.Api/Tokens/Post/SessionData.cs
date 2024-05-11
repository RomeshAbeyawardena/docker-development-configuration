namespace HSINet.Identity.Api.Tokens.Post;

public class SessionData
{
    public Domain.AuthorisationCodes.Authorisation? Authorisation { get; init; }
    public Domain.Clients.Client? Client { get; init; }
}
