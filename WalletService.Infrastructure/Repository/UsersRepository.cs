using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletService.Domain.AggregateModels.Users;
using WalletService.Domain.Repository;
using WalletService.Infrastructure.EntityFrameworkCore;

namespace WalletService.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {

        public Users CreateUser(Users user)
        {
            using (var userDbContext = new WalletServiceDbContext())
            {
                userDbContext.User.Add(user);
                userDbContext.SaveChanges();

                return user;
            }
        }

        public void DeleteUser(int id)
        {
            using (var userDbContext = new WalletServiceDbContext())
            {
                var deleteUser = GetUsersById(id);
                userDbContext.User.Remove(deleteUser);
                userDbContext.SaveChanges();
            }
        }

        public List<Users> GetAllUsers()
        {
            using (var userDbContext = new WalletServiceDbContext())

                return userDbContext.User.ToList();
        }

        public Users GetUsersById(int id)
        {
            using (var userDbContext = new WalletServiceDbContext())

                return userDbContext.User.Find(id);
        }

        public Task<int> SaveChangesAsync()
        {
            return Task.FromResult(1);
        }

        public Users UpdateUser(Users user)
        {
            using (var userDbContext = new WalletServiceDbContext())
            {
                userDbContext.User.Update(user);
                userDbContext.SaveChanges();
                return user;
            }
        }
    }
}
