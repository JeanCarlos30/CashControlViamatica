using CashControl.Application.DTOs;
using CashControl.Application.Interfaces;
using CashControl.Domain.Entities;
using CashControl.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CashControl.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly PasswordHasher<SystemUser> _hasher = new();

        public AuthService(IAuthRepository repo, IJwtTokenGenerator tokenGenerator)
        {
            _repo = repo;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _repo.LoginAsync(request.UserName, request.Password);
            if (user == null)
                return null;

            var result = _hasher.VerifyHashedPassword(user, user.Password, request.Password);
            if (result != PasswordVerificationResult.Success)
                return null;

            var token = _tokenGenerator.GenerateToken(user);

            // Obtener las opciones de menú
            var menuOptions = await _repo.MenuAsync(user.Rol_RolId ?? 0);

            var menuDto = menuOptions.Select(option => new MenuOptionDto
            {
                Label = option.Label,
                Icon = option.Icon,
                Route = option.Route
            }).ToList();

            return new AuthResponseDto
            {
                UserName = user.UserName,
                Role = user.Rol_RolId?.ToString() ?? string.Empty,
                Jwt = token,
                ExpireDate = (int)DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds(),
                Menu = menuDto,
                RoleDescripcion = user.Rol?.RolName ?? string.Empty
            };
        }
    }
}
