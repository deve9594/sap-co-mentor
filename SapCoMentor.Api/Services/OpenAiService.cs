using OpenAI.Responses;

namespace SapCoMentor.Api.Services;

#pragma warning disable OPENAI001


public class OpenAiService
{
    private readonly ResponsesClient _client;
    private readonly string _model;

    public OpenAiService(IConfiguration configuration)
    {
        var apiKey = configuration["OpenAI:ApiKey"]
            ?? throw new InvalidOperationException(
                "OpenAI API key is not configured.");

        _model = configuration["OpenAI:Model"] ?? "gpt-5-mini";

        _client = new ResponsesClient(apiKey);
    }

    public async Task<string> AskAsync(string question)
    {
        var instructions = """
            You are an SAP Controlling (CO) learning mentor.

            The learner already understands SAP FI.

            Your job is to teach SAP CO by connecting every new CO
            concept to concepts the learner already understands from FI.

            For every question:

            1. Explain the concept in simple language.
            2. Connect it to SAP FI.
            3. Give a real-world business example.
            4. Give an SAP example.
            5. Explain why the concept matters.
            6. Give a scenario-based quiz question.

            Avoid unnecessary SAP jargon.
            Do not assume advanced CO knowledge.

            If something depends on SAP configuration or SAP version,
            clearly mention that.
            """;

        var prompt = $"""
            {instructions}

            Learner's question:
            {question}
            """;

        var response = await _client.CreateResponseAsync(
            _model,
            prompt);

        return response.Value.GetOutputText();
    }
}