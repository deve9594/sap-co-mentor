using Microsoft.AspNetCore.Mvc;
using SapCoMentor.Api.Models;
using SapCoMentor.Api.Services;

namespace SapCoMentor.Api.Controllers;

[ApiController]
[Route("api/co-mentor")]
public class CoMentorController : ControllerBase
{
    private readonly CoMentorService _service;

    public CoMentorController(CoMentorService service)
    {
        _service = service;
    }

    [HttpPost("ask")]
    public async Task<ActionResult<CoMentorResponse>> Ask(
        [FromBody] AskQuestionRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Question))
        {
            return BadRequest("Question is required.");
        }

        var response = await _service.AskAsync(request.Question);

        return Ok(response);
    }
}