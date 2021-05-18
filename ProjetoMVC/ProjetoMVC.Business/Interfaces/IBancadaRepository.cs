using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ProjetoMVC.Business.Interfaces
{
    public interface IBancadaRepository : IRepository<Bancada>
    {
        Task<IPagedList<Bancada>> ObterTodosPaginados(int? pagina, string pesquisa);
    }
}
