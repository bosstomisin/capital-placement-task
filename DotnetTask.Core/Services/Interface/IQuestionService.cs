using DotnetTask.Core.Dto.Request;
using DotnetTask.Core.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Core.Services.Interface
{
    public interface IQuestionService
    {
        Task<BaseResponse> InsertQuestionAsync(AddQuestionDto item);

    }
}
