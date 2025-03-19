using System.ComponentModel.DataAnnotations;

namespace MonolitoBackend.API.DTOs;

public class RegisterUserDTO
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Role { get; set; }

    [Required, MinLength(6)]
    public string Password { get; set; }
}
