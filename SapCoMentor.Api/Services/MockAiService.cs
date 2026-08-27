using SapCoMentor.Api.Models;

namespace SapCoMentor.Api.Services;

public class MockAiService : IAiService
{
    public Task<CoMentorResponse> AskAsync(string question)
    {
        var sample = new CoMentorResponse
        {
            Topic = question.Contains("Cost Center", StringComparison.OrdinalIgnoreCase) ? "Cost Center" : "General Topic",
            SimpleExplanation = "A cost center is an organizational unit used to collect and track costs.",
            FiConnection = "In FI you see financial postings; in CO you assign those costs to organizational units so you can analyze where costs occurred.",
            RealWorldExample = "Electricity cost for IT department is posted in FI; in CO it is assigned to the IT cost center to track departmental spending.",
            SapExample = "In SAP, you post an expense to expense account X and assign Cost Center: IT (e.g., 1000).",
            WhyItMatters = "Cost centers let management see which departments incur costs and control budgets.",
            QuizQuestion = "A company buys office supplies for ₹10,000. Which CO object would you use to track the department responsible for this cost?"
        };

        return Task.FromResult(sample);
    }
}
