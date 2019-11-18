using System;
using Users.InternalLibrary.Models;
using System.Collections.Concurrent;
using Users.InternalLibrary.Exceptions;

namespace Users.InternalLibrary.Repositories
{
    /// <summary>
    /// A memory-backed user repository (note: in real life, this repository 
    /// would be backed by some form of persistent storage instead)
    /// </summary>
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly ConcurrentDictionary<Guid, User> _usersById;

        public InMemoryUserRepository()
        {
            _usersById = new ConcurrentDictionary<Guid, User>();
        }

        public User Get(Guid id)
        {
            if(!_usersById.TryGetValue(id, out var user))
            {
                throw new UserNotFoundException($"User {id} could not be found.");
            }

            return user;
        }

        public void AddOrUpdate(User user)
        {
            //Add the user if it doesn't exist, otherwise override the user with the given id value:
            _usersById.AddOrUpdate(user.Id, user, (id, usr) => user);
        }

        public void Delete(Guid userId)
        {
            if(!_usersById.TryRemove(userId, out var deletedUser))
            {
                throw new UserNotFoundException($"User {userId} could not be found.");
            }
        }
    }
}
