﻿using Jargar.MorningStar.Search.Api.Person.Model;
using Jargar.MorningStar.Search.Api.Person.Settings;

namespace Jargar.MorningStar.Search.Api.Person.Search;

public class PersonSearch : IPersonSearch
{
    private readonly IEnumerable<PersonModel> _personSettings;

    public PersonSearch(IEnumerable<PersonModel> personSettings)
    {
        _personSettings = personSettings;
    }

    public IEnumerable<PersonModel> SearchPersons(string searchTerm)
    {
        var persons = _personSettings;

        searchTerm = searchTerm.Trim().ToLower();

        return persons.Where(x => (x.FirstName.Trim() + " " + x.LastName.Trim() + " " + x.Email.Trim()).Trim().Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase));
    }
}