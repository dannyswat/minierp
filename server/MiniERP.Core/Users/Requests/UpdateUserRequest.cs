using System.Data;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MiniERP.Core.Repositories;

namespace MiniERP.Core.Users.Requests;

public record UpdateUserRequest
{
    public required int UserId { get; init; }

    public string? Email { get; init; }

    public string? PhoneNumber { get; init; }

    public string? DisplayName { get; init; }
}

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    private readonly IRepository<User> userRepository;

    public UpdateUserRequestValidator(IRepository<User> userRepository)
    {
        this.userRepository = userRepository;

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("User ID is required.");

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage("Invalid email format.");

        RuleFor(x => x.PhoneNumber)
        .Matches(@"^\+?[1-9]\d{1,14}$")
        .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
        .WithMessage("Invalid phone number format.");
    }

    public override async Task<ValidationResult> ValidateAsync(ValidationContext<UpdateUserRequest> context, CancellationToken cancellation = default)
    {
        var result = await base.ValidateAsync(context, cancellation);
        if (!result.IsValid)
            return result;

        var request = context.InstanceToValidate;

        var user = await userRepository.GetById(request.UserId);
        if (user == null)
        {
            result.Errors.Add(new ValidationFailure(nameof(UpdateUserRequest.UserId), "User not found."));
            return result;
        }

        if (!string.IsNullOrEmpty(request.Email) && request.Email == user.Email)
        {
            result.Errors.Add(new ValidationFailure(nameof(UpdateUserRequest.Email), "New email must be different from the current email."));
            return result;
        }

        if (!string.IsNullOrEmpty(request.PhoneNumber) && request.PhoneNumber == user.PhoneNumber)
        {
            result.Errors.Add(new ValidationFailure(nameof(UpdateUserRequest.PhoneNumber), "New phone number must be different from the current phone number."));
            return result;
        }

        return result;
    }
}