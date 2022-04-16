using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieTicketsApp.WebApi.Shared.Database;

namespace MovieTicketsApp.WebApi.Services.Genre.Entities;

[Table("Genre", Schema = "MovieTicketApp")]
public class Genre : Entity
{
    [Required]
    [MaxLength(500)]
    public string Name { get; set; }
}