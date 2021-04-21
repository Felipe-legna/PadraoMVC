using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMvc.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(250)");

            builder.Property(p => p.Descricao)
              .IsRequired()
              .HasColumnType("VARCHAR(250)");

            builder.Property(p => p.Valor)
              .HasColumnType("DECIMAL(10,2)");

            builder.Property(p => p.Quantidade)
                .HasColumnType("INT");



            builder.HasOne(p => p.Categoria);
            
            //(p => p.CategoriaProdutoId);

          

            builder.ToTable("Produtos");
        }
    }
}
