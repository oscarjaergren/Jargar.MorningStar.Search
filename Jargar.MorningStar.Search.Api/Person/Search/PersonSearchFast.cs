﻿using Jargar.MorningStar.Search.Api.Person.Model;
using Jargar.MorningStar.Search.Api.Person.Settings;

namespace Jargar.MorningStar.Search.Api.Person.Search;

public class PersonSearchFast : IPersonSearch
{
    private readonly IEnumerable<PersonModel> _personSettings;

    public PersonSearchFast(IEnumerable<PersonModel> personSettings)
    {
        _personSettings = personSettings;
    }

    public IEnumerable<PersonModel> SearchPersons(string searchTerm)
    {
        searchTerm = searchTerm.Trim().ToLower();

        foreach (var person in _personSettings)
        {
            var fullName = $"{person.FirstName} {person.LastName} {person.Email}".ToLowerInvariant();
            if (fullName.Contains(searchTerm))
            {
                yield return person;
            }
        }
    }
}