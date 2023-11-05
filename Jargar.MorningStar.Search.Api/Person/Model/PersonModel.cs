
using Newtonsoft.Json;

namespace Jargar.MorningStar.Search.Api.Person.Model;

public record PersonModel
{
    public required int Id { get; init; }

    [ConfigurationKeyName("first_name")]
    public required string FirstName { get; init; }

    [ConfigurationKeyName("last_name")]
    public required string LastName { get; init; }

    public required string Email { get; init; }

    public required string Gender { get; init; }
}