using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(); //database saving management
    }
}
