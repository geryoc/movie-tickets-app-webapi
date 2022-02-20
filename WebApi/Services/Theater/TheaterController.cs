using System.Linq;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        var theater = await _database.Theaters.FirstOrDefaultAsync(theater => theater.Id == id);

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
                                      .Where(theater => string.IsNullOrEmpty(request.Name) || theater.Name == request.Name)
                                      .ToListAsync();

        return theaters.Adapt<List<TheaterResource>>();
    }

    [HttpPost]
    public async Task<ActionResult<TheaterResource>> Create([FromBody] CreateTheaterRequest request)
    {
        var theater = request.Adapt<Theater>();
        _database.Theaters.Add(theater);
        await _database.SaveChangesAsync();
        return theater.Adapt<TheaterResource>();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<TheaterResource>> Update([FromRoute] long id, [FromBody] UpdateTheaterRequest request)
    {
        var theater = await _database.Theaters.FirstOrDefaultAsync(theater => theater.Id == id);

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
        var theater = await _database.Theaters.FirstOrDefaultAsync(theater => theater.Id == id);

        if (theater == null)
        {
            return NotFound();
        }

        _database.Theaters.Remove(theater);
        await _database.SaveChangesAsync();

        return Ok();
    }
}