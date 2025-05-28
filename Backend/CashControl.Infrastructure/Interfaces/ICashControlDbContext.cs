using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace CashControl.Application.Interfaces
{
    public interface ICashControlDbContext
    {
        Task<int> ExecuteSqlAsync(string spName, SqlParameter[] parameters);
        Task<string?> ExecuteSqlWithOutputAsync(string spName, SqlParameter[] parameters, string outputParamName);
    }
}