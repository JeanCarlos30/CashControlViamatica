using CashControl.Domain.Entities;

namespace CashControl.Domain.Interfaces;

public interface IUserRepository
{
    Task<string?> AddAsync(SystemUser user);
}