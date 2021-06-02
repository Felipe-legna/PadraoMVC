using ProjetoMVC.Business.Interfaces;
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
    public class ModeloBancadaService : BaseService, IModeloBancadaService
    {

        private readonly IModeloBancadaRepository _contexto;
        //private readonly IEnderecoRepository _enderecoRepository;

        public ModeloBancadaService(IModeloBancadaRepository contexto
            //,IEnderecoRepository enderecoRepository
            , INotificador notificador) : base(notificador)
        {
            _contexto = contexto;            
            //_enderecoRepository = enderecoRepository;
        }


       
        public async Task Adicionar(ModeloBancada entity)
        {
            //Validar
            if (!ExecutarValidacao(new ModeloBancadaValidation(), entity)) return;
            //Executar
            await _contexto.Adicionar(entity);
        }

        public async Task Atualizar(ModeloBancada entity)
        {
            //Validar
            if (!ExecutarValidacao(new ModeloBancadaValidation(), entity)) return;
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
        public void Dispose()
        {
            //_enderecoRepository?.Dispose();
            _contexto?.Dispose();
        }
    }
}