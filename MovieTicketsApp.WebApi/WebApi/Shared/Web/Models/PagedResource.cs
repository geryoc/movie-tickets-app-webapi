namespace MovieTicketsApp.WebApi.Shared.Web.Models;

public class PagedResource<T>
{
    public List<T> Results { get; set; }
    public int TotalItems { get; set; }
    public int? Take { get; set; }
    public int? Skip { get; set; }
}