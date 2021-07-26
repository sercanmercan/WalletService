using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletService.Application.InterfaceService;
using WalletService.Application.Manager;
using WalletService.Domain.AggregateModels.Users;

namespace WalletService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #region User
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Users> GetUser() 
        {           
            
            return _userService.GetAllUsers();
        }

        /// <summary>
        /// Get User By UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Users GetUser(int id) 
        {
            return _userService.GetUsersById(id);
        }
        
        
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public Users CreateUser([FromBody]Users user)
        {
            return _userService.CreateUser(user);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public Users UpdateUser([FromBody]Users user) 
        {
            return _userService.UpdateUser(user);
        }

        /// <summary>
        /// Delete User By UserId
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void DeleteUser(int id) // delete user by id
        {
            _userService.DeleteUser(id);
        }
        #endregion

        
    }
}