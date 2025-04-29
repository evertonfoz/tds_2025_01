using System;

namespace MonolitoBackend.Api.DTOs;

public class AuthenticateDTO
{
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
