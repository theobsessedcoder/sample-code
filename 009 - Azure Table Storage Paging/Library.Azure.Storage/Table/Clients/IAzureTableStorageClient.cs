using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Library.Azure.Storage.Table.Models;
using Microsoft.WindowsAzure.Storage.Table;

namespace Library.Azure.Storage.Table.Clients
{
    public interface IAzureTableStorageClient
    {
        /// <summary>
        /// Gets a table segment at the given partition
        /// </summary>
        /// <typeparam name="T">The type of table entity</typeparam>
        /// <param name="tableName">The name of the table</param>
        /// <param name="partitionKey">The entity's partition key</param>
        /// <param name="pageSize">The number of results to include in the query segment</param>
        /// <param name="continuationToken">The continuation token indicating the beginning of the segment</param>
        Task<QueryResultsSegment<T>> GetSegmentedTableEntitiesByPartitionAsync<T>(
            string partitionKey,
            int pageSize,
            string tableName,
            TableContinuationToken continuationToken = null) where T : TableEntity, new();
    }
}
