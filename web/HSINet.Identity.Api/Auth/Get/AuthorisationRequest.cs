using System.Text.Json.Serialization;

namespace HSINet.Identity.Api.Auth.Get;

public record AuthorisationRequest 
{
    [JsonPropertyName("response_type")]
    public string? ResponseType { get; init; }
    
    [JsonPropertyName("client_id")]
    public string? ClientId { get; init; }

    [JsonPropertyName("redirect_uri")]
    public string? RedirectedUri { get; init; }

    [JsonIgnore]
    public Uri? RedirectUri => 
        Uri.TryCreate(RedirectedUri, UriKind.Absolute, out  var redirectUri) 
        ? redirectUri : null;

    [JsonPropertyName("scope")]
    public string? Scope { get; init; }

    [JsonIgnore]
    public IEnumerable<string> Scopes => Scope?.Split(' ', 
        StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries) ?? [];

    [JsonPropertyName("csrf_token")]
    public string? CsrfToken { get; init; }
}
