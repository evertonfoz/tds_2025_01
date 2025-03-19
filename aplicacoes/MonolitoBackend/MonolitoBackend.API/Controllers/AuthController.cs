using Microsoft.AspNetCore.Mvc;
using MonolitoBackend.API.DTOs;
using MonolitoBackend.Core.Entities; 
using MonolitoBackend.Core.Services; 

namespace MonolitoBackend.API.Controllers;  

[ApiController] 
[Route("api/auth")] 
public class AuthController(AuthService authService) : ControllerBase { 
    private readonly AuthService _authService = authService;

    [HttpPost("login")] 
    public async Task<ActionResult<string>> Login([FromBody] User user) { 
        var token = await _authService.AuthenticateAsync(user.Username, user.PasswordHash); 
        if (token == null) 
            return Unauthorized("Invalid credentials"); 
        return Ok(new { Token = token }); 
    } 
    [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _authService.RegisterUser(registerDTO.Username, registerDTO.Role, registerDTO.Password);

            return Ok(new { message = "Usuário registrado com sucesso!" });
        }
} 