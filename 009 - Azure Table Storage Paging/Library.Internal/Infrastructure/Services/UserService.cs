using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Azure.Storage.Services;
using Library.Azure.Storage.Table.Clients;
using Library.Internal.Domain.Users.Models;
using Library.Internal.Infrastructure.TableStorage.Entities;

namespace Library.Internal.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private const string UsersTableName = "users";
        private readonly IAzureTableStorageClient _azureTableStorageClient;

        public UserService(IAzureTableStorageClient azureTableStorageClient)
        {
            _azureTableStorageClient = azureTableStorageClient;
        }

        public async Task<UsersPage> GetUsersAsync(int pageSize, string pagingToken)
        {
            //Deserialize the provided paging token into a TableContinuationToken:
            var tableContinuationToken = TableContinuationTokenSerializer.Deserialize(pagingToken);

            var pageOfUsers = await _azureTableStorageClient.GetSegmentedTableEntitiesByPartitionAsync<UserTableEntity>(
                UserTableEntity.GetPartitionKey(),
                pageSize,
                UsersTableName,
                tableContinuationToken).ConfigureAwait(false);

            return new UsersPage()
            {
                Users = pageOfUsers.Results.Select(u => ConvertFromTableEntity(u)).ToArray(),
                //Serialize the next TableContinuationToken into an opaque string:
                PagingToken = TableContinuationTokenSerializer.Serialize(pageOfUsers.ContinuationToken)
            };
        }

        private static User ConvertFromTableEntity(UserTableEntity userTableEntity)
        {
            return new User(
                Guid.Parse(userTableEntity.Id),
                userTableEntity.FirstName,
                userTableEntity.LastName);
        }
    }
}
