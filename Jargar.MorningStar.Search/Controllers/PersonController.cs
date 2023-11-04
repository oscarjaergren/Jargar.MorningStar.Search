using Microsoft.AspNetCore.Mvc;

namespace Jargar.MorningStar.Search.Controllers;

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