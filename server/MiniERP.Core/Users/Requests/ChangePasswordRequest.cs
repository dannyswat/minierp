using FluentValidation;

namespace MiniERP.Core.Users.Requests;

public record ChangePasswordRequest
{
    public required string Username { get; init; }

    public required string Password { get; init; }

    public required string NewPassword { get; init; }
}

public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required.");

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .WithMessage("New password is required.")
            .MinimumLength(8)
            .WithMessage("New password must be at least 8 characters long.")
            .NotEqual(x => x.Password)
            .WithMessage("New password must be different from the old password.");
    }
}