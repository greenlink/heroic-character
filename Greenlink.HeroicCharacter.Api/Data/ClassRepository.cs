namespace Greenlink.HeroicCharacter.Api.Data;

public interface IClassRepository
{
    IList<string> GetAll();
}

public class ClassRepository : IClassRepository
{
    public IList<string> GetAll()
    {
        return new List<string>
        {
            "Barbarian",
            "Bard",
            "Cleric",
            "Druid",
            "Fighter",
            "Monk",
            "Paladin",
            "Ranger",
            "Rogue",
            "Sorcerer",
            "Warlock",
            "Wizard"
        };
    }
}
