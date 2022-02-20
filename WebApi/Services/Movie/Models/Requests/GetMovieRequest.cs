using System.ComponentModel.DataAnnotations;

namespace MovieTicketsApp.WebApi.Services.Movie.Models;

public class GetMovieRequest
{
    public long Id { get; set; }
}