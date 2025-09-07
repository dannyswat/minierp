using FluentValidation;

namespace MiniERP.Core.Users.Requests;

public record CreateUserRequest
{
    public required string Username { get; init; }

    public required string Password { get; init; }

    public required string Email { get; init; }

    public string PhoneNumber { get; init; } = string.Empty;

    public required string DisplayName { get; init; }
}

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");

        RuleFor(x => x.DisplayName)
            .NotEmpty()
            .WithMessage("Display name is required.");
    }
}