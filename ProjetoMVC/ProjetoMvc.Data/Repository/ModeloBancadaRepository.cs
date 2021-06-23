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
    public class ModeloBancadaRepository : Repository<ModeloBancada>, IModeloBancadaRepository
    {
        public ModeloBancadaRepository(ProjetoMVCContext context) : base(context) { }


        public async Task<IPagedList<ModeloBancada>> ObterTodosPaginados(int? pagina, string pesquisa)
        {
            int numeroPagina = pagina ?? 1;

            //var Bancadas = Db.ModelosBancadas.Include(c => c.Categoria).ToPagedListAsync(numeroPagina, QUANTIDADEPAGINA).AsQueryable();

            //if (!String.IsNullOrEmpty(pesquisa))
            //    Bancadas = Bancadas.Where(c => c.Nome.Contains(pesquisa));

            return await Db.ModelosBancadas.Include(c => c.Categoria).ToPagedListAsync(numeroPagina, QUANTIDADEPAGINA);
        }


        public override async Task<ModeloBancada> ObterPorId(Guid id)
        {
            return await Db.ModelosBancadas.Include(c => c.Categoria).FirstOrDefaultAsync(mb => mb.Id == id);
        }

    }
}
