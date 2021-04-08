using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMvc.Data.Mapping
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {

            builder.ToTable("Categorias");

            builder.HasKey(p => p.Id);

            builder.Property(c => c.Nome)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(c => c.Slug)
                .IsRequired()
                .HasColumnType("varchar(100)");
            

            builder.HasOne(c => c.CategoriaPai);
           

        }
    }
}
