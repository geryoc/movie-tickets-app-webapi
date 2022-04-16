using MovieTicketsApp.WebApi.Services.Movie.Models;
using MovieTicketsApp.WebApi.Services.Theater.Models;

namespace MovieTicketsApp.WebApi.Services.Show.Models;

public class ShowResource
{
    public long Id { get; set; }
    public string Description { get; set; }
    public DateTime ShowDate { get; set; }
    public MovieResource Movie { get; set; }
    public ShowTheaterResource Theater { get; set; }
    public TheaterRoomResource TheaterRoom { get; set; }
    public decimal TicketPrice { get; set; }
}
