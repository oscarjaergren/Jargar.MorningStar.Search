using Jargar.MorningStar.Search.Api.Person.Model;
using Jargar.MorningStar.Search.Api.Person.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Jargar.MorningStar.Search.Api.Person;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IPersonSettings _personSettings;

    public PersonController(ILogger<PersonController> logger, IOptions<PersonSettings> personSettings)
    {
        _logger = logger;
        _personSettings = personSettings.Value;
    }

    [HttpGet("api/get", Name = "GetPersons")]
    public IEnumerable<PersonModel> Get()
    {
        _logger.LogInformation("Getting Persons");

        return Enumerable.Range(1, 5).Select(index => new PersonModel
        {
            Id = index,
            FirstName = "",
            LastName = "",
            Gender = "M",
            Email = "",
        })
        .ToArray();
    }

    [HttpGet("api/search", Name = "SearchPersons")]
    public IEnumerable<PersonModel> Search([FromQuery] string? term)
    {
        if (string.IsNullOrWhiteSpace(term))
        {
            return Enumerable.Empty<PersonModel>();
        }

        return SearchPersons(term);
    }

    private IEnumerable<PersonModel> SearchPersons(string searchTerm)
    {
        var persons = _personSettings.Persons;

        searchTerm = searchTerm.Trim().ToLower();
        return persons.Where(person =>
            person.FirstName.ToLower().Contains(searchTerm) ||
            person.LastName.ToLower().Contains(searchTerm)
        );
    }
}
