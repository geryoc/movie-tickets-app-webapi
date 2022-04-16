using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTicketsApp.WebApi.Services.Show.Models;
using MovieTicketsApp.WebApi.Shared.Database;
using MovieTicketsApp.WebApi.Shared.Web.Models;
using MovieTicketsApp.WebApi.Services.Show.Helpers;
using MovieTicketsApp.WebApi.Shared.Helpers;
using ShowEntities = MovieTicketsApp.WebApi.Services.Show.Entities;

namespace ShowTicketsApp.WebApi.Services.Show;

[Route("api/[controller]")]
public class ShowController : ControllerBase
{
    private DatabaseContext _database;

    public ShowController(DatabaseContext databaseContext)
    {
        _database = databaseContext;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShowResource>> Get([FromRoute] long id)
    {
        var show = await _database.Shows.IncludeRelated()
                                        .FirstOrDefaultAsync(Show => Show.Id == id);

        if (show == null)
        {
            return NotFound();
        }

        return show.AdaptToResource();
    }

    [HttpGet]
    public async Task<ActionResult<PagedResource<ShowResource>>> Search([FromQuery] SearchShowRequest request)
    {
        var showsQuery = _database.Shows.IncludeRelated()
                                        .Where(show => string.IsNullOrEmpty(request.Description) || show.Description == request.Description)
                                        .Where(show => !request.MaxShowDate.HasValue || show.ShowDate <= request.MaxShowDate.Value)
                                        .Where(show => !request.MinShowDate.HasValue || show.ShowDate >= request.MinShowDate.Value)
                                        .Where(show => !request.MovieId.HasValue || show.MovieId == request.MovieId.Value)
                                        .Where(show => !request.TheaterId.HasValue || show.TheaterRoom.TheaterId == request.TheaterId.Value)
                                        .Where(show => !request.TheaterRoomId.HasValue || show.TheaterRoomId == request.TheaterRoomId.Value);

        var showsTotalItems = await showsQuery.CountAsync();

        var showResults = await showsQuery.Skip(request.Skip)
                                          .Take(request.Take)
                                          .OrderBy(request.OrderBy)
                                          .Select(show => show.AdaptToResource())
                                          .ToListAsync();

        var result = new PagedResource<ShowResource>()
        {
            Results = showResults,
            TotalItems = showsTotalItems,
            Skip = request.Skip,
            Take = request.Take,
        };

        return result;
    }

    [HttpPost]
    public async Task<ActionResult<ShowResource>> Create([FromBody] CreateShowRequest request)
    {
        var movie = await _database.Movies.FirstOrDefaultAsync(movie => movie.Id == request.MovieId);
        var theaterRoom = await _database.TheaterRooms.FirstOrDefaultAsync(movie => movie.Id == request.TheaterRoomId);

        if (movie == null)
        {
            return BadRequest($"Movie with Id={request.MovieId} does not exist.");
        }

        if (theaterRoom == null)
        {
            return BadRequest($"TheaterRoom with Id={request.TheaterRoomId} does not exist.");
        }

        var newShow = request.Adapt<ShowEntities.Show>();
        _database.Shows.Add(newShow);
        await _database.SaveChangesAsync();

        var show = await _database.Shows.IncludeRelated()
                                        .FirstOrDefaultAsync(show => show.Id == newShow.Id);

        return show.AdaptToResource();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<ShowResource>> Update([FromRoute] long id, [FromBody] UpdateShowRequest request)
    {
        var show = await _database.Shows.IncludeRelated()
                                        .FirstOrDefaultAsync(show => show.Id == id);

        if (show == null)
        {
            return NotFound();
        }

        show.Description = !string.IsNullOrEmpty(request.Description) ? request.Description : show.Description;
        show.MovieId = request.MovieId.HasValue ? request.MovieId.Value : show.MovieId;
        show.TheaterRoomId = request.TheaterRoomId.HasValue ? request.TheaterRoomId.Value : show.TheaterRoomId;
        show.TicketPrice = request.TicketPrice.HasValue ? request.TicketPrice.Value : show.TicketPrice;
        show.ShowDate = request.ShowDate.HasValue ? request.ShowDate.Value : show.ShowDate;

        await _database.SaveChangesAsync();

        return show.AdaptToResource();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ShowResource>> Delete([FromRoute] long id)
    {
        var show = await _database.Shows.FirstOrDefaultAsync(g => g.Id == id);

        if (show == null)
        {
            return NotFound();
        }

        _database.Shows.Remove(show);
        await _database.SaveChangesAsync();

        return Ok();
    }
}