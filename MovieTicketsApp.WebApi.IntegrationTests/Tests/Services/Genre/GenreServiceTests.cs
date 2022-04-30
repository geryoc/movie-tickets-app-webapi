using MovieTicketsApp.WebApi.IntegrationTests.Tests.Shared;
using MovieTicketsApp.WebApi.Services.Genre.Models;
using Xunit;

namespace MovieTicketsApp.WebApi.IntegrationTests.Tests.Services.Genre;

public class GenreServiceTests : BaseIntegrationTests
{
    public GenreServiceTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetGenreById1()
    {
        // Arrange
        var expectedGenre = GenreServiceTestsData.Genres.FirstOrDefault(g => g.Id == 1);

        // Act
        var response = await _client.GetAsync($"{BaseUrl}/genre/1");

        // Assert
        await AssertGetGenreByIdResponse(response, expectedGenre);
    }

    [Fact]
    public async Task GetGenreById2()
    {
        // Arrange
        var expectedGenre = GenreServiceTestsData.Genres.FirstOrDefault(g => g.Id == 2);

        // Act
        var response = await _client.GetAsync($"{BaseUrl}/genre/2");

        // Assert
        await AssertGetGenreByIdResponse(response, expectedGenre);
    }

    [Fact]
    public async Task GetGenreById3()
    {
        // Arrange
        var expectedGenre = GenreServiceTestsData.Genres.FirstOrDefault(g => g.Id == 3);

        // Act
        var response = await _client.GetAsync($"{BaseUrl}/genre/3");

        // Assert
        await AssertGetGenreByIdResponse(response, expectedGenre);
    }

    [Fact]
    public async Task GetGenreByIdNotFound()
    {
        // Arrange

        // Act
        var response = await _client.GetAsync($"{BaseUrl}/genre/4");

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetAllGenres()
    {
        // Arrange

        // Act
        var response = await _client.GetAsync($"{BaseUrl}/genre");

        // Assert
        TestHelper.AssertSuccessJsonResponse(response);

        var actualGenres = await response.Deserialize<List<GenreResource>>();

        GenreServiceTestsData.Genres.ForEach(expectedGenre =>
        {
            var actualGenre = actualGenres.FirstOrDefault(g => g.Id == expectedGenre.Id);
            AssertGenre(expectedGenre, actualGenre);
        });
    }

    [Fact]
    public async Task GetAllGenresByName1()
    {
        // Arrange
        var testName = GenreServiceTestsData.Genres.First().Name;
        var expectedGenres = GenreServiceTestsData.Genres.Where(g => g.Name.Equals(testName)).ToList();

        // Act
        var response = await _client.GetAsync($"{BaseUrl}/genre?name={testName}");

        // Assert
        TestHelper.AssertSuccessJsonResponse(response);

        var actualGenres = await response.Deserialize<List<GenreResource>>();

        expectedGenres.ForEach(expectedGenre =>
        {
            var actualGenre = actualGenres.FirstOrDefault(g => g.Id == expectedGenre.Id);
            AssertGenre(expectedGenre, actualGenre);
        });
    }

    [Fact]
    public async Task GetAllGenresByName2()
    {
        // Arrange
        var testName = GenreServiceTestsData.Genres.Last().Name;
        var expectedGenres = GenreServiceTestsData.Genres.Where(g => g.Name.Equals(testName)).ToList();

        // Act
        var response = await _client.GetAsync($"{BaseUrl}/genre?name={testName}");

        // Assert
        TestHelper.AssertSuccessJsonResponse(response);

        var actualGenres = await response.Deserialize<List<GenreResource>>();

        expectedGenres.ForEach(expectedGenre =>
        {
            var actualGenre = actualGenres.FirstOrDefault(g => g.Id == expectedGenre.Id);
            AssertGenre(expectedGenre, actualGenre);
        });
    }

    #region Private Helper Methods

    private void AssertGenre(WebApi.Services.Genre.Entities.Genre expectedGenre, GenreResource actualGenre)
    {
        Assert.NotNull(actualGenre);
        Assert.Equal(expectedGenre.Id, actualGenre.Id);
        Assert.Equal(expectedGenre.Name, actualGenre.Name);
    }

    private async Task AssertGetGenreByIdResponse(HttpResponseMessage response, WebApi.Services.Genre.Entities.Genre expectedGenre)
    {
        TestHelper.AssertSuccessJsonResponse(response);
        GenreResource actualGenre = await response.Deserialize<GenreResource>();
        AssertGenre(expectedGenre, actualGenre);
    }

    #endregion
}
