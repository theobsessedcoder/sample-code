using System;
using System.Net.Http;
using Users.Client.Dtos;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Users.Client
{
    public interface IUserServiceClient
    {
        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="id">The id of the user to get</param>
        Task<UserDto> GetUserAsync(Guid id);

        /// <summary>
        /// Adds or updates the given user
        /// </summary>
        Task AddOrUpdateUserAsync(UserDto user);

        /// <summary>
        /// Deletes the specified user
        /// </summary>
        /// <param name="id">The id of the user to delete</param>
        Task DeleteUserAsync(Guid id);
    }
}
