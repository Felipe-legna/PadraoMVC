using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Models;
using ProjetoMVC.Data.Context;
using ProjetoMVC.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ProjetoMvc.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ProjetoMVCContext context) : base(context) { }

      


        public async override Task<IPagedList<Categoria>> ObterTodosPaginados(int? pagina)
        {
            int numeroPagina = pagina ?? 1;
            return await DbSet.Include(c => c.CategoriaPai).ToPagedListAsync(numeroPagina, QUANTIDADEPAGINA);
        }
      


    }
}
