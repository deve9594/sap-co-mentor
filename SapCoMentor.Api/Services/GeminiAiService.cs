using Google.GenAI;
using System.Text.Json;
using SapCoMentor.Api.Models;

namespace SapCoMentor.Api.Services;

public class GeminiAiService : IAiService
{
    private readonly Client _client;
    private readonly string _model;

    public GeminiAiService(IConfiguration configuration)
    {
        var apiKey = configuration["Gemini:ApiKey"]
            ?? throw new InvalidOperationException(
                "Gemini API key is not configured.");

        _model = configuration["Gemini:Model"]
            ?? "gemini-3.1-flash-lite";

        _client = new Client(apiKey: apiKey);
    }

    public async Task<CoMentorResponse> AskAsync(string question)
    {
        var prompt = $$"""
            You are an SAP Controlling (CO) learning mentor.

            The learner already understands SAP FI.

            Teach SAP CO by connecting new CO concepts
            to concepts the learner already understands from FI.

            The learner's question is:

            {{question}}

            Return ONLY valid JSON.

            The JSON must have exactly these properties:

            {
            "topic": "string",
            "simpleExplanation": "string",
            "fiConnection": "string",
            "realWorldExample": "string",
            "sapExample": "string",
            "whyItMatters": "string",
            "quizQuestion": "string"
            }

            Rules:

            - Explain the concept in simple language.
            - Connect it to SAP FI.
            - Give a realistic business example.
            - Give a relevant SAP example.
            - Explain why the concept matters.
            - Finish with a scenario-based quiz question.
            - Avoid unnecessary SAP jargon.
            - Do not assume advanced CO knowledge.
            - If something depends on SAP configuration or SAP version,
            clearly mention that.
            """;

        var response = await _client.Models.GenerateContentAsync(
            model: _model,
            contents: prompt);

        var json = response.Text;

        if (string.IsNullOrWhiteSpace(json))
        {
            throw new InvalidOperationException(
                "Gemini returned an empty response.");
        }

        return JsonSerializer.Deserialize<CoMentorResponse>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })
            ?? throw new InvalidOperationException(
                "Unable to parse Gemini response.");
    }
}