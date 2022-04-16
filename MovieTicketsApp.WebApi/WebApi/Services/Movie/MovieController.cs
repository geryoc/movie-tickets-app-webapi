using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTicketsApp.WebApi.Services.Movie.Models;
using MovieTicketsApp.WebApi.Shared.Database;

namespace MovieTicketsApp.WebApi.Services.Movie;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private DatabaseContext _database;

    public MovieController(DatabaseContext databaseContext)
    {
        _database = databaseContext;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieResource>> Get([FromRoute] long id)
    {
        var movie = await _database.Movies
                                   .Include(movie => movie.Genre)
                                   .FirstOrDefaultAsync(movie => movie.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        return movie.Adapt<MovieResource>();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieResource>>> Search([FromQuery] SearchMovieRequest request)
    {
        var movies = await _database.Movies
                                    .Include(movie => movie.Genre)
                                    .Where(movie => string.IsNullOrEmpty(request.Title) || movie.Title == request.Title)
                                    .Where(movie => !request.GenreId.HasValue || movie.Genre.Id == request.GenreId)
                                    .ToListAsync();

        return movies.Adapt<List<MovieResource>>();
    }

    [HttpPost]
    public async Task<ActionResult<MovieResource>> Create([FromBody] CreateMovieRequest request)
    {
        var genre = await _database.Genres.FirstOrDefaultAsync(genre => genre.Id == request.GenreId);

        if (genre == null)
        {
            return BadRequest($"Genre with Id={request.GenreId} does not exist.");
        }

        var movie = new Entities.Movie
        {
            Title = request.Title,
            Genre = genre,
        };

        _database.Movies.Add(movie);
        await _database.SaveChangesAsync();

        return movie.Adapt<MovieResource>();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<MovieResource>> Update([FromRoute] long id, [FromBody] UpdateMovieRequest request)
    {
        var movie = await _database.Movies.Include(movie => movie.Genre)
                                          .FirstOrDefaultAsync(movie => movie.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        movie.Title = string.IsNullOrEmpty(request.Title) ? movie.Title : request.Title;

        if (request.GenreId.HasValue && request.GenreId != movie.Genre.Id)
        {
            var genre = await _database.Genres.FirstOrDefaultAsync(genre => genre.Id == request.GenreId);
            movie.Genre = genre;
        }

        await _database.SaveChangesAsync();

        return movie.Adapt<MovieResource>();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MovieResource>> Delete([FromRoute] long id)
    {
        var movie = await _database.Movies.FirstOrDefaultAsync(g => g.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        _database.Movies.Remove(movie);
        await _database.SaveChangesAsync();

        return Ok();
    }
}