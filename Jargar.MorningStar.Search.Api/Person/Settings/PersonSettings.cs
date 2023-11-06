using Jargar.MorningStar.Search.Api.Person.Model;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Jargar.MorningStar.Search.Api.Person.Settings;

public class PersonSettings : IPersonSettings
{
    public List<PersonModel> Persons { get; set; }

  
}

[JsonSerializable(typeof(PersonSettings))]
[JsonSerializable(typeof(PersonModel))]
[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(int))]
internal partial class PersonSettingsSourceGenerationContext : JsonSerializerContext
{ }
