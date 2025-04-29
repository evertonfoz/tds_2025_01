using System;
using MonolitoBackend.Core.Entities;

namespace MonolitoBackend.Core.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> AddAsync(User user);
}
