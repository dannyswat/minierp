namespace MiniERP.Core.Users;

using System;
using MiniERP.Core.Entities;

public class User : AggregateRoot
{
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public string? ProfileImage { get; set; }

    public bool IsDisabled { get; set; }
    public bool IsLockedOut { get; set; }
}