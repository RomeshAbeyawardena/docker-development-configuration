using Microsoft.AspNetCore.Http.HttpResults;

namespace HSINet.Identity.Api.CSRF.Get;

public static class Endpoint
{
    public static async Task<IResult> GetV1()
    {
        await Task.CompletedTask;
        return Results.Ok();
    }
}
