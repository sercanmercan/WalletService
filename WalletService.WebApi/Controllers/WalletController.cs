using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletService.Application.InterfaceService;
using WalletService.Domain.AggregateModels.Wallet;

namespace WalletService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {

        private IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }


        #region Wallet
        /// <summary>
        /// Get Wallet By WalletId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Wallet GetWallet(int id) // search wallet by id
      {
            return _walletService.GetWalletById(id);
        }

        /// <summary>
        /// Create Wallet
        /// </summary>
        /// <param name="wallet"></param>
        /// <returns></returns>
        [HttpPost]
        public Wallet CreateWallet([FromBody]Wallet wallet)
        {
            return _walletService.CreateWallet(wallet);
        }

        /// <summary>
        /// Update Wallet
        /// </summary>
        /// <param name="wallet"></param>
        /// <returns></returns>
        [HttpPut]
        public Wallet UpdateWallet([FromBody]Wallet wallet)
        {
            return _walletService.UpdateWallet(wallet);
        }

        /// <summary>
        /// Delete Wallet By WalletId
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void DeleteWallet(int id) // delete wallet by id
        {
            _walletService.DeleteWallet(id);
        }

        /// <summary>
        /// Get Balance By WalletId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("balance/{id}")]
        public double GetBalance(int id)
        
        {
           return _walletService.GetBalance(id);
        }

        #endregion
    }
}
