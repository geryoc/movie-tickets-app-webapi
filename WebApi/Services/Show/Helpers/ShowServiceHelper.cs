using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieTicketsApp.WebApi.Services.Show.Models;

namespace MovieTicketsApp.WebApi.Services.Show.Helpers;

public static class ShowServiceHelper
{
    public static IQueryable<Entities.Show> ShowOrderBy(this IQueryable<Entities.Show> showsQuery, List<ShowOrderByOption> orderByOptions)
    {
        if (orderByOptions != null && orderByOptions.Any())
        {
            IOrderedQueryable<Entities.Show> showOrderedQuery;

            switch (orderByOptions.First())
            {
                case ShowOrderByOption.CreatedDate:
                    showOrderedQuery = showsQuery.OrderBy(show => show.Created);
                    break;
                case ShowOrderByOption.CreatedDateDescending:
                    showOrderedQuery = showsQuery.OrderByDescending(show => show.Created);
                    break;
                case ShowOrderByOption.ShowDate:
                    showOrderedQuery = showsQuery.OrderBy(show => show.ShowDate);
                    break;
                case ShowOrderByOption.ShowDateDescending:
                    showOrderedQuery = showsQuery.OrderByDescending(show => show.ShowDate);
                    break;
                case ShowOrderByOption.TicketPrice:
                    showOrderedQuery = showsQuery.OrderBy(show => show.TicketPrice);
                    break;
                case ShowOrderByOption.TicketPriceDescending:
                    showOrderedQuery = showsQuery.OrderByDescending(show => show.TicketPrice);
                    break;
                default:
                    showOrderedQuery = null;
                    break;
            }

            orderByOptions.Remove(orderByOptions.First());

            foreach (var orderByOption in orderByOptions)
            {
                switch (orderByOption)
                {
                    case ShowOrderByOption.CreatedDate:
                        showOrderedQuery = showOrderedQuery.ThenBy(show => show.Created);
                        break;
                    case ShowOrderByOption.CreatedDateDescending:
                        showOrderedQuery = showOrderedQuery.ThenByDescending(show => show.Created);
                        break;
                    case ShowOrderByOption.ShowDate:
                        showOrderedQuery = showOrderedQuery.ThenBy(show => show.ShowDate);
                        break;
                    case ShowOrderByOption.ShowDateDescending:
                        showOrderedQuery = showOrderedQuery.ThenByDescending(show => show.ShowDate);
                        break;
                    case ShowOrderByOption.TicketPrice:
                        showOrderedQuery = showOrderedQuery.ThenBy(show => show.TicketPrice);
                        break;
                    case ShowOrderByOption.TicketPriceDescending:
                        showOrderedQuery = showOrderedQuery.ThenByDescending(show => show.TicketPrice);
                        break;
                    default:
                        break;
                }
            }

            showsQuery = showOrderedQuery;
        }

        return showsQuery;
    }

    public static IQueryable<Entities.Show> IncludeRelated(this DbSet<Entities.Show> shows)
    {
        return shows.Include(show => show.Movie)
                    .ThenInclude(movie => movie.Genre)
                    .Include(show => show.TheaterRoom)
                    .ThenInclude(room => room.Theater);
    }

    public static ShowResource AdaptShow(this Entities.Show show)
    {
        var showResource = show.Adapt<ShowResource>();
        showResource.Theater = show.TheaterRoom.Theater.Adapt<ShowTheaterResource>();
        return showResource;
    }
}