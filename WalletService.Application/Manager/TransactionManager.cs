using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalletService.Application.InterfaceService;
using WalletService.Application.Repository;
using WalletService.Domain.AggregateModels.Transactions;
using WalletService.Domain.AggregateModels.Wallet;

namespace WalletService.Application.Manager
{
    public class TransactionManager : ITransactionService
    {
        private ITransactionRepository _transactionRepository;

        //Dependency Injection
        public TransactionManager(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        //public Task<WalletTransaction> CreateTransaction(WalletTransaction transaction)
        //{
        //    return _transactionRepository.CreateTransaction(transaction);
        //}

        public Task<WalletTransaction> WithdrawTransaction(RequestWithdrawTransactionDto requestWalletTransactionDto)
        {

            return _transactionRepository.WithdrawTransaction(requestWalletTransactionDto);
        }

        public Task<List<WalletTransaction>> getAllTransaction(int walletId)
        {
            return _transactionRepository.getAllTransaction(walletId);
        }
        public Task<WalletTransaction> DepositTransaction(RequestDepositTransactionDto requestDepositTransactionDto)
        {
            return _transactionRepository.DepositTransaction(requestDepositTransactionDto);
        }
    }
}
