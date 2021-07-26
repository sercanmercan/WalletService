using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using WalletService.Domain.AggregateModels.Transactions;

namespace WalletService.Domain.Events
{
    public class TransactionDomainEvent : INotification
    {
        public string  userFirstName { get; set; }
        public string userLastName { get; set; }
        [NotNull]
        [StringLength(11)]
        public string userTcNo { get; set; }

        [NotNull]
        [StringLength(16)]
        public string userCustomerNo { get; set; }

        [NotNull]
        public string userEmail { get; set; }

        [NotNull]
        public string userPassword { get; set; }
        public int userId { get; set; }

        public AggregateModels.Transactions.WalletTransaction transaction { get; set; }

        //public TransactionDomainEvent(int userId, Transaction transaction)
        //{
        //    this.userId = userId;
        //    this.transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
        //}

        public TransactionDomainEvent(string userFirstName, string userLastName, string userTcNo, string userCustomerNo, string userEmail, string userPassword, WalletTransaction transaction)
        {

            this.userFirstName = userFirstName ?? throw new ArgumentNullException(nameof(userFirstName));
            this.userLastName = userLastName ?? throw new ArgumentNullException(nameof(userLastName));
            this.userTcNo = userTcNo ?? throw new ArgumentNullException(nameof(userTcNo));
            this.userCustomerNo = userCustomerNo ?? throw new ArgumentNullException(nameof(userCustomerNo));
            this.userEmail = userEmail ?? throw new ArgumentNullException(nameof(userEmail));
            this.userPassword = userPassword ?? throw new ArgumentNullException(nameof(userPassword));
            this.transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
        }


    }
}
