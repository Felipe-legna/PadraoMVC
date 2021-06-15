using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Interfaces.BancadaBuilder
{
    public interface IBancadaReta
    {
        public Bancada DefinirTipoBancada(string metodoDeCriacao, decimal frontao, decimal saia, List<Peca> pecas);
        public Bancada CriarBancadaRetaUmApoio(decimal frontao, decimal saia, List<Peca> pecas);
        public Bancada CriarBancadaRetaDoisApoios(decimal frontao, decimal saia, List<Peca> pecas);
        public Bancada CriarBancadaRetaTresApoios(decimal frontao, decimal saia, List<Peca> pecas);
    }
}
