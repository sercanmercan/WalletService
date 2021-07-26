using System;
using System.Collections.Generic;
using System.Text;
using WalletService.Domain.AggregateModels.Wallet;
using WalletService.Domain.SeedWork;

namespace WalletService.Application.Repository
{
    public interface IWalletRepository : IRepository
    {

        Wallet GetWalletById(int id);

        Wallet CreateWallet(Wallet wallet);

        Wallet UpdateWallet(Wallet user);

        void DeleteWallet(int id);
        public double GetBalance(int walletId);
    }
}
