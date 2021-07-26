using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Text;
using System.Transactions;
using WalletService.Domain.AggregateModels.Transactions;
using WalletService.Domain.AggregateModels.Users;
using WalletService.Domain.AggregateModels.Wallet;

namespace WalletService.Infrastructure.EntityFrameworkCore
{
    public class WalletServiceDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("...");// Write the sql connection in this paranthesis.
            

        }

        public DbSet<Users> User { get; set; }

        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<WalletTransaction> Transactions { get; set; }
    }

}
