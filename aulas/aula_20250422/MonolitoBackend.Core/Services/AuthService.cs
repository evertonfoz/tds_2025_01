using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MonolitoBackend.Core.Entities;
using MonolitoBackend.Core.Repositories;

namespace MonolitoBackend.Core.Services;

public class AuthService(IUserRepository userRepository, IConfiguration configuration) : IAuthService
{
    public async Task<string?> AuthenticateAsync(string userName, string password)
    {
        var user = await userRepository.GetByName(userName);
        if (BCrypt.Net.BCrypt.Verify(password,user.Password)) {
            
            return GenerateJwtToken(user);
        }
        return null;
    }

    private string GenerateJwtToken(User user) {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var token = new JwtSecurityToken(configuration["Jwt:Issuer"], 
                configuration["Jwt:Audience"], claims, 
                expires:DateTime.UtcNow.AddHours(2), signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
