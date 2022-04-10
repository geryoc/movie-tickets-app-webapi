using System.ComponentModel.DataAnnotations;
using MovieTicketsApp.WebApi.Shared.Web.CustomValidationAttributes;

namespace MovieTicketsApp.WebApi.Services.Show.Models;

public class CreateShowRequest
{
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }

    [Required]
    [EntityExists(typeof(Movie.Entities.Movie))]
    public long MovieId { get; set; }

    [Required]
    [EntityExists(typeof(Theater.Entities.TheaterRoom))]
    public long TheaterRoomId { get; set; }

    [Required]
    [Range(typeof(decimal), "0.0", "9999999999999999.99")]
    public decimal TicketPrice { get; set; }

    [Required]
    public DateTime ShowDate { get; set; }
}