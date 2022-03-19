using System.Linq;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTicketsApp.WebApi.Services.Theater.Entities;
using MovieTicketsApp.WebApi.Services.Theater.Models;
using MovieTicketsApp.WebApi.Shared.Database;

namespace MovieTicketsApp.WebApi.Services.Theater;

[Route("api/[controller]")]
[ApiController]
public class TheaterController : ControllerBase
{
    private DatabaseContext _database;

    public TheaterController(DatabaseContext context)
    {
        _database = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TheaterResource>> Get([FromRoute] long id)
    {
        var theater = await _database.Theaters
                                     .Include(theater => theater.Rooms)
                                     .FirstOrDefaultAsync(theater => theater.Id == id);

        if (theater == null)
        {
            return NotFound();
        }

        return theater.Adapt<TheaterResource>();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TheaterResource>>> Search([FromQuery] SearchTheaterRequest request)
    {
        var theaters = await _database.Theaters
                                      .Include(theater => theater.Rooms)
                                      .Where(theater => string.IsNullOrEmpty(request.Name) || theater.Name == request.Name)
                                      .ToListAsync();

        return theaters.Adapt<List<TheaterResource>>();
    }

    [HttpPost]
    public async Task<ActionResult<TheaterResource>> Create([FromBody] CreateTheaterRequest request)
    {
        var theater = request.Adapt<Theater.Entities.Theater>();
        theater.Rooms = new List<TheaterRoom>();

        _database.Theaters.Add(theater);
        await _database.SaveChangesAsync();

        return theater.Adapt<TheaterResource>();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<TheaterResource>> Update([FromRoute] long id, [FromBody] UpdateTheaterRequest request)
    {
        var theater = await _database.Theaters
                                     .Include(theater => theater.Rooms)
                                     .FirstOrDefaultAsync(theater => theater.Id == id);

        if (theater == null)
        {
            return NotFound();
        }

        theater.Name = string.IsNullOrWhiteSpace(request.Name) ? theater.Name : request.Name;

        await _database.SaveChangesAsync();

        return theater.Adapt<TheaterResource>();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] long id)
    {
        var theater = await _database.Theaters
                                     .Include(theater => theater.Rooms)
                                     .FirstOrDefaultAsync(theater => theater.Id == id);

        if (theater == null)
        {
            return NotFound();
        }

        _database.TheaterRooms.RemoveRange(theater.Rooms);
        _database.Theaters.Remove(theater);

        await _database.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("{theaterId}/room")]
    public async Task<ActionResult<TheaterResource>> CreateRoom([FromRoute] long theaterId, [FromBody] CreateRoomRequest request)
    {
        var theater = await _database.Theaters
                                     .Include(theater => theater.Rooms)
                                     .FirstOrDefaultAsync(theater => theater.Id == theaterId);

        if (theater == null)
        {
            return NotFound();
        }

        theater.Rooms.Add(request.Adapt<TheaterRoom>());

        await _database.SaveChangesAsync();

        return theater.Adapt<TheaterResource>();
    }

    [HttpPatch("{theaterId}/room/{roomId}")]
    public async Task<ActionResult<TheaterResource>> UpdateRoom([FromRoute] long theaterId, [FromRoute] long roomId, [FromBody] UpdateRoomRequest request)
    {
        var theater = await _database.Theaters
                                     .Include(theater => theater.Rooms)
                                     .FirstOrDefaultAsync(theater => theater.Id == theaterId);

        if (theater == null)
        {
            return NotFound();
        }

        var room = theater.Rooms.FirstOrDefault(room => room.Id == roomId);

        if (room == null)
        {
            return NotFound();
        }

        room.Name = string.IsNullOrWhiteSpace(request.Name) ? room.Name : request.Name;
        room.Description = string.IsNullOrWhiteSpace(request.Description) ? room.Description : request.Description;

        await _database.SaveChangesAsync();

        return theater.Adapt<TheaterResource>();
    }

    [HttpDelete("{theaterId}/room/{roomId}")]
    public async Task<ActionResult> DeleteRoom([FromRoute] long theaterId, [FromRoute] long roomId)
    {
        var theater = await _database.Theaters
                                     .Include(theater => theater.Rooms)
                                     .FirstOrDefaultAsync(theater => theater.Id == theaterId);

        if (theater == null)
        {
            return NotFound();
        }

        var room = theater.Rooms.FirstOrDefault(room => room.Id == roomId);

        if (room == null)
        {
            return NotFound();
        }

        theater.Rooms.Remove(room);
        _database.TheaterRooms.Remove(room);

        await _database.SaveChangesAsync();

        return Ok();
    }
}