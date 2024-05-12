using HSINet.Identity.Domain;
using HSINet.Identity.Domain.CSRF;
using HSINet.Shared.Hashing;
using HSINet.Shared.Transactional;
using MediatR;

namespace HSINet.Identity.Api.CSRF.Post;

public class Handler(IHasherFactory hasherFactory, IRepository<CSRFToken> repository, ApplicationSettings applicationSettings) 
    : IRequestHandler<Command, CSRFToken>
{
    private string GenerateToken(string hasherName, string token, string secret, int iterations)
    {
        var hasher = hasherFactory.GetHasher(hasherName);
        
        if(hasher == null)
        {
            throw new NullReferenceException("Hasher not found");
        }

        return hasher.Hash(token, secret, iterations);
    }

    public async Task<CSRFToken> Handle(Command request, CancellationToken cancellationToken)
    {
        request.Entity.Token = GenerateToken("", request.Entity.Token, applicationSettings.Secret, 10000);

        return await repository.Upsert(request, cancellationToken);
    }
}
