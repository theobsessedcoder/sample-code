using System.Threading.Tasks;
using Library.Internal.Domain.Users.Models;
using Library.Internal.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets a page of users
        /// </summary>
        /// <param name="pageSize">The number of results per page</param>
        /// <param name="pagingToken">The token indicating the location of the start of the page</param>
        [HttpGet]
        [Route("")]
        public async Task<UsersPage> GetUsers([FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pagingToken")] string pagingToken)
        {
            return await _userService.GetUsersAsync(pageSize, pagingToken);
        }

    }
}
