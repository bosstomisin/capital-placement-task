using DotnetTask.Core.Dto.Request;
using DotnetTask.Core.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _service;
        public CandidateController(ICandidateService service)
        {
            _service = service;
        }
        [HttpPost("add-candidate")]
        public async Task<IActionResult> AddCandidate(AddCandidateDto request)
        {
            return Ok(await _service.InsertCandidatesync(request));
        }
    }
}
