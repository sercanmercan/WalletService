using System;
using System.Collections.Generic;
using System.Text;
using WalletService.Domain.AggregateModels.Transactions;
using WalletService.Domain.SeedWork;

namespace WalletService.Domain.AggregateModels.Wallet
{
    public class Wallet : BaseEntity
    {
        public int usersId { get; set; }
        public double balance { get; set; }
        //public Currency currency { get; private set; }
        public string currency { get; set; }
        public string walletType { get; set; }
        public DateTime createdOn { get; set; }

        //public Wallet(int usersId, double balance, Currency currency)
        //{
        //    if (walletType == "Bank Card" && balance < 0)
        //        throw new Exception("Balance can not be less than zero");

        //    this.usersId = usersId;
        //    this.balance = balance;
        //    this.currency = currency ?? throw new ArgumentNullException(nameof(currency));
        //}
        
    }
}
