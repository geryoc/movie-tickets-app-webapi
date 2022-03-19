namespace MovieTicketsApp.WebApi.Services.Theater.Models;

public class TheaterResource
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<TheaterRoomResource> Rooms { get; set; }
}