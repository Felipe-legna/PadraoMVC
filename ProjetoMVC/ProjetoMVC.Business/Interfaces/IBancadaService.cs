using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoMVC.Business.Interfaces
{
    public interface IBancadaService : IBaseService<Bancada>
    {
        //Task AtualizarEndereco(Endereco endereco);
        Bancada DefinirTipoBancada(string categoria, string metodoCriacao, decimal frontao, decimal saia, List<Peca> pecas);

        Task AdicionarMaterial(Material entity);

        Task AtualizarMaterial(Material entity);

        Task RemoverMaterial(Guid id);

        Task<decimal> CalcularValorBancada(Guid materialId, decimal metroQuadrado);
    }
}
