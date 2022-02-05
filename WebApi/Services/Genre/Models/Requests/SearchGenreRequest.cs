using System.ComponentModel.DataAnnotations;

namespace MovieTicketsApp.WebApi.Services.Genre.Models;

public class SearchGenreRequest
{
    [MaxLength(500)]
    public string Name { get; set; }
}