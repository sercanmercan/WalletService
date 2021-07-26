using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalletService.Domain.AggregateModels.Transactions;
using WalletService.Domain.AggregateModels.Wallet;

namespace WalletService.Application.InterfaceService
{
    public interface ITransactionService
    {
        public Task<WalletTransaction> WithdrawTransaction(RequestWithdrawTransactionDto requestWalletTransactionDto);
        public Task<List<WalletTransaction>> getAllTransaction(int walletId);
        public Task<WalletTransaction> DepositTransaction(RequestDepositTransactionDto requestDepositTransactionDto);
    }
}
