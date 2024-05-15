using DotnetTask.Core.Dto;
using DotnetTask.Core.Dto.Response;
using DotnetTask.Core.Services.Interface;
using DotnetTask.Domain.Models;
using DotnetTask.Domain.Repository.Interface;
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
        private readonly IProgramRepo _repo;
        public ProgramService(IProgramRepo repo)
        {
            _repo = repo;
        }
        public async Task<BaseResponse> CreateProgramAsync(AddProgramDto item)
        {
            var request = new ProgramModel() {
                ProgramDescription = item.ProgramDescription,
                ProgramTitle = item.ProgramTitle };
           
            var addResponse = await _repo.InsertRecordAsync(request, "Program");
            if (addResponse == HttpStatusCode.OK)
                return new BaseResponse { Message = "Record Successfully Inserted", StatusCode = (int)addResponse };
            return new BaseResponse { Message = "Record Successfully Inserted", StatusCode = (int)addResponse };

        }
    }
}
