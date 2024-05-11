using MediatR;
using System.Text.Json.Serialization;

namespace HSINet.Identity.Api.Tokens.Post;

public class Request : IRequest<Response>
{
    [JsonPropertyName("GRANT_TYPE")]
    public string? GrantType { get; set; }

    [JsonPropertyName("CODE")]
    public string? Code { get; set; }
    [JsonPropertyName("REDIRECT_URI")]
    public string? RedirectUrl { get; set; }
    [JsonPropertyName("CLIENT_ID")]
    public string? ClientId { get; set; }

    [JsonPropertyName("CLIENT_SECRET")]
    public string? ClientSecret { get; set; }

}
