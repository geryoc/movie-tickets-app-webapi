using System.ComponentModel.DataAnnotations;

namespace MovieTicketsApp.WebApi.Services.Theater.Models;

public class CreateTheaterRequest
{
    [Required]
    [MaxLength(500)]
    public string Name { get; set; }
}