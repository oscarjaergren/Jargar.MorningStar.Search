using Jargar.MorningStar.Search.Api.Person.Model;
using Jargar.MorningStar.Search.Api.Person.Settings;

namespace Jargar.MorningStar.Search.Api.Person.Search;

public class PersonSearch : IPersonSearch
{
    private readonly PersonSettings _personSettings;

    public PersonSearch(PersonSettings personSettings)
    {
        _personSettings = personSettings;
    }

    public IEnumerable<PersonModel> SearchPersons(string searchTerm)
    {
        var persons = _personSettings.Persons;

        searchTerm = searchTerm.Trim().ToLower();

        return persons.Where(x => (x.FirstName.Trim() + " " + x.LastName.Trim() + " " + x.Email.Trim()).Trim().ToLowerInvariant().Contains(searchTerm));
    }
}