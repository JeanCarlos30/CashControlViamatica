using CashControl.API.Utils;
using CashControl.Application.DTOs;
using CashControl.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashControl.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] CrearUsuarioDto dto)
        {
            var result = await _usuarioService.CrearUsuarioAsync(dto);
            if (result is null)
            {
                return Ok(ApiResponse<string>.Ok("Usuario creado correctamente.", null));
            }
            else
            {
                return Ok(ApiResponse<string>.Fail(result));
            }
        }
    }
}