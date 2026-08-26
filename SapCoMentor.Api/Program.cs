using SapCoMentor.Api.Services;
using SapCoMentor.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAiService, GeminiAiService>();
// Application services
builder.Services.AddScoped<CoMentorService>();

//AI services
builder.Services.AddScoped<OpenAiService>();
builder.Services.AddScoped<GeminiAiService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("Angular", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Angular");

// CO Mentor API
app.MapPost("/api/co-mentor/ask", async (AskQuestionRequest request, CoMentorService service) =>
{
    if (string.IsNullOrWhiteSpace(request.Question))
    {
        return Results.BadRequest("Question is required.");
    }

    var response = await service.AskAsync(request.Question);

    return Results.Ok(response);
})
.WithName("AskCoMentor")
.WithOpenApi();

app.MapGet("/api/co-mentor/test-ai", async (OpenAiService aiService) =>
{
    var response = await aiService.AskAsync(
        "What is a Cost Center?");

    return Results.Ok(new
    {
        response
    });
})
.WithName("TestAi")
.WithOpenApi();

app.MapGet("/api/co-mentor/test-gemini", async (GeminiAiService aiService) =>
{
    var response = await aiService.AskAsync(
        "What is a Cost Center?");

    return Results.Ok(new
    {
        response
    });
})
.WithName("TestGemini")
.WithOpenApi();

app.MapPost("/api/co-mentor/learn",
    async (
        LearnTopicRequest request,
        CoMentorService service) =>
    {
        if (string.IsNullOrWhiteSpace(request.Topic))
        {
            return Results.BadRequest("Topic is required.");
        }

        var response = await service.AskAsync(
            $"Teach me the SAP CO topic: {request.Topic}");

        return Results.Ok(response);
    })
.WithName("LearnTopic")
.WithOpenApi();

app.Run();