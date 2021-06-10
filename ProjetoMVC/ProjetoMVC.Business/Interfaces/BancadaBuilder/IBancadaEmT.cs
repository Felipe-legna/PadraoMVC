using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Interfaces.BancadaBuilder
{
    public interface IBancadaEmT
    {
        Bancada DefinirTipoBancada(string metodoDeCriacao, decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmTUmApoio(decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmTDoisApoio(decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmTTrêsApoio(decimal frontao, decimal saia, List<Peca> pecas);
    }
}
