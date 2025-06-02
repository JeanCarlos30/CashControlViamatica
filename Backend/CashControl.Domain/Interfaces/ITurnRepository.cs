using CashControl.Domain.Entities;

namespace CashControl.Domain.Interfaces;

public interface ITurnRepository
{
    Task<string?> AddAsync(Turn turn);
}