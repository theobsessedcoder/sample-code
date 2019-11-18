using System;
using System.Threading.Tasks;
using UserServiceExample.Exceptions;
using UserServiceExample.Repositories;

namespace UserServiceExample.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        //Don't do this:
        //public UserService()
        //{
        //    _userRepository = new UserRepository();
        //}

        //Do this:
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> GetUserNameAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId).ConfigureAwait(false);
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                throw new NamelessUserException($"User {userId} has an invalid name.");
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
