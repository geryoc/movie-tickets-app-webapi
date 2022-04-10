using System.ComponentModel.DataAnnotations;
using MovieTicketsApp.WebApi.Shared.Web.CustomValidationAttributes;

namespace MovieTicketsApp.WebApi.Services.Show.Models;

public class UpdateShowRequest
{
    [MaxLength(500)]
    public string Description { get; set; }

    [EntityExists(typeof(Movie.Entities.Movie))]
    public long? MovieId { get; set; }

    [EntityExists(typeof(Theater.Entities.TheaterRoom))]
    public long? TheaterRoomId { get; set; }

    [Range(typeof(decimal), "0.0", "9999999999999999.99")]
    public decimal? TicketPrice { get; set; }

    public DateTime? ShowDate { get; set; }
}