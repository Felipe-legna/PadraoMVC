using ProjetoMVC.Business.Models;
using System.Threading.Tasks;
using X.PagedList;

namespace ProjetoMVC.Business.Interfaces
{
    public interface IClienteRepository :  IRepository<Cliente>
    {
        Task<IPagedList<Cliente>> ObterTodosPaginados(int? pagina, string pesquisa);
    }
}
