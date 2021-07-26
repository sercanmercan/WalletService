using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WalletService.Domain.AggregateModels.Transactions
{
    public class RequestWithdrawTransactionDto
    {
        [Required]
        public int walletId { get; set; }

        [Required]
        public double amount { get; set; }
    }
}
