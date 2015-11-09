using Microsoft.WindowsAzure.Storage;
using System;
using Westerdals.Domain.Contracts;
using Microsoft.WindowsAzure.Storage.Table;

namespace Westerdals.Data.Azure
{
    public class AzureTableConnector : IConnector
    {
        private CloudTable _table;

        public void AddToTable<T>(T entityToAdd)
        {
            var tableEntity = new TableEntity("reading", entityToAdd.ToString());
            var insertOperation = TableOperation.Insert(tableEntity);

            _table.Execute(insertOperation);
        }

        public bool Connect()
        {
            var connectionString    = "";
            var cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient         = cloudStorageAccount.CreateCloudTableClient();

            _table = tableClient.GetTableReference("readings");

           return _table.CreateIfNotExists();
        }
    }
}
