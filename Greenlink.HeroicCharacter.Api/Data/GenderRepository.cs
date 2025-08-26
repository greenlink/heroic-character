namespace Greenlink.HeroicCharacter.Api.Data;

public interface IGenderRepository
{
    IList<string> GetAll();
}

public class GenderRepository : IGenderRepository
{
    public IList<string> GetAll()
    {
        return new List<string>()
        {
            "Male",
            "Female",
            "Non-Binary",
            "Transgender Male",
            "Transgender Female",
            "Genderfluid",
            "Agender",
            "Other"
        };
    }
}