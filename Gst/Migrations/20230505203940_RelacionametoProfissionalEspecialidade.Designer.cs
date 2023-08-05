﻿// <auto-generated />
using System;
using Gst.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gst.Migrations
{
    [DbContext(typeof(GstDbContext))]
    [Migration("20230505203940_RelacionametoProfissionalEspecialidade")]
    partial class RelacionametoProfissionalEspecialidade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Gst.Models.Endereco", b =>
                {
                    b.Property<int>("CdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CDENDERECO");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("BAIRRO");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CIDADE");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("COMPLEMENTO");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LOGRADOURO");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NUMERO");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("UF");

                    b.HasKey("CdEndereco")
                        .HasName("Endereco__cdEndereco_PK");

                    b.ToTable("ENDERECO_TB", (string)null);
                });

            modelBuilder.Entity("Gst.Models.Especialidade", b =>
                {
                    b.Property<int>("CdEspecialidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CDESPECIALIDADE");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NOME");

                    b.HasKey("CdEspecialidade")
                        .HasName("Especialidade__cdEspecialidade_PK");

                    b.ToTable("ESPECIALIDADE_TB", (string)null);
                });

            modelBuilder.Entity("Gst.Models.Ferramenta", b =>
                {
                    b.Property<int>("CdFerramenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CDFERRAMENTA");

                    b.Property<int>("CdProfissional")
                        .HasColumnType("int")
                        .HasColumnName("CDPROFISSIONAL");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("MARCA");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NOME");

                    b.HasKey("CdFerramenta")
                        .HasName("Ferramenta__cdFerramenta_PK");

                    b.HasIndex("CdProfissional");

                    b.ToTable("FERRAMENTA_TB", (string)null);
                });

            modelBuilder.Entity("Gst.Models.Profissional", b =>
                {
                    b.Property<int>("CdProfissional")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CDPROFISSIONAL");

                    b.Property<int>("CdEndereco")
                        .HasColumnType("int")
                        .HasColumnName("CDENDERECO");

                    b.Property<decimal>("Comissao")
                        .HasColumnType("numeric(12,2)")
                        .HasColumnName("COMISSAO");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime")
                        .HasColumnName("DATANASCIMENTO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NOME");

                    b.HasKey("CdProfissional")
                        .HasName("Profissional__cdProfissional_PK");

                    b.HasIndex(new[] { "CdEndereco" }, "Porfissional__cdEndereco_IDX")
                        .IsUnique();

                    b.ToTable("PROFISSIONAL_TB", (string)null);
                });

            modelBuilder.Entity("Gst.Models.ProfissionalEspecialidade", b =>
                {
                    b.Property<int>("CdProfissionalEspecialidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CdEspecialidade")
                        .HasColumnType("int")
                        .HasColumnName("CDESPECIALIDADE");

                    b.Property<int>("CdProfissional")
                        .HasColumnType("int")
                        .HasColumnName("CDPROFISSIONAL");

                    b.HasKey("CdProfissionalEspecialidade")
                        .HasName("ProfissionalEspecialidade__cdProfissionalEspecialidade_PK");

                    b.HasIndex("CdEspecialidade");

                    b.HasIndex(new[] { "CdProfissional", "CdEspecialidade" }, "ProfissionalEspecialidade__cdProfissional_cdEspecialidade_IDX")
                        .IsUnique();

                    b.ToTable("PROFISSIONAL_ESPECIALIDADE_TB", (string)null);
                });

            modelBuilder.Entity("Gst.Models.Ferramenta", b =>
                {
                    b.HasOne("Gst.Models.Profissional", "Profissional")
                        .WithMany("Ferramentas")
                        .HasForeignKey("CdProfissional")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FerramentaXProfissional__cdProfissional_FK");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("Gst.Models.Profissional", b =>
                {
                    b.HasOne("Gst.Models.Endereco", "Endereco")
                        .WithOne("Profissional")
                        .HasForeignKey("Gst.Models.Profissional", "CdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("EnderecoXProfissional__cdEndereco_FK");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Gst.Models.ProfissionalEspecialidade", b =>
                {
                    b.HasOne("Gst.Models.Especialidade", "Especialidade")
                        .WithMany()
                        .HasForeignKey("CdEspecialidade")
                        .IsRequired()
                        .HasConstraintName("Especialidade__cdEspecialidade_FK");

                    b.HasOne("Gst.Models.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("CdProfissional")
                        .IsRequired()
                        .HasConstraintName("Profissional__cdProfisional_FK");

                    b.Navigation("Especialidade");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("Gst.Models.Endereco", b =>
                {
                    b.Navigation("Profissional")
                        .IsRequired();
                });

            modelBuilder.Entity("Gst.Models.Profissional", b =>
                {
                    b.Navigation("Ferramentas");
                });
#pragma warning restore 612, 618
        }
    }
}