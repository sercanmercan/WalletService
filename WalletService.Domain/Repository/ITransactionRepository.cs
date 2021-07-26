using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalletService.Domain.AggregateModels.Transactions;
using WalletService.Domain.AggregateModels.Wallet;
using WalletService.Domain.SeedWork;

namespace WalletService.Application.Repository
{
    public interface ITransactionRepository : IRepository
    {
        public Task<WalletTransaction> WithdrawTransaction(RequestWithdrawTransactionDto requestWalletTransactionDto);
        public  Task<WalletTransaction> CreateTransaction(WalletTransaction transaction);
        public  Task<List<WalletTransaction>> getAllTransaction(int walletId);
        public Task<WalletTransaction> DepositTransaction(RequestDepositTransactionDto requestDepositTransactionDto);
    }
}