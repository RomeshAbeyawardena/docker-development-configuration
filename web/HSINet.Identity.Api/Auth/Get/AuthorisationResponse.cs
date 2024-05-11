namespace HSINet.Identity.Api.Auth.Get;

public record AuthorisationResponse
{
    public string? Code { get; init; }
    public string? State { get; init; }
    public string? StateFormat { get; init; }
}
