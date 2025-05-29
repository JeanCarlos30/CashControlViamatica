using CashControl.API.Utils;
using CashControl.Application.DTOs;
using CashControl.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashControl.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UserController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CrearUsuario([FromBody] UserCreateDto dto)
        {
            var result = await _usuarioService.AddAsync(dto);
            Console.WriteLine("El valor de result es {0}", result);
            if (string.IsNullOrWhiteSpace(result))
            {
                Console.WriteLine("El valor de result es vacio");
                return Ok(ApiResponse<string>.Ok("Usuario creado correctamente.", null));
            }
            else
            {
                Console.WriteLine("El valor de result no es vacio"); 
                return Ok(ApiResponse<string>.Fail(result));
            }
        }
    }
}