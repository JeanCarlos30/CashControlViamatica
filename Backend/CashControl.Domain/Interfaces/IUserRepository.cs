using CashControl.Domain.Entities;

namespace CashControl.Domain.Interfaces;

public interface IUserRepository
{
    Task<string?> AddAsync(SystemUser user);
    Task<IEnumerable<SystemUser>> GetAllAsync();
    Task<SystemUser?> GetByIdAsync(int id);
    Task UpdateAsync(SystemUser user);
}