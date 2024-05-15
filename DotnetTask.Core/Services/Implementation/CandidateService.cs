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
    public class CandidateService : ICandidateService
    {
        private readonly DbConfig _dbConfig;
        private readonly ICandidateRepo _repo;
        public CandidateService(IOptions<DbConfig> dbConfig, ICandidateRepo repo)
        {
            _dbConfig = dbConfig.Value;
            _repo = repo;
        }
        public async Task<BaseResponse> InsertCandidatesync(AddCandidateDto item)
        {
            var getProgram = await _repo.GetRecordByIdAsync<ProgramModel>(item.ProgramId, _dbConfig.ContainerConfig.ProgramContainer);
            if (getProgram == null)
                return new BaseResponse { Message = "Program Not Found", StatusCode = (int)HttpStatusCode.NotFound };

            var getQuestion = await _repo.GetRecordByIdAsync<Questions>(item.QuestionId, _dbConfig.ContainerConfig.QuestionContainer);
            if (getQuestion == null)
                return new BaseResponse { Message = "Question Not Found", StatusCode = (int)HttpStatusCode.NotFound };
            
            var request = new Candidate() { ProgramId = item.ProgramId, QuestionId = item.QuestionId, Value = item.Value };
            var insertResponse = await _repo.InsertRecordAsync(request, _dbConfig.ContainerConfig.CandidateContainer);
            if (insertResponse == HttpStatusCode.Created)
                return new BaseResponse { Message = "Record Successfully Inserted", StatusCode = (int)insertResponse, Data = request };
            return new BaseResponse { Message = "Failed", StatusCode = (int)insertResponse };

        }
    }
}
