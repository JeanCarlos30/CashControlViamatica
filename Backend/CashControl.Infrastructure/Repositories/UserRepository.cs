﻿using CashControl.Domain.Entities;
using CashControl.Domain.Interfaces;
using CashControl.Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashControl.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CashControlDbContext _db;
        public UserRepository(CashControlDbContext db) {
            _db = db;
        }

        public async Task<string?> AddAsync(SystemUser user)
        {
            var error = new SqlParameter("@Error", SqlDbType.VarChar, 255)
            {
                Direction = ParameterDirection.Output
            };

            await _db.ExecuteSqlWithOutputAsync("sp_CrearUsuario", new[]
            {
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@RolId", user.Rol_RolId),
                new SqlParameter("@UserCreate", user.UserCreate),
                error
            }, "@Error");

            return error.Value?.ToString();
        }

        public async Task<IEnumerable<SystemUser>> GetAllAsync()
        {
            return await _db.SystemUser
                .Include(u => u.Rol)
                .ToListAsync();
        }
        public async Task<SystemUser?> GetByIdAsync(int id)
        {
            return await _db.SystemUser
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task UpdateAsync(SystemUser user)
        {
            _db.SystemUser.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}
