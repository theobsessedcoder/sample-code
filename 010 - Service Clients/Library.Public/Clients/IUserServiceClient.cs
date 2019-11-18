using System;
using System.Threading.Tasks;
using Library.Public.ViewModels;

namespace Library.Public.Clients
{
    public interface IUserServiceClient
    {
        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="id">The id of the user</param>
        Task<UserViewModel> GetUserAsync(Guid id);
    }
}