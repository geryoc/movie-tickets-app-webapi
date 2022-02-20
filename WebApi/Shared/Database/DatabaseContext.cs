using Microsoft.EntityFrameworkCore;
using MovieTicketsApp.WebApi.Services.Genre.Entities;
using MovieTicketsApp.WebApi.Services.Movie.Entities;
using MovieTicketsApp.WebApi.Services.Theater;

namespace MovieTicketsApp.WebApi.Shared.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Theater> Theaters { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.AddSoftDeleteQueryFilter();
    }

    public override int SaveChanges()
    {
        ChangeTracker.HandleEntityTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        ChangeTracker.HandleEntityTimestamps();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}