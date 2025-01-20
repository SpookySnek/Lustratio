using Lustratio.Server.Data;
using Lustratio.Server.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lustratio.Server.Features.Users.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    
    public UserRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users
            .OrderBy(x => x.Id)
            .ToListAsync();
    }
    
    public async Task<User> GetUserByIdAsync(int userId)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Id == userId);
    }
}