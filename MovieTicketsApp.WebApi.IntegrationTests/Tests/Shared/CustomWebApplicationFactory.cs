using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieTicketsApp.WebApi.Shared.Database;

namespace MovieTicketsApp.WebApi.IntegrationTests.Tests.Shared;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<DatabaseContext>));

            services.Remove(descriptor);

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase("MovieTicketsApp.IntegrationTests");
            });

            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var databaseContext = scopedServices.GetRequiredService<DatabaseContext>();
                databaseContext.Database.EnsureCreated();
                databaseContext.SeedDataForIntegrationTests();
            }
        });
    }
}
