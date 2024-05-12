namespace HSINet.Identity.Api.CSRF;

public static class Endpoints
{
    public static void AddCSRFEndpoints(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/api/auth/csrf", Get.Endpoint.GetV1)
            .WithName("Get CSRF")
            .WithTags("Csrf");

        builder.MapPost("/api/auth/csrf", Post.Endpoint.GenerateCSRFV1)
            .WithName("Generate CSRF")
            .WithTags("Csrf"); ;
    }
}
