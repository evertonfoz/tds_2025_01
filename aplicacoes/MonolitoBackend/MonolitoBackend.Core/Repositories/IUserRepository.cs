using MonolitoBackend.Core.Entities; 

namespace MonolitoBackend.Core.Repositories; 

public interface IUserRepository { 
    Task<User?> GetByUsernameAsync(string username); 
    Task AddAsync(User user); 
} 