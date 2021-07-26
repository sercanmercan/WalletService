using System;
using System.Collections.Generic;
using System.Text;
using WalletService.Domain.AggregateModels.Wallet;

namespace WalletService.Application.InterfaceService
{
    public interface IWalletService
    {
        Wallet GetWalletById(int id);

        Wallet CreateWallet(Wallet wallet);

        Wallet UpdateWallet(Wallet user);

        void DeleteWallet(int id);
        double GetBalance(int walletId);

    }
}
