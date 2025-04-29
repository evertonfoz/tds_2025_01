using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonolitoBackend.Core.Entities;
using MonolitoBackend.Core.Services;

namespace MonolitoBackend.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<User>>> GetAll() {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] User user) {
        if (user == null)
           return BadRequest("Invalid user data");

        await _userService.AddAsync(user);

        return Created(nameof(Create), user);
    }

}
