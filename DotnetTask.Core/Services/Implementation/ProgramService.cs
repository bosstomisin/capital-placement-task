using DotnetTask.Core.Dto.Request;
using DotnetTask.Core.Dto.Response;
using DotnetTask.Core.Services.Interface;
using DotnetTask.Domain.Config;
using DotnetTask.Domain.Models;
using DotnetTask.Domain.Repository.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Core.Services.Implementation
{
    public class ProgramService : IProgramService
    {
        private readonly DbConfig _dbConfig;
        private readonly IProgramRepo _repo;
        public ProgramService(IOptions<DbConfig> dbConfig, IProgramRepo repo)
        {
            _dbConfig = dbConfig.Value;
            _repo = repo;
        }
        public async Task<BaseResponse> CreateProgramAsync(AddProgramDto item)
        {
            var request = new ProgramModel() {
                ProgramDescription = item.ProgramDescription,
                ProgramTitle = item.ProgramTitle };
           
            var insertResponse = await _repo.InsertRecordAsync(request, _dbConfig.ContainerConfig.ProgramContainer);
            if (insertResponse == HttpStatusCode.Created)
                return new BaseResponse { Message = "Record Successfully Inserted", StatusCode = (int)insertResponse, Data = request };
            return new BaseResponse { Message = "Failed", StatusCode = (int)insertResponse};

        }

        public async Task<BaseResponse> GetProgramAsync(string id)
        {          
            var getResponse = await _repo.GetRecordByIdAsync<ProgramModel>(id, _dbConfig.ContainerConfig.ProgramContainer);
            if (getResponse  == null)
                return new BaseResponse { Message = "Failed", StatusCode = (int)HttpStatusCode.NotFound};
            return new BaseResponse { Message = "Successful!", StatusCode = (int)getResponse.StatusCode, Data = getResponse.Resource };

        }
    }
}
