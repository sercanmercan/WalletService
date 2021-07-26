using System;
using System.Collections.Generic;
using System.Text;
using WalletService.Application.InterfaceService;
using WalletService.Application.Repository;
using WalletService.Domain.AggregateModels.Wallet;

namespace WalletService.Application.Manager
{
    public class WalletManager : IWalletService
    {
        private IWalletRepository _walletRepository;

        //Dependency Injection
        public WalletManager(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        #region Wallets
        public Wallet CreateWallet(Wallet wallet)
        {
            if (wallet.usersId != 0 && wallet.walletType != "" && wallet.balance != 0 && wallet.currency!="")
            {
                wallet.createdOn = DateTime.Now;                
                return _walletRepository.CreateWallet(wallet);
            }


            else
                throw new Exception("You should fill customer no, tc no, email and password");
        }

        public void DeleteWallet(int id)
        {
            if (id > 0)
                _walletRepository.DeleteWallet(id);
            else
                throw new Exception("Id must be greater than zero.");
        }

        public Wallet GetWalletById(int id)
        {
            if (id > 0)
                return _walletRepository.GetWalletById(id);
            else
                throw new Exception("Id must be greater than zero.");
        }

        public Wallet UpdateWallet(Wallet wallet)
        {   
            return _walletRepository.UpdateWallet(wallet);
        }

        public double GetBalance(int walletId)
        {
            return _walletRepository.GetBalance(walletId);
        }
        #endregion
    }
}
