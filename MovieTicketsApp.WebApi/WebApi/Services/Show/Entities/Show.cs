using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieTicketsApp.WebApi.Services.Theater.Entities;
using MovieTicketsApp.WebApi.Shared.Database;

namespace MovieTicketsApp.WebApi.Services.Show.Entities;

[Table("Show", Schema = "MovieTicketApp")]
public class Show : Entity
{
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }

    public long MovieId { get; set; }
    public Movie.Entities.Movie Movie { get; set; }

    public long TheaterRoomId { get; set; }
    public TheaterRoom TheaterRoom { get; set; }

    public DateTime ShowDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TicketPrice { get; set; }
}
