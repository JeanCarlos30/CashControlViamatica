using CashControl.API.Utils;
using CashControl.Application.DTOs;
using CashControl.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var token = await _authService.LoginAsync(dto);

        if (token is null)
            return Unauthorized(ApiResponse<string>.Fail("Credenciales inválidas."));

        return Ok(ApiResponse<AuthResponseDto>.Ok("Inicio de sesión exitoso", token));
    }
}
