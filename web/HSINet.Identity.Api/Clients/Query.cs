using MediatR;

namespace HSINet.Identity.Api.Clients;

public record Query : IRequest<Domain.Clients.Client>
{
    public string? Reference { get; init; }
}
