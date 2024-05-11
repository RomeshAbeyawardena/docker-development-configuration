using MediatR;

namespace HSINet.Identity.Api.AccessToken.Post;

public class Handler : IRequestHandler<Command, Domain.AccessTokens.AccessToken>
{
    public Task<Domain.AccessTokens.AccessToken> Handle(Command request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
