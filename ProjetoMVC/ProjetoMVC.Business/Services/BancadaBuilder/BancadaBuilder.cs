using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Models;
using ProjetoMVC.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC.Business.Services.BancadaBuilder
{
    public class BancadaBuilder : IBancadaBuilder
    {
        private readonly Bancada _bancada;
        private readonly List<Peca> _pecas;


        public BancadaBuilder()
        {
            _bancada = new Bancada();
            _pecas = new List<Peca>();
        }

        public IBancadaBuilder AdicionarFrontaoSaia(decimal frontao, decimal saia)
        {
            _bancada.Frontao = frontao;
            _bancada.Saia = saia;
            return this;
        }

        public IBancadaBuilder AdicionarPeca(Peca peca, Func<decimal, decimal> apoioLargura, Func<decimal, decimal> apoioComprimento)
        {
            var totalLarguraPeca = apoioLargura(peca.Largura);
            var totalComprimentoPeca = apoioComprimento(peca.Comprimento);

            var novaPeca = new Peca()
            {
                Largura = peca.Largura,
                TotalLarguraPeca = totalLarguraPeca,
                Comprimento = peca.Comprimento,
                TotalComprimentoPeca = totalComprimentoPeca
            };

            if (peca.AlturaDaBase > 0)
            {
                if (peca.Base == TipoBase.SemConexaoLateral) novaPeca.TotalComprimentoPeca += AddBaseSemConexaoLateral(peca);
                if (peca.Base == TipoBase.ConexaoUmaLateral) novaPeca.TotalComprimentoPeca += AddApoioUmaLateral(peca);
                if (peca.Base == TipoBase.conexaoDuasLaterais) novaPeca.TotalComprimentoPeca += AddApoioDuasLaterais(peca);

                //Se tem base é necessário remover uma saia
                novaPeca.TotalLarguraPeca -= _bancada.Saia;
            }

            if (peca.ComprimentoFogaoEmbutido > 0)
            {
                novaPeca.MetroQuadradoPeca = AdicionarLarguraFogao(peca);
            }

            _pecas.Add(novaPeca);

            return this;
        }

        public decimal AdicionarLarguraFogao(Peca peca)
        {
            //apenas para encaixar o fogão foi adicionado 2 cm 
            return (peca.ComprimentoFogaoEmbutido + 0.02M) * _bancada.Frontao;
        }

        public decimal AddSemApoio(decimal medida)
        {
            return (_bancada.Saia * 2) + medida;
        }

        public decimal AddApoioUmaParede(decimal medida)
        {
            return _bancada.Frontao + _bancada.Saia + medida;
        }

        public decimal AddApoioDuasParedes(decimal medida)
        {
            return (_bancada.Frontao * 2) + medida;
        }

        public decimal AddApoioOutraPeca(decimal medida)
        {
            return _bancada.Saia + medida;
        }

        private decimal AddBaseSemConexaoLateral(Peca peca)
        {
            return peca.AlturaDaBase + (_bancada.Saia * 2);
        }

        private decimal AddApoioUmaLateral(Peca peca)
        {
            return peca.AlturaDaBase + (_bancada.Saia);
        }

        private decimal AddApoioDuasLaterais(Peca peca)
        {
            return peca.AlturaDaBase;
        }

        private decimal CalculaMetroQuadrado(Peca peca)
        {
            return peca.MetroQuadradoPeca += peca.TotalLarguraPeca * peca.TotalComprimentoPeca;
        }

        public Bancada ObterBancada()
        {
            foreach (var peca in _pecas)
            {
                _bancada.MetroQuadrado += CalculaMetroQuadrado(peca);
            }
            _bancada.Pecas = _pecas;
            return _bancada;
        }

    }
}
