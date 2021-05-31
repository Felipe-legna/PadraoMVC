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
    public class BancadaRepository : Repository<Bancada>, IBancadaRepository
    {
        public BancadaRepository(ProjetoMVCContext context) : base(context) { }


        public async Task<IPagedList<Bancada>> ObterTodosPaginados(int? pagina, string pesquisa)
        {
            int numeroPagina = pagina ?? 1;

            var Bancadas = Db.Bancadas.AsQueryable();

            if (!String.IsNullOrEmpty(pesquisa))
                Bancadas = Bancadas.Where(c => c.Nome.Contains(pesquisa));

            return await Bancadas.ToPagedListAsync(numeroPagina, QUANTIDADEPAGINA);
        }


    }
}
