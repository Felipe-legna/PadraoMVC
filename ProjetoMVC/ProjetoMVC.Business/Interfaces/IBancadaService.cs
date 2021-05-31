using ProjetoMVC.Business.Models;

namespace ProjetoMVC.Business.Interfaces
{
    public interface IBancadaService : IBaseService<Bancada>
    {
        //Task AtualizarEndereco(Endereco endereco);
        Bancada DefinirTipoBancada(Categoria categoria, string metodoCriacao);
    }
}
