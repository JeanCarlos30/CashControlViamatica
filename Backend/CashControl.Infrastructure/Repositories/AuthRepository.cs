using CashControl.Domain.Entities;
using CashControl.Domain.Interfaces;
using CashControl.Infrastructure.Context;
using CashControlSolution.Domain.Entities;
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
            return await _db.SystemUser
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.UserName == usuario);
        }

        public async Task<List<MenuOption>?> MenuAsync(int role)
        {
            return await _db.OptionRole
                            .Where(or => or.Role_RoleId == role)
                            .OrderBy(or => or.Order)
                            .Select(or => or.MenuOption)
                            .ToListAsync();
        }
    }
}
