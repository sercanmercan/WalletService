using System;
using System.Collections.Generic;
using System.Text;
using WalletService.Domain.SeedWork;

namespace WalletService.Domain.AggregateModels.Transactions
{
    public class WalletTransaction : BaseEntity, IAggregateRoot
    {

        public double senderBalance { get;  set; }
        public double amount { get;  set; }
        public string detail { get;  set; }
        public int senderUserId { get;  set; }
        public int receiverUserId { get;  set; }
        public int senderWalletId { get;  set; }
        public int receiverWalletId { get;  set; }
        public Int64 senderCustomerNo { get; set; }
        public Int64 receiverCustomerNo { get; set; }
        public string senderCurrency { get; set; }
        public string receiverCurrency { get; set; }
        public DateTime createdOn { get; set; }

        
    }
}
