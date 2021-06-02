using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMvc.Data.Mapping
{
    public class ModeloBancadaMapping : IEntityTypeConfiguration<ModeloBancada>
    {
        public void Configure(EntityTypeBuilder<ModeloBancada> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(250)");

            builder.Property(p => p.Descricao)
              .IsRequired()
              .HasColumnType("VARCHAR(250)");

            builder.Property(p => p.QuantidadePecas)
           .IsRequired()
           .HasColumnType("INT");

            builder.HasOne(p => p.Categoria);            

            builder.ToTable("ModelosBancadas");
        }
    }
}
