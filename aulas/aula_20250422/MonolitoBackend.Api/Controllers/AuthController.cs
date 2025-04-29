using System;
using Microsoft.AspNetCore.Mvc;
using MonolitoBackend.Api.DTOs;
using MonolitoBackend.Core.Entities;
using MonolitoBackend.Core.Services;

namespace MonolitoBackend.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost]
    public async Task<ActionResult<string>> Authenticate([FromBody] AuthenticateDTO authenticateDTO) {
        var result = await _authService.AuthenticateAsync(authenticateDTO.Name, authenticateDTO.Password);
        return Ok(result);
    }
}
