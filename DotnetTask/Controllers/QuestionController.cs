using DotnetTask.Core.Dto.Request;
using DotnetTask.Core.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _service;
        public QuestionController(IQuestionService service)
        {
            _service = service;
        }

        [HttpPost("add-question")]
        public async Task<IActionResult> AddQuestion(AddQuestionDto request)
        {
            var resp = await _service.InsertQuestionAsync(request);
            return StatusCode(resp.StatusCode, resp);

        }

        [HttpPut("update-question")]
        public async Task<IActionResult> UpdateQuestion(string id, UpdateQuestionDto request)
        {
            var resp = await _service.UpdateQuestion(id,request);
            return StatusCode(resp.StatusCode, resp);

        }
        [HttpGet("get-question")]
        public async Task<IActionResult> GetQuestion(string id)
        {
            var resp = await _service.GetQuestionAsync(id);
            return StatusCode(resp.StatusCode, resp);

        }
    }
}
