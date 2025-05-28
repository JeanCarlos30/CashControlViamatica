using CashControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashControl.Domain.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(SystemUser user);
    }
}
