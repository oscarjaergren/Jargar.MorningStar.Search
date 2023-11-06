using Jargar.MorningStar.Search.Api.Person.Model;
using Jargar.MorningStar.Search.Api.Person.Search;
using Microsoft.AspNetCore.Mvc;

namespace Jargar.MorningStar.Search.Api.Person;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IPersonSearch _personSearch;

    public PersonController(ILogger<PersonController> logger, IPersonSearch personSearch)
    {
        _logger = logger;
        _personSearch = personSearch;
    }

    [HttpGet("api/get", Name = "GetPersons")]
    public IEnumerable<PersonModel> Get()
    {
        _logger.LogInformation("Getting Persons");

        return Enumerable.Range(1, 5).Select(index => new PersonModel
        {
            Id = index,
            FirstName = "Oscar",
            LastName = "Jargren",
            Gender = "M",
            Email = "oscar@noreply.com",
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

        return _personSearch.SearchPersons(term);
    }
}
