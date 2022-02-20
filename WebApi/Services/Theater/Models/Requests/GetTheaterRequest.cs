using System.ComponentModel.DataAnnotations;

namespace MovieTicketsApp.WebApi.Services.Theater.Models;

public class GetTheaterRequest
{
    [Required]
    public long Id { get; set; }
}