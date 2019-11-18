using System;
using Users.InternalLibrary.Models;
namespace Users.InternalLibrary.Repositories
{
    /// <summary>
    /// Persists users
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the user by id
        /// </summary>
        /// <param name="id">The id of the user</param>
        User Get(Guid id);

        /// <summary>
        /// Adds or updates the given user
        /// </summary>
        void AddOrUpdate(User user);

        /// <summary>
        /// Deletes the specified user
        /// </summary>
        /// <param name="userId">The id of the user to delete</param>
        void Delete(Guid userId);
    }
}
