using CashControl.Domain.Entities;

namespace CashControl.Domain.Interfaces;

public interface IUserRepository
{
    Task<SystemUser?> GetByIdAsync(int id);
    Task<IEnumerable<SystemUser>> GetAllAsync();
    Task AddAsync(SystemUser user);
    Task UpdateAsync(SystemUser user);
    Task DeleteAsync(SystemUser user);
}