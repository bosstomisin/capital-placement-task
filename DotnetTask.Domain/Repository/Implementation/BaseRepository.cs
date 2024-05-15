using DotnetTask.Domain.Config;
using DotnetTask.Domain.Repository.Interface;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Domain.Repository.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbConfig _dbConfig;
        private CosmosClient cosmosClient;
        public BaseRepository(IOptions<DbConfig> dbConfig)
        {
            _dbConfig = dbConfig.Value;
            cosmosClient = new CosmosClient(_dbConfig.DbConnection.Endpoint, _dbConfig.DbConnection.AuthKey);
        }

        private async Task<Container> InitializeDatabaseAndContainersAsync(string container)
        {
            Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(_dbConfig.DbConnection.DatabaseId);
            return await database.CreateContainerIfNotExistsAsync(container, "/id");
        }

        public async Task<HttpStatusCode> InsertRecordAsync(T item, string container)
        {
            var containerResp = await InitializeDatabaseAndContainersAsync(container);
            var resp = await containerResp.UpsertItemAsync(item);
            return resp.StatusCode;
        }
    }

}
