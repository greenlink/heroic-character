using Greenlink.HeroicCharacter.Api.Models;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Images;

namespace Greenlink.HeroicCharacter.Api.Services;

public interface IOpenAiCharacterService
{
    Task<CharacterResult> GenerateCharacterAsync(CharacterRequest request);
}

public class OpenAiCharacterService : IOpenAiCharacterService
{
    private readonly OpenAIClient _client;

    public OpenAiCharacterService(IConfiguration config)
    {
        // Get your API key from appsettings.json or user secrets
        var apiKey = config["OpenAI:ApiKey"];
        _client = new OpenAIClient(apiKey);
    }
    
    public async Task<CharacterResult> GenerateCharacterAsync(CharacterRequest request)
    {
        // Step 1 - Dungeon Master role (GPT-4.1) → description
            var chat = _client.GetChatClient("gpt-4.1");

            const string systemPrompt = "You are a Dungeon Master for the D&D 2024 Ruleset.";
            var userPrompt = $"""
                              Generate a single paragraph character description for a {request.Gender} {request.Species} {request.ClassName}.
                              The description must include exactly 3 physical characteristics and 3 mental characteristics.
                              """;

            var chatResponse = await chat.CompleteChatAsync(new List<ChatMessage>
            {
                new SystemChatMessage(systemPrompt),
                new UserChatMessage(userPrompt)
            });

            var description = chatResponse.Value.Content[0].Text.Trim();

            // Step 2 - Prompt engineer (GPT-4.1) → DALL-E 3 prompt
            var promptEngineerResponse = await chat.CompleteChatAsync(new List<ChatMessage>
                {
                    new SystemChatMessage("You are an expert prompt engineer for DALL-E 3."),
                    new UserChatMessage(
                        $"Create a concise DALL-E 3 prompt to visually represent this character: {description}")
                }
            );

            var dallEPrompt = promptEngineerResponse.Value.Content[0].Text.Trim();

            // Step 3 - Generate image (DALL-E 3)
            var imageClient = _client.GetImageClient("dall-e-3");
            var imageResult = await imageClient.GenerateImageAsync(dallEPrompt, new ImageGenerationOptions
            {
                Size = GeneratedImageSize.W1024xH1792
            });

            var imageUrl = imageResult.Value.ImageUri.ToString();

            // Step 4 - Return result
            return new CharacterResult
            {
                Description = description,
                ImageUrl = imageUrl
            };
    }
}