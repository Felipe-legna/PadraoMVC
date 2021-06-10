using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Interfaces.BancadaBuilder
{
    public interface IBancadaEmL
    {
        Bancada DefinirTipoBancada(string metodoDeCriacao, decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmLComUmApoio(decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmLComUmApoioInvertido(decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmLComDoisApoios(decimal frontao, decimal saia, List<Peca> pecas);
    }
}
