using ProjetoMVC.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoMVC.Data.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.ToTable("Clientes");

            builder.HasKey(p => p.Id);                                  

            builder.Property(c => c.Nome)
               .IsRequired()
               .HasColumnType("varchar(100)");           

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnType("CHAR(11)");

            //builder.HasOne(c => c.Endereco)
            //    .WithOne(e => e.Cliente);


            //builder.HasIndex(c => c.Telefone);

           
        }
    }
}
