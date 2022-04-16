using System.ComponentModel.DataAnnotations;

namespace MovieTicketsApp.WebApi.Services.Genre.Models;

public class CreateGenreRequest
{
    [Required]
    [MaxLength(500)]
    public string Name { get; set; }
}