using CashControl.Application.DTOs;
using CashControl.Application.Interfaces;
using CashControl.Domain.Entities;
using CashControl.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var menuOptions = await _repo.MenuAsync((int)user.Rol_RolId!);

            var menuDto = menuOptions.Select(option => new MenuOptionDto
            {
                Label = option.Label,
                Icon = option.Icon,
                Route = option.Route
            }).ToList();

            return new AuthResponseDto 
            { 
                User =  user.UserName, 
                Role = user.Rol_RolId.ToString(),
                Jwt = token,
                ExpireDate = (int)DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds(),
                Menu = menuDto
            };
        }
    }
}
