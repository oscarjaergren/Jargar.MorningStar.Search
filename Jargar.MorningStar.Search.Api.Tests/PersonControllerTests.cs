using FluentAssertions;
using Jargar.MorningStar.Search.Api.Person.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Text.Json;

namespace Jargar.MorningStar.Search.Api.Tests;

public static class TestFixture
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config => { });
            builder.ConfigureTestServices(services => { });
        }
    }

    public class PersonControllerTests : IClassFixture<ApiWebApplicationFactory>
    {
        private readonly ApiWebApplicationFactory _fixture;

        public PersonControllerTests(ApiWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Get_Person_Returns_OK()
        {
            var response = await _fixture.CreateClient().GetAsync("/person/api/get");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("James")]
        public async Task Search_Person_Returns_Results_For_James(string searchTerm)
        {
            var expectedResults = new[]
            {
                new PersonModel { Id = 8, FirstName = "James", LastName = "Kubu", Email = "hkubu7@craigslist.org", Gender = "Male" },
                new PersonModel { Id = 11, FirstName = "James", LastName = "Pfeffer", Email = "bpfeffera@amazon.com", Gender = "Male" }
            };

            await RunTestAndAssertResults(searchTerm, expectedResults);
        }

        [Theory]
        [InlineData("jam")]
        public async Task Search_Person_Returns_Results_For_Jam(string searchTerm)
        {
            var expectedResults = new[]
            {
                new PersonModel { Id = 8, FirstName = "James", LastName = "Kubu", Email = "hkubu7@craigslist.org", Gender = "Male" },
                new PersonModel { Id = 11, FirstName = "James", LastName = "Pfeffer", Email = "bpfeffera@amazon.com", Gender = "Male" },
                new PersonModel { Id = 14, FirstName = "Chalmers", LastName = "Longfut", Email = "clongfujam@wp.com", Gender = "Male" }
            };

            await RunTestAndAssertResults(searchTerm, expectedResults);
        }

        [Theory]
        [InlineData("Katey Soltan")]
        public async Task Search_Person_Returns_Results_For_Katey_Soltan(string searchTerm)
        {
            var expectedResults = new[]
            {
                new PersonModel { Id = 18, FirstName = "Katey", LastName = "Soltan", Email = "ksoltanh@simplemachines.org", Gender = "Female" }
            };

            await RunTestAndAssertResults(searchTerm, expectedResults);
        }

        [Theory]
        [InlineData("Jasmine Duncan")]
        [InlineData("")]
        public async Task Search_Person_Returns_No_Results(string searchTerm)
        {
            var expectedResults = Array.Empty<PersonModel>();

            await RunTestAndAssertResults(searchTerm, expectedResults);
        }

        private async Task RunTestAndAssertResults(string searchTerm, PersonModel[] expectedResults)
        {
            // Arrange
            var client = _fixture.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"/person/api/search?term={searchTerm}");

            // Act
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var actualResults = JsonSerializer.Deserialize<PersonModel[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            actualResults.Should().NotBeNull();
            actualResults.Should().BeEquivalentTo(expectedResults);
        }
    }
}