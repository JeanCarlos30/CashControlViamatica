using CashControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using CashControl.Application.Interfaces;
using CashControlSolution.Domain.Entities;

namespace CashControl.Infrastructure.Context
{
    public class CashControlDbContext : DbContext, ICashControlDbContext
    {
        public CashControlDbContext(DbContextOptions<CashControlDbContext> options) : base(options) { }

        public DbSet<SystemUser> SystemUser => Set<SystemUser>();
        public DbSet<OptionRole> OptionRole => Set<OptionRole>();
        public DbSet<MenuOption> MenuOption => Set<MenuOption>();

        public async Task<int> ExecuteSqlAsync(string spName, SqlParameter[] parameters)
        {
            var sql = $"EXEC {spName} " + string.Join(",", parameters.Select(p => p.ParameterName));
            return await Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public async Task<string?> ExecuteSqlWithOutputAsync(string spName, SqlParameter[] parameters, string outputParamName)
        {
            using var command = Database.GetDbConnection().CreateCommand();
            command.CommandText = spName;
            command.CommandType = CommandType.StoredProcedure;

            foreach (var param in parameters)
            {
                command.Parameters.Add(param);
            }

            if (command.Connection.State != ConnectionState.Open)
                await command.Connection.OpenAsync();

            await command.ExecuteNonQueryAsync();

            var output = command.Parameters[outputParamName].Value?.ToString();

            return output;
        }
    }
}