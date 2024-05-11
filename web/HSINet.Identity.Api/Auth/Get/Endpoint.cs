using MediatR;
using System.Text;
using System.Web;

namespace HSINet.Identity.Api.Auth.Get;

public static class Endpoint
{
    public static async Task<IResult> GetAuthV1(IMediator mediator,
        AuthorisationRequest request, CancellationToken cancellationToken)
    {       
        var response = await mediator.Send(request, cancellationToken);
        var redirectUrl = new StringBuilder(request.RedirectedUri);
        var separator = '?';
        
        if(!string.IsNullOrWhiteSpace(response.Code))
        {
            redirectUrl.Append($"{separator}code={HttpUtility.UrlEncode(response.Code)}");
            separator = '&';
        }

        if (!string.IsNullOrWhiteSpace(response.State))
        {
            redirectUrl.Append($"{separator}state={HttpUtility.UrlEncode(response.State)}");
            separator = '&';
        }

        if (!string.IsNullOrWhiteSpace(response.StateFormat))
        {
            redirectUrl.Append($"{separator}stateFormat={HttpUtility.UrlEncode(response.StateFormat)}");
        }

        return Results.Redirect(redirectUrl.ToString(), true);
    }
}
