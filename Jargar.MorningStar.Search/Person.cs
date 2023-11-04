namespace Jargar.MorningStar.Search;

public record Person
{
    public required int Id { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string Email { get; init; }

    public required string Gender { get; init; }
}