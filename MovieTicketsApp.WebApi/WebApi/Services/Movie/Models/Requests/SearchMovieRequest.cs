using System.ComponentModel.DataAnnotations;

namespace MovieTicketsApp.WebApi.Services.Movie.Models;

public class SearchMovieRequest
{
    [MaxLength(500)]
    public string Title { get; set; }

    public long? GenreId { get; set; }
}