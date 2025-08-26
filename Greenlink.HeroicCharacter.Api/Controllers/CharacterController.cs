using Greenlink.HeroicCharacter.Api.Models;
using Greenlink.HeroicCharacter.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Greenlink.HeroicCharacter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly IOpenAiCharacterService _openAiCharacterService;

    public CharacterController(IOpenAiCharacterService openAiCharacterService)
    {
        _openAiCharacterService =  openAiCharacterService;
    }
    
    [HttpPost("generate")]
    public async Task<ActionResult<CharacterResult>> GenerateCharacter([FromBody] CharacterRequest request)
    {
        var result = await _openAiCharacterService.GenerateCharacterAsync(request);
        return Ok(result);
    }
}
