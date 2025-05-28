using CashControl.Domain.Entities;
using CashControl.Domain.Interfaces;
using CashControl.Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashControl.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly CashControlDbContext _db;

        public AuthRepository(CashControlDbContext db)
        {
            _db = db;
        }

        public async Task<SystemUser?> LoginAsync(string usuario, string password)
        {
            return await _db.SystemUser.FirstOrDefaultAsync(u => u.UserName == usuario);
        }
    }
}
