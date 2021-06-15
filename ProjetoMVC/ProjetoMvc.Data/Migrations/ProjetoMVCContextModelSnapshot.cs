﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoMVC.Data.Context;

namespace ProjetoMvc.Data.Migrations
{
    [DbContext(typeof(ProjetoMVCContext))]
    partial class ProjetoMVCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoMVC.Business.Models.Bancada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Frontao")
                        .HasColumnType("DECIMAL(10,2)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("VARCHAR(450)");

                    b.Property<decimal>("MetroQuadrado")
                        .HasColumnType("DECIMAL(10,2)");

                    b.Property<Guid?>("ModeloBancadaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Saia")
                        .HasColumnType("DECIMAL(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ModeloBancadaId");

                    b.ToTable("Bancadas");
                });

            modelBuilder.Entity("ProjetoMVC.Business.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoriaPaiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaPaiId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ProjetoMVC.Business.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProjetoMVC.Business.Models.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AtreladoDolar")
                        .HasColumnType("bit");

                    b.Property<Guid?>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Imagem")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Materiais");
                });

            modelBuilder.Entity("ProjetoMVC.Business.Models.ModeloBancada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Imagem")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Metodo")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<int>("QuantidadePecas")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("ModelosBancadas");
                });

            modelBuilder.Entity("ProjetoMVC.Business.Models.Peca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AlturaDaBase")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ApoioComprimento")
                        .HasColumnType("int");

                    b.Property<int>("ApoioLargura")
                        .HasColumnType("int");

                    b.Property<Guid?>("BancadaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Base")
                        .HasColumnType("int");

                    b.Property<decimal>("Comprimento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ComprimentoFogaoEmbutido")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Largura")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MetroQuadradoPeca")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalComprimentoPeca")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalLarguraPeca")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BancadaId");

                    b.ToTable("Peca");
                });

            modelBuilder.Entity("ProjetoMVC.Business.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Imagem")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INT");

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ProjetoMVC.Business.Models.Bancada", b =>
                {
                    b.HasOne("ProjetoMVC.Business.Models.ModeloBancada", "ModeloBancada")
                        .WithMany()
                        .HasForeignKey("ModeloBancadaId");
                });

            modelBuilder.Entity("ProjetoMVC.Business.Models.Categoria", b =>
                {
                    b.HasOne("ProjetoMVC.Business.Models.Categoria", "CategoriaPai")
                        .WithMany()
                        .HasForeignKey("CategoriaPaiId");
                });

            modelBuilder.Entity("ProjetoMVC.Business.Models.Material", b =>
                {
                    b.HasOne("ProjetoMVC.Business.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("ProjetoMVC.Business.Models.ModeloBancada", b =>
                {
                    b.HasOne("ProjetoMVC.Business.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoMVC.Business.Models.Peca", b =>
                {
                    b.HasOne("ProjetoMVC.Business.Models.Bancada", null)
                        .WithMany("Pecas")
                        .HasForeignKey("BancadaId");
                });

            modelBuilder.Entity("ProjetoMVC.Business.Models.Produto", b =>
                {
                    b.HasOne("ProjetoMVC.Business.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");
                });
#pragma warning restore 612, 618
        }
    }
}
