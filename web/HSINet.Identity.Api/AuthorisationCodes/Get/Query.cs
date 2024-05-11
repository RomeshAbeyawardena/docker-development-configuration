using MediatR;

namespace HSINet.Identity.Api.AuthorisationCodes.Get;

public record Query : IRequest<Domain.AuthorisationCodes.Authorisation>
{
    public string? Code { get; init; }
}
