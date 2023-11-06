using Jargar.MorningStar.Search.Api.Person.Model;

namespace Jargar.MorningStar.Search.Api.Person.Search;

public interface IPersonSearch
{
    IEnumerable<PersonModel> SearchPersons(string searchTerm);
}