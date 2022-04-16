
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MovieTicketsApp.WebApi.Shared.Database;

public static class DatabaseContextHelper
{
    public static void HandleEntityTimestamps(this ChangeTracker changeTracker)
    {
        var entries = changeTracker
            .Entries()
            .Where(e => e.Entity is Entity && (e.State == EntityState.Added ||
                                               e.State == EntityState.Modified ||
                                               e.State == EntityState.Deleted));

        foreach (var entityEntry in entries)
        {
            switch (entityEntry.State)
            {
                case EntityState.Deleted:
                    entityEntry.State = EntityState.Modified;
                    ((Entity)entityEntry.Entity).Deleted = System.DateTimeOffset.UtcNow;
                    break;
                case EntityState.Modified:
                    ((Entity)entityEntry.Entity).Updated = System.DateTimeOffset.UtcNow;
                    break;
                case EntityState.Added:
                    ((Entity)entityEntry.Entity).Created = System.DateTimeOffset.UtcNow;
                    break;
                default:
                    break;
            }
        }
    }

    public static void AddSoftDeleteQueryFilter(this ModelBuilder modelBuilder)
    {
        var entityTypes = modelBuilder
            .Model
            .GetEntityTypes()
            .Select(entity => entity.ClrType)
            .ToList();

        foreach (var type in entityTypes)
        {
            if (typeof(Entity).IsAssignableFrom(type))
            {
                MethodInfo method = typeof(DatabaseContextHelper).GetMethod("ApplySoftDeleteFilterForType", BindingFlags.Static | BindingFlags.NonPublic);
                MethodInfo applySoftDeleteFilter = method.MakeGenericMethod(type);
                applySoftDeleteFilter.Invoke(null, new[] { modelBuilder });
            }
        }
    }

    private static void ApplySoftDeleteFilterForType<Type>(ModelBuilder builder) where Type : Entity
    {
        builder.Entity<Type>().HasQueryFilter(m => EF.Property<DateTimeOffset?>(m, "Deleted") == null);
    }
}