using Jargar.MorningStar.Search.Api.Person.Model;

namespace Jargar.MorningStar.Search.Api.Person.Settings;

public class PersonSettings : IPersonSettings
{
    public required List<PersonModel> Persons { get; set; }
}
