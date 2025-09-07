namespace MiniERP.Core.Authorization;

using MiniERP.Core.Roles;

public class UserRole
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
}
