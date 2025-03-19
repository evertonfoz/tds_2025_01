using Microsoft.EntityFrameworkCore; 
using MonolitoBackend.Core.Entities; 
using MonolitoBackend.Core.Repositories; 
using MonolitoBackend.Infrastructure.Data; 
namespace MonolitoBackend.Infrastructure.Repositories;  
public class UserRepository(AppDbContext context) : IUserRepository { 
    private readonly AppDbContext _context = context;

    public async Task<User?> GetByUsernameAsync(string username) { 
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username); 
    } 
    public async Task AddAsync(User user) { 
        await _context.Users.AddAsync(user); 
        await _context.SaveChangesAsync(); 
    } 
} 