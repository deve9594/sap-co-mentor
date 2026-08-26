namespace SapCoMentor.Api.Models;

public class CoMentorResponse
{
    public string Topic { get; set; } = string.Empty;

    public string SimpleExplanation { get; set; } = string.Empty;

    public string FiConnection { get; set; } = string.Empty;

    public string RealWorldExample { get; set; } = string.Empty;

    public string SapExample { get; set; } = string.Empty;

    public string WhyItMatters { get; set; } = string.Empty;

    public string QuizQuestion { get; set; } = string.Empty;
}