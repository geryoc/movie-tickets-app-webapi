using System.ComponentModel.DataAnnotations;

namespace MovieTicketsApp.WebApi.Services.Genre.Models;

public class GetGenreRequest
{
    [Required]
    public long Id { get; set; }
}
