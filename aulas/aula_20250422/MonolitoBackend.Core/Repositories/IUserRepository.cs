using System;
using MonolitoBackend.Core.Entities;

namespace MonolitoBackend.Core.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> AddAsync(User user);
    Task<User> GetByName(string name);
}
