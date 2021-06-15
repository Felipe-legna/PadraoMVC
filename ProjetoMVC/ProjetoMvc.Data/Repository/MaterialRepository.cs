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
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(ProjetoMVCContext context) : base(context) { }

        public async Task<IPagedList<Material>> ObterTodosPaginados(int? pagina, string pesquisa)
        {
            int numeroPagina = pagina ?? 1;

            var materiais = Db.Materiais.AsQueryable();

            if (!String.IsNullOrEmpty(pesquisa))
                materiais = materiais.Where(c => c.Nome.Contains(pesquisa));

            return await materiais.ToPagedListAsync(numeroPagina, QUANTIDADEPAGINA);

        }


        public async override Task<Material> ObterPorId(Guid id)
        {

            return await DbSet.Include(c =>c.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
