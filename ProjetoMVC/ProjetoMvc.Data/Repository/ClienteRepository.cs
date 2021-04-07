using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Models;
using ProjetoMVC.Data.Context;

namespace ProjetoMVC.Data.Repository
{
    //Repositorio padrao, Repositorio especifico
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ProjetoMVCContext context) : base (context) {}
        //public async Task<Cliente> ObterClienteEnderecos(Guid id)
        //{
        //    return await Db.Clientes.Include(c => c.Endereco)
        //        .FirstOrDefaultAsync(c => c.Id == id);            
        //}

    }
}
