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
            var request = new Questions() { PragramId = item.PragramId,
                Question = item.Question,
                QuestionType = item.Questiontype.ToString() 
            };
            var insertResponse = await _repo.InsertRecordAsync(request, _dbConfig.ContainerConfig.QuestionContainer);
            if (insertResponse == HttpStatusCode.Created)
                return new BaseResponse { Message = "Record Successfully Inserted", StatusCode = (int)insertResponse, Data = request };
            return new BaseResponse { Message = "Failed", StatusCode = (int)insertResponse };

        }
    }
}
