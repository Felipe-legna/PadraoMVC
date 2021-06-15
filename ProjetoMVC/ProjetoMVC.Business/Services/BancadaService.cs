using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Interfaces.BancadaBuilder;
using ProjetoMVC.Business.Models;
using ProjetoMVC.Business.Models.Enums;
using ProjetoMVC.Business.Services.BancadaBuilder;
using ProjetoMVC.Business.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMVC.Business.Services
{
    public class BancadaService : BaseService, IBancadaService
    {

        private readonly IBancadaRepository _contexto;
        private readonly IMaterialRepository _materialContexto;
        private readonly IBancadaReta _bancadaReta;
        private readonly IBancadaEmL _bancadaEmL;
        private readonly IBancadaEmU _bancadaEmU;
        private readonly IBancadaEmT _bancadaEmT;

        public BancadaService(IBancadaRepository contexto,
                                IMaterialRepository materialContexto,
                                IBancadaReta bancadaReta,
                                IBancadaEmL bancadaEmL,
                                IBancadaEmU bancadaEmU,
                                IBancadaEmT bancadaEmT,
                                INotificador notificador) : base(notificador)
        {
            _bancadaReta = bancadaReta;
            _bancadaEmL = bancadaEmL;
            _bancadaEmU = bancadaEmU;
            _bancadaEmT = bancadaEmT;
            _contexto = contexto;
            _materialContexto = materialContexto;
            //_enderecoRepository = enderecoRepository;
        }



        public Bancada DefinirTipoBancada(string categoria, string metodoCriacao, decimal frontao, decimal saia, List<Peca> pecas)
        {
            //Bancada bancada = null;
            Bancada bancada = new Bancada()
            {
                Frontao = frontao,
                Saia = saia,
                Pecas = pecas
            };

            switch (categoria)
            {
                case "Bancada Reta":
                    bancada = _bancadaReta.DefinirTipoBancada(metodoCriacao, bancada.Frontao, bancada.Saia, bancada.Pecas);
                    break;
                case "Bancada Em L":
                    bancada = _bancadaEmL.DefinirTipoBancada(bancada.ModeloBancada.Metodo, bancada.Frontao, bancada.Saia, bancada.Pecas);
                    break;
                case "Bancada Em T":
                    bancada = _bancadaEmT.DefinirTipoBancada(bancada.ModeloBancada.Metodo, bancada.Frontao, bancada.Saia, bancada.Pecas);
                    break;
                case "Bancada Em U":
                    bancada = _bancadaEmU.DefinirTipoBancada(bancada.ModeloBancada.Metodo, bancada.Frontao, bancada.Saia, bancada.Pecas);
                    break;
            }

            return bancada;
        }




        public async Task Adicionar(Bancada entity)
        {
            //Validar
            if (!ExecutarValidacao(new BancadaValidation(), entity)) return;
            //Executar
            await _contexto.Adicionar(entity);
        }

        public async Task Atualizar(Bancada entity)
        {
            //Validar
            if (!ExecutarValidacao(new BancadaValidation(), entity)) return;
            //Executar
            await _contexto.Atualizar(entity);
        }


        //public async Task AtualizarEndereco(Endereco endereco)
        //{
        //    if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

        //    await _enderecoRepository.Atualizar(endereco);
        //}


        public async Task Remover(Guid id)
        {
            //var endereco = await _enderecoRepository.ObterEnderecoPorProduto(id);

            //if (endereco != null)
            //{
            //    await _enderecoRepository.Remover(endereco.Id);
            //}

            await _contexto.Remover(id);
        }


        public async Task AdicionarMaterial(Material entity)
        {
            //Validar
            if (!ExecutarValidacao(new MaterialValidation(), entity)) return;
            //Executar
            await _materialContexto.Adicionar(entity);
        }

        public async Task AtualizarMaterial(Material entity)
        {
            //Validar
            if (!ExecutarValidacao(new MaterialValidation(), entity)) return;
            //Executar
            await _materialContexto.Atualizar(entity);
        }


        //public async Task AtualizarEndereco(Endereco endereco)
        //{
        //    if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

        //    await _enderecoRepository.Atualizar(endereco);
        //}


        public async Task RemoverMaterial(Guid id)
        {
            //var endereco = await _enderecoRepository.ObterEnderecoPorProduto(id);

            //if (endereco != null)
            //{
            //    await _enderecoRepository.Remover(endereco.Id);
            //}

            await _materialContexto.Remover(id);
        }
        public void Dispose()
        {
            //_enderecoRepository?.Dispose();
            _contexto?.Dispose();
            _materialContexto?.Dispose();
        }
    }
}