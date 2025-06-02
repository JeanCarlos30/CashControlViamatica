using CashControl.Domain.Entities;
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
    public class TurnRepository : ITurnRepository
    {
        private readonly CashControlDbContext _db;
        public TurnRepository(CashControlDbContext db) {
            _db = db;
        }

        public async Task<string?> AddAsync(Turn turn)
        {
            var error = new SqlParameter("@Error", SqlDbType.VarChar, 255)
            {
                Direction = ParameterDirection.Output
            };

            await _db.ExecuteSqlWithOutputAsync("sp_CrearTurno", new[]
            {
                new SqlParameter("@Description", turn.Description),
                new SqlParameter("@DateTurn", turn.DateTurn),
                new SqlParameter("@CashId", turn.Cash_CashId),
                new SqlParameter("@UserGestorId", turn.UserGestorId),
                error
            }, "@Error");

            return error.Value?.ToString();
        }
    }
}
