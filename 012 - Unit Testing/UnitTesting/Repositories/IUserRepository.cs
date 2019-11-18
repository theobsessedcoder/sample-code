using System;
using System.Threading.Tasks;
using UserServiceExample.Models;

namespace UserServiceExample.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task AddAsync(User user);
        Task DeleteAsync(Guid id);
    }
}
