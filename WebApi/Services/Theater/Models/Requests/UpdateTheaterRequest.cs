using System.ComponentModel.DataAnnotations;

namespace MovieTicketsApp.WebApi.Services.Theater.Models;

public class UpdateTheaterRequest
{
    [MaxLength(500)]
    public string Name { get; set; }
}