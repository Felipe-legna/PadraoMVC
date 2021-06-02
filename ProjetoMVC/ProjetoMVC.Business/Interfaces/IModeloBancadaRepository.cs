using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ProjetoMVC.Business.Interfaces
{
    public interface IModeloBancadaRepository : IRepository<ModeloBancada>
    {
        Task<IPagedList<ModeloBancada>> ObterTodosPaginados(int? pagina, string pesquisa);
    }
}
