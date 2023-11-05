using Jargar.MorningStar.Search.Api.Person.Model;

namespace Jargar.MorningStar.Search.Api.Person.Settings;

public interface IPersonSettings
{
    List<PersonModel> Persons { get; set; }
}
