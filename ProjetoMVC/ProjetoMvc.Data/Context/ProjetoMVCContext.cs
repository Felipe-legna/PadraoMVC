using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Business.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoMVC.Data.Context
{
    public class ProjetoMVCContext : DbContext
    {
        public ProjetoMVCContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
                
        
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Para as propriedades do tipo string que não tiverem definidas, serão iniciadas no banco em um coluna com tamnho 100
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("VARCHAR(100)");

            //pega todas as classes do ProjetoMVCContext e verifica classes que herdem de IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjetoMVCContext).Assembly);

            //Bloqueando a exclusão em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
       
       public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
       {
           foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
           {
               if (entry.State == EntityState.Added)
               {
                   entry.Property("DataCadastro").CurrentValue = DateTime.Now;
               }

               if (entry.State == EntityState.Modified)
               {
                   entry.Property("DataCadastro").IsModified = false;
               }
           }

           return base.SaveChangesAsync(cancellationToken);
       }
       
    }
}
