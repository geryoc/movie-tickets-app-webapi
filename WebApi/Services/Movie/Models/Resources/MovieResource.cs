using MovieTicketsApp.WebApi.Services.Genre.Models;

namespace MovieTicketsApp.WebApi.Services.Movie.Models;

public class MovieResource
{
    public long Id { get; set; }
    public string Title { get; set; }
    public GenreResource Genre { get; set; }
}