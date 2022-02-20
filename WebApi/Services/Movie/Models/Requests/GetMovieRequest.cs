using System.ComponentModel.DataAnnotations;

namespace MovieTicketsApp.WebApi.Services.Movie.Models;

public class GetMovieRequest
{
    [Required]
    public long Id { get; set; }
}