using System.ComponentModel.DataAnnotations;

namespace MovieTicketsApp.WebApi.Services.Theater.Models;

public class UpdateRoomRequest
{
    [MaxLength(500)]
    public string Name { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }
}