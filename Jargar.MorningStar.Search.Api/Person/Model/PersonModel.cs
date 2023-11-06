
using System.Text.Json.Serialization;

namespace Jargar.MorningStar.Search.Api.Person.Model;


public record PersonModel
{
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    [ConfigurationKeyName("first_name")]
    [JsonPropertyName("first_name")]
    public required string FirstName { get; init; }

    [ConfigurationKeyName("last_name")]
    [JsonPropertyName("last_name")]
    public required string LastName { get; init; }

    [JsonPropertyName("email")]
    public required string Email { get; init; }

    [JsonPropertyName("gender")]
    public required string Gender { get; init; }
}

[JsonSerializable(typeof(PersonModel))]
[JsonSerializable(typeof(List<PersonModel>))]

[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(int))]
public partial class PersonModelSourceGenerationContext : JsonSerializerContext
{ }