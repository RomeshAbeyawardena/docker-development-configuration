using MediatR;

namespace HSINet.Identity.Api.Token.Post;

public static class Endpoint
{
    public static async Task<IResult> PostAuthTokenV1(IMediator mediator, Request request, CancellationToken cancellationToken)
    {
        return Results.Ok(await mediator.Send(request, cancellationToken));
    }
}
