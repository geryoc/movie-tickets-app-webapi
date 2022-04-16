using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieTicketsApp.WebApi.Shared.Database;
using GenreEntities = MovieTicketsApp.WebApi.Services.Genre.Entities;

namespace MovieTicketsApp.WebApi.Services.Movie.Entities;

[Table("Movie", Schema = "MovieTicketApp")]
public class Movie : Entity
{
    [Required]
    [MaxLength(500)]
    public string Title { get; set; }

    [Required]
    public GenreEntities.Genre Genre { get; set; }
}
