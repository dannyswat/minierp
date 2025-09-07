namespace MiniERP.Core.Users;

using System;
using MiniERP.Core.Entities;

public class UserStatus : Entity
{
    public UserStatus() { }

    public int UserId { get; set; }
    public bool IsOnline { get; set; }
    public DateTimeOffset LastLogin { get; set; }
    public DateTimeOffset LastPasswordChange { get; set; }
    public DateTimeOffset LastFailedLogin { get; set; }
    public int FailedLoginAttempts { get; set; }
    public DateTimeOffset LastLockedOut { get; set; }
}