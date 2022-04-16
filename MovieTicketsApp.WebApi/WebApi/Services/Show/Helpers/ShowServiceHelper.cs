using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieTicketsApp.WebApi.Services.Show.Models;

namespace MovieTicketsApp.WebApi.Services.Show.Helpers;

public static class ShowServiceHelper
{
    public static IQueryable<Entities.Show> IncludeRelated(this DbSet<Entities.Show> shows)
    {
        return shows.Include(show => show.Movie)
                    .ThenInclude(movie => movie.Genre)
                    .Include(show => show.TheaterRoom)
                    .ThenInclude(room => room.Theater);
    }

    public static ShowResource AdaptToResource(this Entities.Show show)
    {
        var showResource = show.Adapt<ShowResource>();
        showResource.Theater = show.TheaterRoom.Theater.Adapt<ShowTheaterResource>();
        return showResource;
    }
}