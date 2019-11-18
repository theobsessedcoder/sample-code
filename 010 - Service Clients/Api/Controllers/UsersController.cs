using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Public.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="userId">The id of the user</param>
        [HttpGet]
        [Route("users/{userId}")]
        public UserViewModel GetUser(Guid userId)
        {
            //For illustrative purposes:
            return new UserViewModel()
            {
                Id = userId,
                FirstName = "James",
                LastName = "Rapp"
            };
        }
    }
}
