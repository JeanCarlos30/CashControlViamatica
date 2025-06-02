using CashControl.Application.DTOs;
using System.Threading.Tasks;

namespace CashControl.Application.Interfaces
{
    public interface ITurnService
    {
        Task<string?> AddAsync(TurnDto dto);
    }
}