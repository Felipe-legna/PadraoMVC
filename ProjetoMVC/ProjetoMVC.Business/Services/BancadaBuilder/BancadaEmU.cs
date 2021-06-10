using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Interfaces.BancadaBuilder;
using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjetoMVC.Business.Services.BancadaBuilder
{
    public class BancadaEmU : IBancadaEmU
    {
       
        private readonly IBancadaBuilder _bancada;
        public BancadaEmU(IBancadaBuilder bancada)
        {
            _bancada = bancada;
        }

        public Bancada DefinirTipoBancada(string metodoDeCriacao, decimal frontao, decimal saia, List<Peca> pecas)
        {

            Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(metodoDeCriacao);
            return (Bancada)theMethod.Invoke(this, new object[] { frontao, saia, pecas });
        }



        public Bancada CriarBancadaEmUComUmApoio(decimal frontao, decimal saia, List<Peca> pecas)
        {
            if (pecas.Count == 3)
            {
                _bancada.AdicionarFrontaoSaia(frontao, saia)
                                    .AdicionarPeca(pecas[0], _bancada.AddApoioUmaParede, _bancada.AddSemApoio)
                                    .AdicionarPeca(pecas[1], _bancada.AddSemApoio, _bancada.AddApoioOutraPeca)
                                    .AdicionarPeca(pecas[2], _bancada.AddSemApoio, _bancada.AddApoioOutraPeca);
            }

            return _bancada.ObterBancada();
        }


        public Bancada CriarBancadaEmUComDoisApoios(decimal frontao, decimal saia, List<Peca> pecas)
        {
            if (pecas.Count == 3)
            {
                _bancada.AdicionarFrontaoSaia(frontao, saia)
                                    .AdicionarPeca(pecas[0], _bancada.AddApoioUmaParede, _bancada.AddApoioUmaParede)
                                    .AdicionarPeca(pecas[1], _bancada.AddApoioUmaParede, _bancada.AddApoioOutraPeca)
                                    .AdicionarPeca(pecas[2], _bancada.AddSemApoio, _bancada.AddApoioOutraPeca);
            }

            return _bancada.ObterBancada();
        }

        public Bancada CriarBancadaEmUComTresApoios(decimal frontao, decimal saia, List<Peca> pecas)
        {
            if (pecas.Count == 3)
            {
                _bancada.AdicionarFrontaoSaia(frontao, saia)
                                    .AdicionarPeca(pecas[0], _bancada.AddApoioUmaParede, _bancada.AddApoioDuasParedes)
                                    .AdicionarPeca(pecas[1], _bancada.AddApoioUmaParede, _bancada.AddApoioOutraPeca)
                                    .AdicionarPeca(pecas[2], _bancada.AddApoioUmaParede, _bancada.AddApoioOutraPeca);
            }

            return _bancada.ObterBancada();
        }
    }
}
