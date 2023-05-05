using Gst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gst.Mappings;

public class ProfissionalEspecialidadeMap : IEntityTypeConfiguration<ProfissionalEspecialidade>
{
    public void Configure(EntityTypeBuilder<ProfissionalEspecialidade> builder)
    {
        builder.HasKey(e => e.CdProfissionalEspecialidade)
            .HasName("ProfissionalEspecialidade__cdProfissionalEspecialidade_PK");

        builder.ToTable("PROFISSIONAL_ESPECIALIDADE_TB");

        builder.HasIndex(e => new { e.CdProfissional, e.CdEspecialidade },
            "ProfissionalEspecialidade__cdProfissional_cdEspecialidade_IDX")
            .IsUnique();

        builder.Property(e => e.CdEspecialidade)
            .IsRequired()
            .HasColumnName("CDESPECIALIDADE")
            .HasColumnType("int");

        builder.Property(e => e.CdProfissional)
            .IsRequired()
            .HasColumnName("CDPROFISSIONAL")
            .HasColumnType("int");

        builder.HasOne(d => d.Especialidade)
            .WithMany()
            .HasForeignKey(d => d.CdEspecialidade)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Especialidade__cdEspecialidade_FK");

        builder.HasOne(d => d.Profissional)
            .WithMany()
            .HasForeignKey(d => d.CdProfissional)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Profissional__cdProfisional_FK");
    }
}
