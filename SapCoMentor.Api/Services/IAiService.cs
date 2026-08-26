using SapCoMentor.Api.Models;

namespace SapCoMentor.Api.Services;

public interface IAiService
{
    Task<CoMentorResponse> AskAsync(string question);
}