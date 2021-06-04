using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMvc.Data.Mapping
{
    public class BancadaMapping : IEntityTypeConfiguration<Bancada>
    {
        public void Configure(EntityTypeBuilder<Bancada> builder)
        {
            builder.HasKey(p => p.Id);

            //builder.Property(p => p.Nome)
            //    .IsRequired()
            //    .HasColumnType("VARCHAR(250)");

            //builder.Property(p => p.Descricao)
            //  .IsRequired()
            //  .HasColumnType("VARCHAR(250)");

            builder.Property(p => p.Imagem)
            .IsRequired()
            .HasColumnType("VARCHAR(450)");

            builder.Property(p => p.Frontao)
              .HasColumnType("DECIMAL(10,2)");

            builder.Property(p => p.Saia)
                .HasColumnType("DECIMAL(10,2)");
            
            builder.Property(p => p.MetroQuadrado)
               .HasColumnType("DECIMAL(10,2)");

            //builder.Property(p => p.QuantidadePecas)
            //    .HasColumnType("INT");

            ////builder.HasMany(b => b.Pecas);


            //builder.HasOne(p => p.Categoria);            

            builder.ToTable("Bancadas");
        }
    }
}
