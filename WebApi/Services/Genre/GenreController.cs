using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTicketsApp.WebApi.Services.Genre.Models;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<GenreResource>> Get([FromRoute] GetGenreRequest request)
    {
        var genre = await _database.Genres.FirstOrDefaultAsync(genre => genre.Id == request.Id);

        if (genre == null)
        {
            return NotFound();
        }

        return genre.Adapt<GenreResource>();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenreResource>>> Search([FromQuery] SearchGenreRequest request)
    {
        var genres = await _database.Genres
            .Where(genre => string.IsNullOrEmpty(request.Name) || genre.Name == request.Name)
            .ToListAsync();

        return genres.Adapt<List<GenreResource>>();
    }

    [HttpPost]
    public async Task<ActionResult<GenreResource>> Create([FromBody] CreateGenreRequest request)
    {
        var genre = request.Adapt<Entities.Genre>();
        _database.Genres.Add(genre);
        await _database.SaveChangesAsync();
        return genre.Adapt<GenreResource>();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<GenreResource>> Update([FromRoute] long id, [FromBody] UpdateGenreRequest request)
    {
        var genre = await _database.Genres.FirstOrDefaultAsync(genre => genre.Id == id);

        if (genre == null)
        {
            return NotFound();
        }

        genre.Name = string.IsNullOrEmpty(request.Name) ? genre.Name : request.Name;

        await _database.SaveChangesAsync();

        return genre.Adapt<GenreResource>();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<GenreResource>> Delete([FromRoute] long id)
    {
        var genre = await _database.Genres.FirstOrDefaultAsync(genre => genre.Id == id);

        if (genre == null)
        {
            return NotFound();
        }

        _database.Genres.Remove(genre);
        await _database.SaveChangesAsync();

        return Ok();
    }
}