using Azure.Core;
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
    public class QuestionService : IQuestionService
    {
        private readonly DbConfig _dbConfig;
        private readonly IQuestionRepo _repo;
        public QuestionService(IOptions<DbConfig> dbConfig, IQuestionRepo repo)
        {
            _dbConfig = dbConfig.Value;
            _repo = repo;
        }
        public async Task<BaseResponse> InsertQuestionAsync(AddQuestionDto item)
        {
            var getProgram = await _repo.GetRecordByIdAsync<ProgramModel>(item.ProgramId, _dbConfig.ContainerConfig.ProgramContainer);

            if (getProgram == null)
                return new BaseResponse { Message = "Program Not Found", StatusCode = (int)HttpStatusCode.NotFound };

            var request = new Questions() { ProgramId = item.ProgramId,
                Question = item.Question,
                QuestionType = item.QuestionType.ToString() 
            };
            var insertResponse = await _repo.InsertRecordAsync(request, _dbConfig.ContainerConfig.QuestionContainer);
            if (insertResponse == HttpStatusCode.Created)
                return new BaseResponse { Message = "Record Successfully Inserted", StatusCode = (int)insertResponse, Data = request };
            return new BaseResponse { Message = "Failed", StatusCode = (int)insertResponse };

        }

 
    
        public async Task<BaseResponse> GetQuestionAsync(string id)
        {
            var getResponse = await _repo.GetRecordByIdAsync<Questions>(id, _dbConfig.ContainerConfig.QuestionContainer);
            if (getResponse == null)
                return new BaseResponse { Message = "Failed", StatusCode = (int)HttpStatusCode.NotFound };
            return new BaseResponse { Message = "Successful!", StatusCode = (int)getResponse.StatusCode, Data = getResponse.Resource };

        }

        public async Task<BaseResponse> UpdateQuestion(string id, UpdateQuestionDto item)
        {
            var getResponse = await _repo.GetRecordByIdAsync<Questions>(id, _dbConfig.ContainerConfig.QuestionContainer);
            if(getResponse == null)
                return new BaseResponse { Message = "Record Not Found", StatusCode = (int)HttpStatusCode.NotFound };

            getResponse.Resource.Question = item.Question;
            getResponse.Resource.QuestionType = item.QuestionType.ToString();

            var updateResp = await _repo.UpdateRecordAsync(getResponse.Resource, _dbConfig.ContainerConfig.QuestionContainer, id);
            if (updateResp == HttpStatusCode.Created)
                return new BaseResponse { Message = "Update Successful", StatusCode = (int)updateResp };
            return new BaseResponse { Message = "Failed", StatusCode = (int)updateResp };

        }
    }
}
