using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieTicketsApp.WebApi.Shared.Database;

namespace MovieTicketsApp.WebApi.Services.Theater.Entities;

[Table("TheaterRoom", Schema = "MovieTicketApp")]
public class TheaterRoom : Entity
{
    [Required]
    [MaxLength(500)]
    public string Name { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    public long TheaterId { get; set; }
    public Theater Theater { get; set; }
}