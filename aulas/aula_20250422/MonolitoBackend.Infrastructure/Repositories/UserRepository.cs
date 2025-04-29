using Microsoft.EntityFrameworkCore;
using MonolitoBackend.Core.Entities;
using MonolitoBackend.Core.Repositories;
using MonolitoBackend.Infrastructure.Data;

namespace MonolitoBackend.Infrastructure.Repositories;

public class UserRepository(AppDbContext appDbContext) : IUserRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;
    public async Task<User> AddAsync(User user)
    {
        await _appDbContext.Users.AddAsync(user);
        await _appDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _appDbContext.Users.ToListAsync();
    }

    public async Task<User> GetByName(string name)
    {
        return await _appDbContext.Users.Where(u => u.Name == name).SingleAsync();
    }
}
