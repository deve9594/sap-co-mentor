using SapCoMentor.Api.Models;

namespace SapCoMentor.Api.Services;

public class CoMentorService
{
     private readonly IAiService _aiService;
     public CoMentorService(IAiService aiService)
    {
        _aiService = aiService;
    }
    // public Task<CoMentorResponse> AskAsync(string question)
    // {
    //     var response = new CoMentorResponse
    //     {
    //         Topic = "Cost Center",

    //         SimpleExplanation =
    //             "A cost center is an organizational unit used to collect and monitor costs.",

    //         FiConnection =
    //             "You already understand FI. FI records the financial transaction, while CO helps identify where the cost was incurred and analyze it.",

    //         RealWorldExample =
    //             "Suppose a company pays ₹1,00,000 in electricity expenses. FI records the expense, while CO can assign the cost to the appropriate department such as IT, HR or Production.",

    //         SapExample =
    //             "Electricity Expense → Cost Center: IT",

    //         WhyItMatters =
    //             "Cost centers help the business understand which department or area is responsible for the costs incurred.",

    //         QuizQuestion =
    //             "A company spends ₹50,000 on HR training. Which CO object could be used to track the department responsible for this cost?"
    //     };

    //     return Task.FromResult(response);
    // }

     public async Task<CoMentorResponse> AskAsync(string question)
    {
        return await _aiService.AskAsync(question);
    }
}