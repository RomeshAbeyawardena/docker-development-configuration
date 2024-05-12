using HSINet.Shared.Hashing;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HSINet.Identity.Api.CSRF.Post;

public static class Endpoint
{
    public static async Task<IResult> GenerateCSRFV1(IMediator mediator, CancellationToken cancellationToken)
    {
        return Results.Ok(await mediator.Send(
            new Command
            {
                Entity = new Domain.CSRF.CSRFToken
                {
                    Token = Guid.NewGuid().ToString("x")
                },
                CommitChanges = true
            }, cancellationToken)); ;
    }
}
