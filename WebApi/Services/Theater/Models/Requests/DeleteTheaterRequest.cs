using System.ComponentModel.DataAnnotations;

namespace MovieTicketsApp.WebApi.Services.Theater.Models;

public class DeleteTheaterRequest
{
    [Required]
    public long Id { get; set; }
}