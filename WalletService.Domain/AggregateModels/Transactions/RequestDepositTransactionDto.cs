using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace WalletService.Domain.AggregateModels.Transactions
{
    public class RequestDepositTransactionDto
    {
        [Required]
        public Int64 senderCustomerNo { get; set; }

        [Required]
        public Int64 receiverCustomerNo { get; set; }
        
        [Required]
        public int senderWalletId { get; set; }

        [Required]
        public int receiverWalletId { get; set; }

        [Required]
        public double amount { get; set; }

    }
}
