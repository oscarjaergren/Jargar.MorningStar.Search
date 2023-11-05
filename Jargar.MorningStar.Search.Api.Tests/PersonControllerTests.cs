using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Json;
using static System.Net.Mime.MediaTypeNames;

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
            var response =  await _fixture.CreateClient().GetAsync("/Person");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}