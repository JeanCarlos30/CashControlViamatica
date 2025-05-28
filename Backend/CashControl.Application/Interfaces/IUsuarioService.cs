using CashControl.Application.DTOs;
using System.Threading.Tasks;

namespace CashControl.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<string?> CrearUsuarioAsync(CrearUsuarioDto dto);
    }
}