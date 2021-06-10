using ProjetoMVC.Business.Models;
using System.Collections.Generic;

namespace ProjetoMVC.Business.Interfaces
{
    public interface IBancadaService : IBaseService<Bancada>
    {
        //Task AtualizarEndereco(Endereco endereco);
        Bancada DefinirTipoBancada(string categoria, string metodoCriacao, decimal frontao, decimal saia, List<Peca> pecas);
    }
}
