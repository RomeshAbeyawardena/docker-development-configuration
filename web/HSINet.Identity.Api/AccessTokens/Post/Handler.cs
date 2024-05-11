using HSINet.Shared.Transactional;
using MediatR;

namespace HSINet.Identity.Api.AccessTokens.Post;

public class Handler(IRepository<Domain.AccessTokens.AccessToken> accessTokenRepository) 
    : IRequestHandler<Command, Domain.AccessTokens.AccessToken>
{
    public Task<Domain.AccessTokens.AccessToken> Handle(Command request, CancellationToken cancellationToken)
    {
        return accessTokenRepository.Upsert(request, cancellationToken);
    }
}
