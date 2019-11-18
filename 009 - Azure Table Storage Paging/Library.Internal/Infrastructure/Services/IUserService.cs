using System.Threading.Tasks;
using Library.Internal.Domain.Users.Models;

namespace Library.Internal.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UsersPage> GetUsersAsync(int pageSize, string pagingToken);
    }
}