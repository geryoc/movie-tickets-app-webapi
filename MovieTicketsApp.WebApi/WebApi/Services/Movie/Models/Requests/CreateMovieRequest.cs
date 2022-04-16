using System.ComponentModel.DataAnnotations;
using MovieTicketsApp.WebApi.Shared.Web.CustomValidationAttributes;

namespace MovieTicketsApp.WebApi.Services.Movie.Models;

public class CreateMovieRequest
{
    [Required]
    [MaxLength(500)]
    public string Title { get; set; }

    [Required]
    [EntityExists(typeof(Genre.Entities.Genre))]
    public long GenreId { get; set; }
}