using MediatR;

namespace HSINet.Identity.Api.Auth.Get;

public static class Endpoint
{
    public static async Task<IResult> GetAuthV1(IMediator mediator,
        AuthorisationRequest request, CancellationToken cancellationToken)
    {       
        var response = await mediator.Send(request, cancellationToken);
        var redirectUrl = $"{request.RedirectedUri}?code={response.Code}&state={response.State}";
        return Results.Redirect(redirectUrl, true);
    }
}
