using Greenlink.HeroicCharacter.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Greenlink.HeroicCharacter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OptionsController : ControllerBase
{
    private readonly ISpeciesRepository _speciesRepository;
    private readonly IClassRepository _classRepository;
    private readonly IGenderRepository _genderRepository;

    public OptionsController(ISpeciesRepository speciesRepository,
                             IClassRepository classRepository,
                             IGenderRepository genderRepository)
    {
        _speciesRepository = speciesRepository;
        _classRepository = classRepository;
        _genderRepository = genderRepository;
    }

    [HttpGet("species")]
    public IActionResult GetSpecies() => Ok(_speciesRepository.GetAll());

    [HttpGet("classes")]
    public IActionResult GetClasses() => Ok(_classRepository.GetAll());

    [HttpGet("genders")]
    public IActionResult GetGenders() => Ok(_genderRepository.GetAll());
}
