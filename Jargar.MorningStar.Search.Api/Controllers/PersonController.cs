using Microsoft.AspNetCore.Mvc;

namespace Jargar.MorningStar.Search.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPersons")]
    public IEnumerable<Person> Get()
    {
        _logger.LogInformation("Getting Persons");

        return Enumerable.Range(1, 5).Select(index => new Person
        {
            Id = index,
            FirstName = "",
            LastName = "",
            Gender = "M",
            Email = "",
        })
        .ToArray();
    }
}