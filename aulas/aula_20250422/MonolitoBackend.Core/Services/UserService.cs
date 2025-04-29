using System;
using BCrypt.Net;
using MonolitoBackend.Core.Entities;
using MonolitoBackend.Core.Repositories;

namespace MonolitoBackend.Core.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User> AddAsync(User user)
    {
       user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
       return await _userRepository.AddAsync(user);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }
}
