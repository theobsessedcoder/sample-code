using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage.Table;

namespace Library.Internal.Infrastructure.TableStorage.Entities
{
    public class UserTableEntity : TableEntity
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserTableEntity()
        {
            //Parameterless constructur needed by Azure Table Storage
        }

        public UserTableEntity(
            Guid id,
            string firstName,
            string lastName)
        {
            //For this example, all users are stored in a single partition:
            PartitionKey = GetPartitionKey();
            RowKey = GetRowKey(id);
            Id = id.ToString("N");
            FirstName = firstName;
            LastName = lastName;
        }

        public static string GetPartitionKey()
        {
            return "StaticPartitionKey";
        }

        public static string GetRowKey(Guid id)
        {
            return id.ToString("N");
        }
    }
}
