using MediatR;

namespace HSINet.Identity.Api.Auth.Get;

public static class Endpoint
{
    public static async Task<IResult> GetAuthV1(IMediator mediator,
        AuthorisationRequest request, CancellationToken cancellationToken)
    {
        return Results.Ok(request);
    }
}
