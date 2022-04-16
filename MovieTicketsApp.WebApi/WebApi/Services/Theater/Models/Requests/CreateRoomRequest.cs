using System.ComponentModel.DataAnnotations;
using MovieTicketsApp.WebApi.Shared.Web.CustomValidationAttributes;

namespace MovieTicketsApp.WebApi.Services.Theater.Models;

public class CreateRoomRequest
{
    [Required]
    [MaxLength(500)]
    public string Name { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }
}