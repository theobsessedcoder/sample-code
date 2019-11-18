using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage.Table;

namespace Library.Azure.Storage.Table.Models
{
    /// <summary>
    /// A segment of azure table storage query results
    /// </summary>
    /// <typeparam name="T">The type of table entities included in the results</typeparam>
    public class QueryResultsSegment<T> where T : new()
    {
        /// <summary>
        /// The table entity results
        /// </summary>
        public IEnumerable<T> Results { get; set; }

        /// <summary>
        /// The continuation token to query the next segment of results
        /// </summary>
        public TableContinuationToken ContinuationToken { get; set; }
    }
}
