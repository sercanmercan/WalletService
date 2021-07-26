using System;
using System.Collections.Generic;
using System.Text;
using WalletService.Domain.AggregateModels.Users;
using WalletService.Domain.SeedWork;

namespace WalletService.Domain.Repository
{
    public interface IUsersRepository : IRepository
    {
        List<Users> GetAllUsers();

        Users GetUsersById(int id);

        Users CreateUser(Users user);

        Users UpdateUser(Users user);

        void DeleteUser(int id);
    }
}
