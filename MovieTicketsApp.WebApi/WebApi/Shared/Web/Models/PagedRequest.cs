namespace MovieTicketsApp.WebApi.Shared.Web.Models;

public class PagedRequest
{
    public int Skip { get; set; }
    public int Take { get; set; } = 1000;
}