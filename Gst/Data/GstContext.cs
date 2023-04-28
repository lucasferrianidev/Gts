using Gst.Models;
using Microsoft.EntityFrameworkCore;

namespace Gst.Data;

public class GstContext : DbContext
{
    public GstContext(DbContextOptions<GstContext> opts) : base(opts)
    {
        
    }

    public DbSet<Profissional> Profissionais { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            // Use the entity name instead of the Context.DbSet<T> name
            // refs https://learn.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=fluent-api#table-name
            modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
        }
    }
}
