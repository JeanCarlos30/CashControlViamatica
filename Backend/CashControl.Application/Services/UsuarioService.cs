using CashControl.Application.DTOs;
using CashControl.Application.Interfaces;
using CashControl.Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace CashControl.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ICashControlDbContext _db;

        public UsuarioService(ICashControlDbContext db)
        {
            _db = db;
        }

        public async Task<string?> CrearUsuarioAsync(CrearUsuarioDto dto)
        {
            var error = new SqlParameter("@Error", SqlDbType.VarChar, 255)
            {
                Direction = ParameterDirection.Output
            };

            await _db.ExecuteSqlWithOutputAsync("sp_CrearUsuario", new[]
            {
                new SqlParameter("@UserName", dto.UserName),
                new SqlParameter("@Email", dto.Email),
                new SqlParameter("@Password", dto.Password),
                new SqlParameter("@RolId", dto.RolId),
                new SqlParameter("@UserCreate", dto.UserCreate),
                error
            }, "@Error");

            return error.Value?.ToString();
        }
    }
}