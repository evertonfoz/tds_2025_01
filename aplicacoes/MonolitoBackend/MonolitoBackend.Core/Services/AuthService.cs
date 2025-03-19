using System.IdentityModel.Tokens.Jwt; 
using System.Security.Claims; 
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens; 
using MonolitoBackend.Core.Entities; 
using MonolitoBackend.Core.Repositories; 

namespace MonolitoBackend.Core.Services; 
public class AuthService(IUserRepository userRepository, IConfiguration configuration)
{ 
    private readonly IUserRepository _userRepository = userRepository; 
    private readonly IConfiguration _configuration = configuration;

    public async Task<string?> AuthenticateAsync(string username, string password) { 
        var user = await _userRepository.GetByUsernameAsync(username); 
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) { 
            return null; // Credenciais inválidas 
        } 
        return GenerateJwtToken(user); 
    } 
    private string GenerateJwtToken(User user) { 
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"])); 
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); 
        var claims = new[] { 
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), 
            new Claim(ClaimTypes.Name, user.Username), new Claim(ClaimTypes.Role, user.Role) 
        }; 
        var token = new JwtSecurityToken( _configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddHours(2), signingCredentials: credentials); 
        return new JwtSecurityTokenHandler().WriteToken(token); 
    } 
    public async Task RegisterUser(string username, string role, string password)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = username,
            Role = role,
            PasswordHash = hashedPassword
        };

        await _userRepository.AddAsync(user);
    }
}