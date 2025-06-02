using CashControl.Application.DTOs;
using System.Threading.Tasks;

namespace CashControl.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<string?> AddAsync(UserCreateDto dto);
        Task<IEnumerable<UserDto>> GetAllByStatusAsync(string status);
        Task<UserDto?> GetByIdAsync(int id);
        Task<string?> UpdateAsync(int id, UserDto dto);
        Task<string?> DeleteAsync(int id, string newStatus);
    }
}