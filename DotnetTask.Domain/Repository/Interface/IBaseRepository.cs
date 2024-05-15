using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Domain.Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<HttpStatusCode> InsertRecordAsync(T item, string container);
        Task<ItemResponse<T>> GetRecordByIdAsync<T>(string id, string containerId);
        Task<HttpStatusCode> UpdateRecordAsync(T item, string containerId, string id);


    }
}
