using CashControl.API.Utils;
using CashControl.Application.DTOs;
using CashControl.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashControl.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UserController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
        {
            var userCreateClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userCreateClaim) || !int.TryParse(userCreateClaim, out int userCreate))
                return Unauthorized(ApiResponse<string>.Fail("No se pudo identificar al usuario autenticado."));

            dto.UserCreate = userCreate;
            var result = await _usuarioService.AddAsync(dto);
            if (string.IsNullOrWhiteSpace(result))
                return Ok(ApiResponse<string>.Ok("Usuario creado correctamente.", null));
            else
                return Ok(ApiResponse<string>.Fail(result));
        }

        [HttpGet("getAll/{status}")]
        public async Task<IActionResult> GetAllByStatus(string status)
        {
            var users = await _usuarioService.GetAllByStatusAsync(status);
            return Ok(ApiResponse<IEnumerable<UserDto>>.Ok(null, users));
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var user = await _usuarioService.GetByIdAsync(userId);
            if (user == null)
                return NotFound(ApiResponse<string>.Fail("Usuario no encontrado."));
            return Ok(ApiResponse<UserDto>.Ok(null, user));
        }

        [HttpPut("{userId:int}")]
        public async Task<IActionResult> Update(int userId, [FromBody] UserDto dto)
        {
            var result = await _usuarioService.UpdateAsync(userId, dto);
            if (string.IsNullOrWhiteSpace(result))
                return Ok(ApiResponse<string>.Ok("Usuario actualizado correctamente.", null));
            else
                return BadRequest(ApiResponse<string>.Fail(result));
        }

        [HttpDelete("{userId:int}")]
        public async Task<IActionResult> Delete(int userId, [FromQuery] string newStatus)
        {
            var result = await _usuarioService.DeleteAsync(userId, newStatus);
            if (string.IsNullOrWhiteSpace(result))
                return Ok(ApiResponse<string>.Ok("Estado del usuario actualizado correctamente.", null));
            else
                return NotFound(ApiResponse<string>.Fail(result));
        }
    }
}