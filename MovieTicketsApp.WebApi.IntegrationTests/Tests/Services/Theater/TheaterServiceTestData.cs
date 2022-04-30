using TheaterEntities = MovieTicketsApp.WebApi.Services.Theater.Entities;

namespace MovieTicketsApp.WebApi.IntegrationTests.Tests.Services.Theater;

public static class TheaterServiceTestData
{
    public static List<TheaterEntities.Theater> Theaters { get; } = new List<TheaterEntities.Theater>
    {
        new TheaterEntities.Theater { Name = "Theater1"},
        new TheaterEntities.Theater { Name = "Theater2"},
        new TheaterEntities.Theater { Name = "Theater3"},
    };

    public static List<TheaterEntities.TheaterRoom> TheaterRooms { get; } = new List<TheaterEntities.TheaterRoom>
    {
        new TheaterEntities.TheaterRoom { Name = "Room 1", TheaterId = 1 },
        new TheaterEntities.TheaterRoom { Name = "Room 2", TheaterId = 1, Description = "3D" },
        new TheaterEntities.TheaterRoom { Name = "Room 3", TheaterId = 1, Description = "Imax" },
        new TheaterEntities.TheaterRoom { Name = "Room 1", TheaterId = 2 },
        new TheaterEntities.TheaterRoom { Name = "Room 2", TheaterId = 2, Description = "3D" },
        new TheaterEntities.TheaterRoom { Name = "Room 3", TheaterId = 2, Description = "Imax" },
        new TheaterEntities.TheaterRoom { Name = "Room 1", TheaterId = 3 },
        new TheaterEntities.TheaterRoom { Name = "Room 2", TheaterId = 3, Description = "3D" },
        new TheaterEntities.TheaterRoom { Name = "Room 3", TheaterId = 3, Description = "Imax" },
    };
}
