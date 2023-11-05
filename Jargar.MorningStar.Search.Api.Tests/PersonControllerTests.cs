using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Text.Json;

namespace Jargar.MorningStar.Search.Api.Tests;

public static class PersonControllerTests
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config => { });
            builder.ConfigureTestServices(services => { });
        }
    }

    public class WeatherForecastControllerTests : IClassFixture<ApiWebApplicationFactory>
    {
        private readonly ApiWebApplicationFactory _fixture;

        public WeatherForecastControllerTests(ApiWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Get_Person_Returns_OK()
        {
            var response =  await _fixture.CreateClient().GetAsync("/person/api/get");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("James", new[] { "James Kubu", "James Pfieffer" })]
        [InlineData("jam", new[] { "James Kubu", "James Pfieffer", "Chalmers Longfut" })]
        [InlineData("Katey Soltan", new[] { "Katey Soltan" })]
        [InlineData("Jasmine Duncan", new string[0])]
        [InlineData("", new string[0])]
        public async Task Search_Person_Returns_Expected_Results(string searchTerm, string[] expectedResults)
        {
            var response = await _fixture.CreateClient().GetAsync($"/person/api/search??term={Uri.EscapeDataString(searchTerm)}");


            response.Should().BeEquivalentTo(expectedResults);
        }
    }
}