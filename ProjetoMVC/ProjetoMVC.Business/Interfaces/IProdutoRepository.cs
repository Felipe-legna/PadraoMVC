using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ProjetoMVC.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IPagedList<Produto>> ObterTodosPaginados(int? pagina, string pesquisa);
    }
}
