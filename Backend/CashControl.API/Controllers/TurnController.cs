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
    public class TurnController : ControllerBase
    {
        private readonly ITurnService _turnService;

        public TurnController(ITurnService turnService)
        {
            _turnService = turnService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TurnDto dto)
        {
            var userCreateClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userCreateClaim) || !int.TryParse(userCreateClaim, out int userCreate))
                return Unauthorized(ApiResponse<string>.Fail("No se pudo identificar al usuario autenticado."));

            dto.UserGestorId = userCreate;
            var result = await _turnService.AddAsync(dto);
            if (string.IsNullOrWhiteSpace(result))
                return Ok(ApiResponse<string>.Ok("Turno creado correctamente.", null));
            else
                return Ok(ApiResponse<string>.Fail(result));
        }
    }
}