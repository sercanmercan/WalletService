using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;
using WalletService.Domain.SeedWork;

namespace WalletService.Domain.AggregateModels.Users
{
    public class Users :BaseEntity
    {
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string surname { get; set; }

        [NotNull]
        public Int64 tcNo { get; set; }

        [NotNull]
        public Int64 customerNo { get; set; }

        [NotNull]
        [StringLength(50)]
        public string email { get; set; }

        [NotNull]
        [StringLength(50)]
        public string password { get; set; }

        public DateTime createdOn { get; set; }

       
    }
}
