namespace MovieTicketsApp.WebApi.IntegrationTests.Tests.Services.Genre;

public static class GenreServiceTestsData
{
    public static List<WebApi.Services.Genre.Entities.Genre> Genres { get; } = new List<WebApi.Services.Genre.Entities.Genre>()
    {
        new WebApi.Services.Genre.Entities.Genre { Name = "Comedy" },
        new WebApi.Services.Genre.Entities.Genre { Name = "Drama" },
        new WebApi.Services.Genre.Entities.Genre { Name = "Action" },
    };
}
