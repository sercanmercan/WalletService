using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WalletService.Application.Repository;
using WalletService.Domain.AggregateModels.Transactions;
using WalletService.Domain.AggregateModels.Users;
using WalletService.Domain.AggregateModels.Wallet;
using WalletService.Infrastructure.EntityFrameworkCore;

namespace WalletService.Infrastructure.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task<WalletTransaction> WithdrawTransaction(RequestWithdrawTransactionDto requestWalletTransactionDto) {
            WalletRepository walletRepository = new WalletRepository();
            var walletById =walletRepository.GetWalletById(requestWalletTransactionDto.walletId);
            WalletTransaction transaction = new WalletTransaction();
            if (walletById.balance > requestWalletTransactionDto.amount)
            {
                
                var newBalance = walletById.balance - requestWalletTransactionDto.amount;
                
                //update et
                walletRepository.UpdateWallet(new Wallet {Id = walletById.Id, balance = newBalance , usersId= walletById.usersId, currency = walletById.currency, createdOn = walletById.createdOn, walletType = walletById.walletType});
                
                transaction.createdOn = DateTime.Now;
                transaction.senderUserId = walletById.usersId;
                transaction.senderWalletId = walletById.Id;
                transaction.senderBalance = newBalance;
                transaction.amount = requestWalletTransactionDto.amount;
                transaction.detail = "withdraw";
                transaction.senderCurrency = walletById.currency;

                //create
                Task<WalletTransaction> walletTransactionTask = Task.Run(() => CreateTransaction(transaction));

                return walletTransactionTask;
            }
            else
            {
                throw new Exception("You dont have sufficient balance...");
            }
        }

        public Task<int> SaveChangesAsync()
        {
            return Task.FromResult(1);
        }

        public async Task<WalletTransaction> CreateTransaction(WalletTransaction transaction)
        {
            using (var userDbContext = new WalletServiceDbContext())
            {
                userDbContext.Transactions.Add(transaction);
                userDbContext.SaveChanges();
                
                return await Task.FromResult(transaction); 
            }
        }

        public async Task<List<WalletTransaction>> getAllTransaction(int walletId)
        {
            using (var userDbContext = new WalletServiceDbContext())
            {
                var query = userDbContext.Transactions.Where(s => s.senderWalletId == walletId).ToList();

                return await Task.FromResult(query);
            }                
        }

        public Task<WalletTransaction> DepositTransaction(RequestDepositTransactionDto requestDepositTransactionDto)
        {
            double exchangeRate;
            double calculateSenderBalance = 0.0;
            double calculateReceiverBalance = 0.0;
            WalletTransaction transaction = new WalletTransaction();

            using (var userDbContext = new WalletServiceDbContext())
            {
                var getUserBySender = userDbContext.User.Where(s => s.customerNo == requestDepositTransactionDto.senderCustomerNo).FirstOrDefault();
                var getUserByReceiver = userDbContext.User.Where(s => s.customerNo == requestDepositTransactionDto.receiverCustomerNo).FirstOrDefault();

                var getWalletBySender = userDbContext.Wallets.Where(s => s.Id == requestDepositTransactionDto.senderWalletId).FirstOrDefault();
                var getWalletByReceiver = userDbContext.Wallets.Where(s => s.Id == requestDepositTransactionDto.receiverWalletId).FirstOrDefault();

                if (getWalletBySender.balance > requestDepositTransactionDto.amount)
                {

                    if (getWalletBySender.currency == getWalletByReceiver.currency)
                    {
                        calculateSenderBalance = getWalletBySender.balance - requestDepositTransactionDto.amount;
                        calculateReceiverBalance = getWalletByReceiver.balance + requestDepositTransactionDto.amount;
                    }

                    else
                    {

                        if (requestDepositTransactionDto.senderCustomerNo == requestDepositTransactionDto.receiverCustomerNo && requestDepositTransactionDto.senderWalletId != requestDepositTransactionDto.receiverWalletId)
                        {

                            exchangeRate = Double.Parse(exchangeRateMethod());
                            calculateSenderBalance = getWalletBySender.balance - (requestDepositTransactionDto.amount);

                            if (getWalletBySender.currency == "tl")
                            {
                                calculateReceiverBalance = getWalletByReceiver.balance + (requestDepositTransactionDto.amount / exchangeRate);
                            }

                            else
                            {
                                calculateReceiverBalance = getWalletByReceiver.balance + (requestDepositTransactionDto.amount * exchangeRate);
                            }

                        }
                        else
                        {
                            throw new Exception("You cannot deposit different currencies between different bank accounts");
                        }
                    }

                    //Update transaction sender user
                    updateWallet(requestDepositTransactionDto.senderWalletId, calculateSenderBalance);

                    //Update transaction receiver user
                    updateWallet(requestDepositTransactionDto.receiverWalletId, calculateReceiverBalance);

                    transaction.createdOn = DateTime.Now;
                    transaction.senderUserId = getWalletBySender.usersId;
                    transaction.receiverUserId = getWalletByReceiver.usersId;
                    transaction.senderWalletId = getWalletBySender.Id;
                    transaction.receiverWalletId = getWalletByReceiver.Id;
                    transaction.senderBalance = calculateSenderBalance;
                    transaction.amount = requestDepositTransactionDto.amount;
                    transaction.detail = "deposit";
                    transaction.senderCustomerNo = getUserBySender.customerNo;
                    transaction.senderCurrency = getWalletBySender.currency;
                    transaction.receiverCustomerNo = getUserByReceiver.customerNo;
                    transaction.receiverCurrency = getWalletByReceiver.currency;

                    Task<WalletTransaction> walletTransactionTask = Task.Run(() => CreateTransaction(transaction));

                    return walletTransactionTask;
                }

                else
                {
                    throw new Exception("There is not sufficient balance");
                }
            }
        }

        public void updateWallet( int walletId, double balance)
        {
            WalletRepository walletRepository = new WalletRepository();
            using (var userDbContext = new WalletServiceDbContext())
            {
               
                var walletQuery = userDbContext.Wallets.Where(x => x.Id == walletId).FirstOrDefault();
                walletRepository.UpdateWallet(new Wallet { Id = walletId, balance = balance, usersId = walletQuery.usersId, currency = walletQuery.currency, createdOn = walletQuery.createdOn, walletType = walletQuery.walletType });
            }
        }

        public string exchangeRateMethod()
        {
            HtmlWeb website = new HtmlWeb();
            HtmlDocument document = website.Load("https://uzmanpara.milliyet.com.tr/doviz-kurlari/");
            var datalist = document.DocumentNode.SelectSingleNode("//span[@id='usd_header_son_data']").InnerText.ToString();
            return datalist;

        }
    }
}
