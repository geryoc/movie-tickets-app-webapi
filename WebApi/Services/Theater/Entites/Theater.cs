using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieTicketsApp.WebApi.Shared.Database;

namespace MovieTicketsApp.WebApi.Services.Theater;

[Table("Theater", Schema = "MovieTicketApp")]
public class Theater : Entity
{
    [Required]
    [MaxLength(500)]
    public string Name { get; set; }
}