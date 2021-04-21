using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Models;
using ProjetoMVC.Data.Context;
using ProjetoMVC.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ProjetoMvc.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProjetoMVCContext context) : base(context) { }

        public async Task<IPagedList<Produto>> ObterTodosPaginados(int? pagina, string pesquisa)
        {
            int numeroPagina = pagina ?? 1;

            var produtos = Db.Produtos.AsQueryable();

            if (!String.IsNullOrEmpty(pesquisa))
                produtos = produtos.Where(c => c.Nome.Contains(pesquisa));

            return await produtos.ToPagedListAsync(numeroPagina, QUANTIDADEPAGINA);

        }


        public async override Task<Produto> ObterPorId(Guid id)
        {

            return await DbSet.Include(c =>c.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
