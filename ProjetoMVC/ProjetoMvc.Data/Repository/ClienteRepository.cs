using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Models;
using ProjetoMVC.Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace ProjetoMVC.Data.Repository
{
    //Repositorio padrao, Repositorio especifico
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ProjetoMVCContext context) : base(context) { }

        public  async  Task<IPagedList<Cliente>> ObterTodosPaginados(int? pagina, string pesquisa)
        {
            int numeroPagina = pagina ?? 1;

            var clientes = Db.Clientes.AsQueryable();

            if (!String.IsNullOrEmpty(pesquisa))
                clientes = clientes.Where(c => c.Nome.Contains(pesquisa) || c.Telefone.Contains(pesquisa));

            return await clientes.ToPagedListAsync(numeroPagina, QUANTIDADEPAGINA);

        }

    }
}
