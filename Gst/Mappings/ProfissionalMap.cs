using Gst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gst.Mappings;

public class ProfissionalMap : IEntityTypeConfiguration<Profissional>
{
    public void Configure(EntityTypeBuilder<Profissional> builder)
    {
        builder.HasKey(e => e.CdProfissional)
            .HasName("Profissional__cdProfissional_PK");

        builder.ToTable("PROFISSIONAL_TB");

        builder.HasIndex(e => e.CdEndereco,
            "Porfissional__cdEndereco_IDX")
            .IsUnique();

        builder.Property(e => e.CdProfissional)
            .IsRequired()
            .HasColumnName("CDPROFISSIONAL")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Nome)
            .IsRequired()
            .HasColumnName("NOME")
            .HasColumnType("varchar(100)");

        builder.Property(e => e.DataNascimento)
            .IsRequired()
            .HasColumnName("DATANASCIMENTO")
            .HasColumnType("datetime");

        builder.Property(e => e.Cpf)
            .HasColumnName("CPF")
            .HasColumnType("varchar(11)");

        builder.Property(e => e.Comissao)
            .IsRequired()
            .HasColumnName("COMISSAO")
            .HasColumnType("numeric(12,2)");

        builder.Property(e => e.CdEndereco)
            .IsRequired()
            .HasColumnName("CDENDERECO")
            .HasColumnType("int");

        builder.HasOne(e => e.Endereco)
            .WithOne(e => e.Profissional)
            .HasForeignKey<Profissional>(e => e.CdEndereco)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("EnderecoXProfissional__cdEndereco_FK");

        builder.HasMany(p => p.Ferramentas)
            .WithOne(f => f.Profissional)
            .HasForeignKey(f => f.CdFerramenta)
            .HasConstraintName("FerramentaXProfissional__cdFerramenta_FK");
    }
}
