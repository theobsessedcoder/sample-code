using System;
using System.Threading.Tasks;
using UserServiceExample.Models;

namespace UserServiceExample.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public async Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
