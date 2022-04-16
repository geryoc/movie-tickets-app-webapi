using System.ComponentModel.DataAnnotations;
using MovieTicketsApp.WebApi.Shared.Web.Models;

namespace MovieTicketsApp.WebApi.Services.Show.Models;

public class SearchShowRequest : PagedRequest
{
    [MaxLength(500)]
    public string Description { get; set; }

    public DateTime? MinShowDate { get; set; }

    public DateTime? MaxShowDate { get; set; }

    public long? MovieId { get; set; }

    public long? TheaterId { get; set; }

    public long? TheaterRoomId { get; set; }

    public List<ShowOrderByOption> OrderBy { get; set; }
}

public enum ShowOrderByOption
{
    Created = 0,
    CreatedDescending = 1,
    ShowDate = 2,
    ShowDateDescending = 3,
    TicketPrice = 4,
    TicketPriceDescending = 5,
}