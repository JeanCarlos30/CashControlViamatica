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

        private bool ValidarFormatoPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            var regex = new Regex(@"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,30}$");
            return regex.IsMatch(password);
        }

    }
}