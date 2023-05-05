using Gst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gst.Mappings;

public class FerramentaMap : IEntityTypeConfiguration<Ferramenta>
{
    public void Configure(EntityTypeBuilder<Ferramenta> builder)
    {
        builder.HasKey(e => e.CdFerramenta)
            .HasName("Ferramenta__cdFerramenta_PK");

        builder.ToTable("FERRAMENTA_TB");

        builder.Property(e => e.CdProfissional)
            .IsRequired()
            .HasColumnName("CDPROFISSIONAL")
            .HasColumnType("int");

        builder.Property(e => e.CdFerramenta)
            .IsRequired()
            .HasColumnName("CDFERRAMENTA")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Nome)
            .IsRequired()
            .HasColumnName("NOME")
            .HasColumnType("varchar(100)");

        builder.Property(e => e.Marca)
            .HasColumnName("MARCA")
            .HasColumnType("varchar(100)");

        builder.HasOne(f => f.Profissional)
            .WithMany(p => p.Ferramentas)
            .HasForeignKey(f => f.CdProfissional)
            .HasConstraintName("FerramentaXProfissional__cdProfissional_FK");
    }
}
