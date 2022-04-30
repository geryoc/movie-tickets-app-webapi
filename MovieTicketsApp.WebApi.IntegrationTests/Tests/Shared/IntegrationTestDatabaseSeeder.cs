using MovieTicketsApp.WebApi.IntegrationTests.Tests.Services.Genre;
using MovieTicketsApp.WebApi.IntegrationTests.Tests.Services.Movies;
using MovieTicketsApp.WebApi.IntegrationTests.Tests.Services.Theater;
using MovieTicketsApp.WebApi.Services.Genre.Entities;
using MovieTicketsApp.WebApi.Services.Movie.Entities;
using MovieTicketsApp.WebApi.Services.Theater.Entities;
using MovieTicketsApp.WebApi.Shared.Database;

namespace MovieTicketsApp.WebApi.IntegrationTests.Tests.Shared;

public static class IntegrationTestDatabaseSeeder
{
    public static void SeedDataForIntegrationTests(this DatabaseContext database)
    {
        GenreServiceTestsData.Genres.ForEach(genre => database.Genres.Add(genre));
        database.SaveChanges();

        MovieServiceTestData.Movies.ForEach(movie => database.Movies.Add(movie));
        database.SaveChanges();

        TheaterServiceTestData.Theaters.ForEach(theater => database.Theaters.Add(theater));
        database.SaveChanges();

        TheaterServiceTestData.TheaterRooms.ForEach(room => database.TheaterRooms.Add(room));
        database.SaveChanges();
    }
}
