using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using WalletService.Application.InterfaceService;
using WalletService.Application.Repository;
using WalletService.Domain.AggregateModels.Users;
using WalletService.Domain.AggregateModels.Wallet;
using WalletService.Domain.Repository;
using WalletService.Infrastructure.Repository;

namespace WalletService.Application.Manager
{
    public class UserManager : IUserService
    {
        private IUsersRepository _usersRepository;

        //Dependency Injection
        public UserManager(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        #region Users
        public Users CreateUser(Users user)
        {
            if (user.customerNo != 0 && DigitCount(user.customerNo)==16 && user.tcNo != 0 && DigitCount(user.tcNo) == 11 && user.email != "" && user.password != "")
                return _usersRepository.CreateUser(user);

            else
            {
  
                throw new Exception("You should fill customer no, tc no, email and password");
            }             
        }

        public void DeleteUser(int id)
        {
            if (id > 0)
                _usersRepository.DeleteUser(id);
            else
                throw new Exception("Id must be greater than zero.");

        }

        public List<Users> GetAllUsers()
        {
            return _usersRepository.GetAllUsers();
        }

        public Users GetUsersById(int id)
        {
            if (id > 0)
                return _usersRepository.GetUsersById(id);
            else
                throw new Exception("Id must be greater than zero.");
        }

        public Users UpdateUser(Users user)
        {
            return _usersRepository.UpdateUser(user);
        }

        #endregion

        public int DigitCount(Int64 number)
        {
            int count = 0;
            while (number >= 1)
            {

                number /= 10;
                count++;
            }
            return count;
        }
        
    }
}
