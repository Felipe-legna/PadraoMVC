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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ProjetoMVCContext context) : base(context) { }


        public async Task<IPagedList<Categoria>> ObterTodosPaginados(int? pagina, string pesquisa)
        {
            int numeroPagina = pagina ?? 1;

            var categorias = Db.Categorias.AsQueryable();

            if (!String.IsNullOrEmpty(pesquisa))
                categorias = categorias.Where(c => c.Nome.Contains(pesquisa));

            return await categorias.ToPagedListAsync(numeroPagina, QUANTIDADEPAGINA);

        }



    }
}
