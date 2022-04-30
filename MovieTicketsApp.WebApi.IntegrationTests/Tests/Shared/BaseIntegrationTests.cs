using MovieTicketsApp.WebApi.Shared.Database;
using Xunit;

namespace MovieTicketsApp.WebApi.IntegrationTests.Tests.Shared;

public class BaseIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    protected static readonly string BaseUrl = "/api";
    
    protected CustomWebApplicationFactory<Program> _factory;
    protected HttpClient _client;
    protected DatabaseContext _database;

    public BaseIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }
}