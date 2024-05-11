using System.Text.Json.Serialization;

namespace HSINet.Identity.Api.Token.Post;

public class Response
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("access_token")]
    public string? TokenType { get; set; }

    [JsonPropertyName("access_token")]
    public long? Expires { get; set; }

    [JsonPropertyName("access_token")]
    public string? RefreshToken { get; set; }
}
