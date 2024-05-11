using MediatR;
using HSINet.Identity.Domain.CSRF;
namespace HSINet.Identity.Api.CSRF.Get;

public record Query : IRequest<CSRFToken?>
{
    public string? Token { get; init; }
}
