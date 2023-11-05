using System.Text.Json;
using System.Text.Json.Serialization;

namespace Jargar.MorningStar.Search.Api.Person.Model;

public record PersonModel
{
    public required int Id { get; init; }

    [JsonPropertyName("first_name")]
    public required string FirstName { get; init; }

    [JsonPropertyName("last_name")]
    public required string LastName { get; init; }

    public required string Email { get; init; }

    public required string Gender { get; init; }
}