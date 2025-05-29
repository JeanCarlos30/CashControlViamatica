using CashControl.Domain.Entities;
using CashControlSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CashControl.Domain.Interfaces
{
    public interface IAuthRepository
    {   
        Task<SystemUser?> LoginAsync(string usuario, string password);
        Task<List<MenuOption>?> MenuAsync(int role);
    }
}
