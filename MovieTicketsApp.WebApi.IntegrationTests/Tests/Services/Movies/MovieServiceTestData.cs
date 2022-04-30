using MovieTicketsApp.WebApi.IntegrationTests.Tests.Services.Genre;
using MovieEntities = MovieTicketsApp.WebApi.Services.Movie.Entities;

namespace MovieTicketsApp.WebApi.IntegrationTests.Tests.Services.Movies;

public static class MovieServiceTestData
{
    public static List<MovieEntities.Movie> Movies { get; } = new List<MovieEntities.Movie>
    {
        new MovieEntities.Movie { Title = "Scary Movie", Genre = GenreServiceTestsData.Genres.FirstOrDefault(g => g.Id == 1)},
        new MovieEntities.Movie { Title = "Titanic", Genre = GenreServiceTestsData.Genres.FirstOrDefault(g => g.Id == 2)},
        new MovieEntities.Movie { Title = "The Matrix", Genre = GenreServiceTestsData.Genres.FirstOrDefault(g => g.Id == 3)},
    };
}
