using HSINet.Shared.Transactional;
using MediatR;

namespace HSINet.Identity.Api.Tokens.Post;

public class Handler(IMediator mediator, IRepository<Domain.AccessTokens.AccessToken> repository) 
    : IRequestHandler<Request, Response>
{
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var client = await mediator.Send(
            new Clients.Query { 
                Reference = request.ClientId 
            }, cancellationToken);


        throw new NotImplementedException();
    }
}
