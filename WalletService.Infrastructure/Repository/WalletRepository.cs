using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletService.Application.Repository;
using WalletService.Domain.AggregateModels.Users;
using WalletService.Domain.AggregateModels.Wallet;
using WalletService.Infrastructure.EntityFrameworkCore;

namespace WalletService.Infrastructure.Repository
{
    public class WalletRepository : IWalletRepository
    {
        public Wallet CreateWallet(Wallet wallet)
        {
            using (var userDbContext = new WalletServiceDbContext())
            {
                userDbContext.Wallets.Add(wallet);
                userDbContext.SaveChanges();

                return wallet;
            }
        }

        public void DeleteWallet(int id)
        {
            using (var userDbContext = new WalletServiceDbContext())
            {
                var deleteUser = GetWalletById(id);
                userDbContext.Wallets.Remove(deleteUser);
                userDbContext.SaveChanges();
            }
        }

        public Wallet GetWalletById(int id)
        {
            using (var userDbContext = new WalletServiceDbContext())

                return userDbContext.Wallets.Find(id);
        }

        public Task<int> SaveChangesAsync()
        {
            return Task.FromResult(1);
        }

        public Wallet UpdateWallet(Wallet wallet)
        {
            using (var userDbContext = new WalletServiceDbContext())
            {
                userDbContext.Wallets.Update(wallet);
                userDbContext.SaveChanges();
                return wallet;
            }
        }

        public double GetBalance(int walletId)
        {
            using (var userDbContext = new WalletServiceDbContext())
            {
                var wallet = userDbContext.Wallets.Find(walletId);
                return wallet.balance;
            }


        }
    }
}
