using Gst.Mappings;
using Gst.Models;
using Microsoft.EntityFrameworkCore;

namespace Gst.Data;

public class GstContext : DbContext
{
    public GstContext(DbContextOptions<GstContext> opts) : base(opts)
    {
        
    }

    public DbSet<Profissional> Profissionais { get; set; }
    public DbSet<Ferramenta> Ferramentas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Especialidade> Especialidades { get; set; }
    public DbSet<ProfissionalEspecialidade> ProfissionaisEspecialidades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        //{
        //    // Use the entity name instead of the Context.DbSet<T> name
        //    // refs https://learn.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=fluent-api#table-name
        //    modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
        //}

        modelBuilder.ApplyConfiguration(new EnderecoMap());
        modelBuilder.ApplyConfiguration(new ProfissionalMap());
        modelBuilder.ApplyConfiguration(new FerramentaMap());
        modelBuilder.ApplyConfiguration(new EspecialidadeMap());
        modelBuilder.ApplyConfiguration(new ProfissionalEspecialidadeMap());
    }
}
