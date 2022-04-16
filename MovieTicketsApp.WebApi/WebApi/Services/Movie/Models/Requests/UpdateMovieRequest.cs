using System.ComponentModel.DataAnnotations;
using MovieTicketsApp.WebApi.Shared.Web.CustomValidationAttributes;

namespace MovieTicketsApp.WebApi.Services.Movie.Models;

public class UpdateMovieRequest
{
    [MaxLength(500)]
    public string Title { get; set; }

    [EntityExists(typeof(Genre.Entities.Genre))]
    public long? GenreId { get; set; }
}