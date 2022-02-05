using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTicketsApp.WebApi.Shared.Database;

namespace MovieTicketsApp.WebApi.Services.Genre;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private DatabaseContext _database;

    public GenreController(DatabaseContext databaseContext)
    {
        _database = databaseContext;
    }

    [HttpPost]
    public async Task<ActionResult<Models.Genre>> Create([FromBody] Models.CreateGenreRequest request)
    {
        var genre = request.Adapt<Entities.Genre>();
        _database.Genres.Add(genre);
        await _database.SaveChangesAsync();
        return genre.Adapt<Models.Genre>();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Models.Genre>> GetGenre([FromRoute] Models.GetGenreRequest request)
    {
        var genre = await _database.Genres.FirstOrDefaultAsync(g => g.Id == request.Id);

        if (genre == null)
        {
            return NotFound();
        }

        return genre.Adapt<Models.Genre>();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Genre>>> SearchGenre([FromQuery] Models.SearchGenreRequest request)
    {
        var genres = await _database.Genres
            .Where(g => string.IsNullOrEmpty(request.Name) || g.Name == request.Name)
            .ToListAsync();

        return genres.Adapt<List<Models.Genre>>();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<Models.Genre>> UpdateGenre([FromRoute] long id, [FromBody] Models.UpdateGenreRequest request)
    {
        var genre = await _database.Genres.FirstOrDefaultAsync(g => g.Id == id);

        if (genre == null)
        {
            return NotFound();
        }

        genre.Name = string.IsNullOrEmpty(request.Name) ? genre.Name : request.Name;

        await _database.SaveChangesAsync();

        return genre.Adapt<Models.Genre>();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Models.Genre>> DeleteGenre([FromRoute] long id)
    {
        var genre = await _database.Genres.FirstOrDefaultAsync(g => g.Id == id);

        if (genre == null)
        {
            return NotFound();
        }

        _database.Genres.Remove(genre);
        await _database.SaveChangesAsync();

        return Ok();
    }
}