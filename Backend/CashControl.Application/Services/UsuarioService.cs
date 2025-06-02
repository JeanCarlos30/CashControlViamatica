using Azure.Core;
using CashControl.Application.DTOs;
using CashControl.Application.Interfaces;
using CashControl.Domain.Entities;
using CashControl.Domain.Interfaces;
using CashControl.Infrastructure.Context;
using CashControlSolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CashControl.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        //private readonly ICashControlDbContext _db;
        private readonly IUserRepository _repo;
        private readonly PasswordHasher<SystemUser> _hasher = new();

        public UsuarioService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<string?> AddAsync(UserCreateDto dto)
        {
            if (!ValidarFormatoPassword(dto.Password))
            {
                return "La contraseña debe tener al menos un número, al menos una letra mayúscula, mínimo 8 caracteres y máximo 30 caracteres.";
            }
            var user = new SystemUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Rol_RolId = dto.RolId,
                UserCreate = dto.UserCreate
            };
            user.Password = _hasher.HashPassword(user, dto.Password);

            var result = await _repo.AddAsync(user);

            return result?.ToString();
        }

        public async Task<IEnumerable<UserDto>> GetAllByStatusAsync(string status)
        {
            var users = await _repo.GetAllAsync();
            return users
                .Where(u => u.UserStatus_StatusId == status)
                .Select(MapToUserDto)
                .ToList();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            return user == null ? null : MapToUserDto(user);
        }

        public async Task<string?> UpdateAsync(int id, UserDto dto)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null)
                return "Usuario no encontrado.";

            // Actualiza solo los campos permitidos
            user.Email = dto.Email ?? user.Email;
            user.Rol_RolId = dto.RolId != 0 ? dto.RolId : user.Rol_RolId;

            await _repo.UpdateAsync(user);
            return null;
        }

        public async Task<string?> DeleteAsync(int id, string newStatus)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null)
                return "Usuario no encontrado.";

            user.UserStatus_StatusId = newStatus;
            await _repo.UpdateAsync(user);
            return null;
        }

        private bool ValidarFormatoPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            var regex = new Regex(@"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,30}$");
            return regex.IsMatch(password);
        }

        private bool EsUsuarioValido(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName) || userName.Length < 8 || userName.Length > 20)
                return false;
            if (!userName.Any(char.IsLetter) || !userName.Any(char.IsDigit))
                return false;
            if (userName.Any(c => !char.IsLetterOrDigit(c)))
                return false;
            return true;
        }

        // Método de mapeo
        private UserDto MapToUserDto(SystemUser user)
        {
            return new UserDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                RolId = user.Rol_RolId,
                RolName = user.Rol?.RolName,
                Status = user.UserStatus_StatusId
            };
        }
    }
}