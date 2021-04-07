using ProjetoMVC.Business.Models;
using System;
using System.Threading.Tasks;

namespace ProjetoMVC.Business.Interfaces
{
    public interface IBaseService<TEntity> : IDisposable where TEntity: Entity
    {
        Task Adicionar(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Remover(Guid Id);

    }
}
