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

        //public async Task<Cliente> ObterClienteEnderecos(Guid id)
        //{
        //    return await Db.Clientes.Include(c => c.Endereco)
        //        .FirstOrDefaultAsync(c => c.Id == id);            
        //}

      
    }
}
