using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletService.Application.InterfaceService;
using WalletService.Domain.AggregateModels.Transactions;
using WalletService.Domain.AggregateModels.Wallet;

namespace WalletService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// Withdraw Transaction
        /// </summary>
        /// <param name="requestWalletTransactionDto"></param>
        /// <returns></returns>
        [HttpPost("withdraw")]

        public Task<WalletTransaction> WithdrawTransaction([FromBody]RequestWithdrawTransactionDto requestWalletTransactionDto)
        {
            return _transactionService.WithdrawTransaction(requestWalletTransactionDto);
        }

        /// <summary>
        /// Get All Transaction By Sender UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task<List<WalletTransaction>> getAllTransaction(int id)
        {
            return _transactionService.getAllTransaction(id);
        }

        /// <summary>
        /// Deposit Transaction
        /// </summary>
        /// <param name="requestDepositTransactionDto"></param>
        /// <returns></returns>
        [HttpPost("deposit")]
        public Task<WalletTransaction> DepositTransaction([FromBody] RequestDepositTransactionDto requestDepositTransactionDto)
        {
            return _transactionService.DepositTransaction(requestDepositTransactionDto);
        }
    }
}