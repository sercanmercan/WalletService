using System;
using System.Collections.Generic;
using System.Text;
using WalletService.Domain.AggregateModels.Users;
using WalletService.Domain.AggregateModels.Wallet;

namespace WalletService.Application.InterfaceService
{
    public interface IUserService
    {
        #region Users
        List<Users> GetAllUsers();
        Users GetUsersById(int id);

        Users CreateUser(Users user);

        Users UpdateUser(Users user);

        void DeleteUser(int id);
        #endregion


    }
}
