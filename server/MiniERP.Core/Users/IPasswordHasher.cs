using System.Threading.Tasks;

namespace MiniERP.Core.Users;

public interface IPasswordHasher
{
    Task<string> HashPassword(string password);
    Task<bool> VerifyHashedPassword(string hashedPassword, string providedPassword);
}