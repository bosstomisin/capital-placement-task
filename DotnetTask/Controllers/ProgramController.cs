using DotnetTask.Core.Dto;
using DotnetTask.Core.Services.Implementation;
using DotnetTask.Core.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _service;
        public ProgramController(IProgramService service)
        {
            _service = service;
        }
        [HttpPost("add-program")]
        public async Task<IActionResult> InsertProgram(AddProgramDto request)
        {
            var resp = await _service.CreateProgramAsync(request);
            return StatusCode(resp.StatusCode, resp);
        }
    }
}
