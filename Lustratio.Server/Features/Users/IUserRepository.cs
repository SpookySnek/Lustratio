using Lustratio.Server.Domain;

namespace Lustratio.Server.Features.Users;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int userId);
}