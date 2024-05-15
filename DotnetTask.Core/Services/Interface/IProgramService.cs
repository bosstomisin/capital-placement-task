using DotnetTask.Core.Dto;
using DotnetTask.Core.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DotnetTask.Core.Services.Interface
{
    public interface IProgramService
    {
        Task<BaseResponse> CreateProgramAsync(AddProgramDto item);
    }
}
