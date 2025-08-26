namespace Greenlink.HeroicCharacter.Api.Data;

public interface ISpeciesRepository
{
    IList<string> GetAll();
}

public class SpeciesRepository : ISpeciesRepository
{
    public IList<string> GetAll()
    {
        return new List<string>
        {
            // Aasimar
            "Aasimar",

            // Dragonborn (ancestries could be handled separately if desired)
            "Dragonborn",

            // Dwarves
            "Hill Dwarf",
            "Mountain Dwarf",

            // Elves
            "Drow Elf",
            "High Elf",
            "Wood Elf",

            // Gnomes
            "Forest Gnome",
            "Rock Gnome",

            // Goliath (Giant Ancestry as variants)
            "Cloud Goliath",
            "Fire Goliath",
            "Frost Goliath",
            "Hill Goliath",
            "Stone Goliath",
            "Storm Goliath",

            // Halflings
            "Lightfoot Halfling",
            "Stout Halfling",

            // Humans
            "Human",

            // Orcs
            "Orc",

            // Tieflings (Legacies)
            "Infernal Tiefling",
            "Abyssal Tiefling",
            "Chthonic Tiefling"
        };
    }
}
