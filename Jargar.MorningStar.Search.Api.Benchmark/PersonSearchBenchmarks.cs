namespace Jargar.MorningStar.Search.Api.Benchmark;

using BenchmarkDotNet.Attributes;
using Jargar.MorningStar.Search.Api.Person.Search;
using Jargar.MorningStar.Search.Api.Person.Settings;
using Microsoft.Extensions.Configuration;

[MemoryDiagnoser]
public class PersonSearchBenchmarks
{
    private IPersonSearch _fastSearch = null!;
    private IPersonSearch _regularSearch = null!;

    private readonly string _searchTerm = "John";

    [GlobalSetup]
    public void Setup()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("persons.json", optional: false)
                .Build();
        var personSettings = configuration.GetSection("PersonSettings").Get<PersonSettings>();
        _fastSearch = new PersonSearchFast(personSettings);
        _regularSearch = new PersonSearch(personSettings);
    }

    [Benchmark]
    public void FastSearchBenchmark()
    {
        _fastSearch.SearchPersons(_searchTerm);
    }

    [Benchmark]
    public void RegularSearchBenchmark()
    {
        _regularSearch.SearchPersons(_searchTerm);
    }
}
