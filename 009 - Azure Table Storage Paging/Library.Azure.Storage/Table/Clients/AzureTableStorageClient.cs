using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Azure.Storage.Table.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace Library.Azure.Storage.Table.Clients
{
    public class AzureTableStorageClient : IAzureTableStorageClient
    {
        private readonly CloudTableClient _tableClient;

        public AzureTableStorageClient(string accountName, string accountKey)
        {
            var storageCredentials = new StorageCredentials(accountName, accountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            _tableClient = storageAccount.CreateCloudTableClient();
        }

        /// <summary>
        /// Gets a table segment at the given partition
        /// </summary>
        /// <typeparam name="T">The type of table entity</typeparam>
        /// <param name="tableName">The name of the table</param>
        /// <param name="partitionKey">The entity's partition key</param>
        /// <param name="pageSize">The number of results to include in the query segment</param>
        /// <param name="continuationToken">The continuation token indicating the beginning of the segment</param>
        public async Task<QueryResultsSegment<T>> GetSegmentedTableEntitiesByPartitionAsync<T>(
            string partitionKey,
            int pageSize,
            string tableName,
            TableContinuationToken continuationToken = null) where T : TableEntity, new()
        {
            var table = await GetOrCreateTableAsync(tableName).ConfigureAwait(false);
            var query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
            query = query.Take(pageSize);

            var result = await table.ExecuteQuerySegmentedAsync(query, continuationToken).ConfigureAwait(false);

            return new QueryResultsSegment<T>()
            {
                Results = result.Results,
                ContinuationToken = result.ContinuationToken
            };
        }

        private async Task<CloudTable> GetOrCreateTableAsync(string tableName)
        {
            var table = _tableClient.GetTableReference(tableName);
            await table.CreateIfNotExistsAsync().ConfigureAwait(false);
            return table;
        }
    }
}
