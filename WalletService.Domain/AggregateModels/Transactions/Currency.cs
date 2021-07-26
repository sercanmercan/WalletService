using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalletService.Domain.SeedWork;

namespace WalletService.Domain.AggregateModels.Transactions
{
    public class Currency : ValueObject
    {
        [Key]
        public string name { get; set; }
        public double exchangeRate { get; set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {            
            yield return name;
            yield return exchangeRate;           
        }

        public Currency(string name, double exchangeRate)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.exchangeRate = exchangeRate;
        }
    }
}
