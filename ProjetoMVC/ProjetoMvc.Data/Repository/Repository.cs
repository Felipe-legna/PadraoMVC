using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Models;
using ProjetoMVC.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMVC.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ProjetoMVCContext Db;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(ProjetoMVCContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
           
        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);            
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
          
            await SaveChanges();
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }
                
        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        //salva alteracoes do contexto
        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            //Verifica se já foi feito o dispose, caso contrário executa. 
            Db?.Dispose();
        }

    }
}
