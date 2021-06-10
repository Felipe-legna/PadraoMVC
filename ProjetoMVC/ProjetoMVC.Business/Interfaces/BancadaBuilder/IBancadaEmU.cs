using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Interfaces.BancadaBuilder
{
    public interface IBancadaEmU
    {
        Bancada DefinirTipoBancada(string metodoDeCriacao, decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmUComUmApoio(decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmUComDoisApoios(decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmUComTresApoios(decimal frontao, decimal saia, List<Peca> pecas);
    }
}
