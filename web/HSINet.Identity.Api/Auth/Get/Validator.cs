using FluentValidation;

namespace HSINet.Identity.Api.Auth.Get;

public class Validator : AbstractValidator<AuthorisationRequest>
{
    public Validator()
    {
        RuleFor(x => x.ResponseType)
            .NotEmpty()
            .WithMessage("Response type is required.")
            .Must(rt => rt == "code" || rt == "token")
            .WithMessage("Invalid response type. Valid types are 'code' or 'token'.");

        RuleFor(x => x.ClientId)
            .NotEmpty()
            .WithMessage("Client ID is required.");

        RuleFor(x => x.RedirectedUri)
            .NotEmpty()
            .WithMessage("Redirect URI is required.");

        RuleFor(x => x.RedirectUri)
            .NotNull()
            .WithMessage("Redirect URI must be a valid URL. Ensure the URL is properly formatted.");

        RuleFor(x => x.Scope)
            .NotEmpty()
            .WithMessage("Scope is required.");

        RuleFor(x => x.CsrfToken)
            .NotEmpty()
            .WithMessage("CSRF token is required.");
    }
}