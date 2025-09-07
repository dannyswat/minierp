using System;
using System.Threading.Tasks;
using FluentValidation;
using MiniERP.Core.Repositories;
using MiniERP.Core.Users.Requests;

namespace MiniERP.Core.Users;

public class UserService(
    IRepository<User> userRepository,
    IRepository<UserStatus> userStatusRepository,
    IUnitOfWork unitOfWork,
    IPasswordHasher passwordHasher)
{
    public const string UserCreatedEvent = "UserCreated";

    private static readonly CreateUserRequestValidator CreateUserRequestValidator = new();

    public async Task<User> CreateUser(CreateUserRequest request)
    {
        var validateResult = await CreateUserRequestValidator.ValidateAsync(request);
        if (!validateResult.IsValid)
            throw new ValidationException("create user failed", validateResult.Errors);

        var user = new User
        {
            Username = request.Username,
            PasswordHash = await passwordHasher.HashPassword(request.Password),
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            DisplayName = request.DisplayName
        };
        var status = new UserStatus();

        await unitOfWork.UseTransaction(async (uow) =>
        {
            await userRepository.Add(user, uow);
            uow.DispatchEventAfterCommit(UserCreatedEvent, user);
            status.UserId = user.Id;
            await userStatusRepository.Add(status, uow);
        });

        return user;
    }
}