using Gst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gst.Mappings;

public class EnderecoMap : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.HasKey(e => e.CdEndereco)
            .HasName("Endereco__cdEndereco_PK");

        builder.ToTable("ENDERECO_TB");

        builder.Property(e => e.CdEndereco)
            .IsRequired()
            .HasColumnName("CDENDERECO")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Logradouro)
            .IsRequired()
            .HasColumnName("LOGRADOURO")
            .HasColumnType("varchar(100)");

        builder.Property(e => e.Numero)
            .IsRequired()
            .HasColumnName("NUMERO")
            .HasColumnType("varchar(50)");

        builder.Property(e => e.Complemento)
            .HasColumnName("COMPLEMENTO")
            .HasColumnType("varchar(100)");

        builder.Property(e => e.Bairro)
            .IsRequired()
            .HasColumnName("BAIRRO")
            .HasColumnType("varchar(100)");

        builder.Property(e => e.Cep)
            .IsRequired()
            .HasColumnName("CEP")
            .HasColumnType("varchar(8)");

        builder.Property(e => e.Cidade)
            .IsRequired()
            .HasColumnName("CIDADE")
            .HasColumnType("varchar(100)");
        
        builder.Property(e => e.Uf)
            .IsRequired()
            .HasColumnName("UF")
            .HasColumnType("varchar(2)");
    }
}
