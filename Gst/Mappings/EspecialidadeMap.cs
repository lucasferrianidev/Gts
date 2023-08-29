using Gst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gst.Mappings;

public class EspecialidadeMap : IEntityTypeConfiguration<Especialidade>
{
    public void Configure(EntityTypeBuilder<Especialidade> builder)
    {
        builder.HasKey(e => e.CdEspecialidade)
            .HasName("Especialidade__cdEspecialidade_PK");

        builder.ToTable("ESPECIALIDADE_TB");

        builder.Property(e => e.CdEspecialidade)
            .IsRequired()
            .HasColumnName("CDESPECIALIDADE")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Nome)
            .IsRequired()
            .HasColumnName("NOME")
            .HasColumnType("varchar(100)");

        builder.Property(e => e.Favorito).HasDefaultValue(false);
    }
}
