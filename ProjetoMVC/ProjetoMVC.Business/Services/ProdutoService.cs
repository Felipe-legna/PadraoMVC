﻿using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Models;
using ProjetoMVC.Business.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMVC.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _clienteRepository;
        //private readonly IEnderecoRepository _enderecoRepository;

        public ProdutoService(IProdutoRepository clienteRepository
            //,IEnderecoRepository enderecoRepository
            , INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            //_enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Produto entity)
        {
            //Validar
            if (!ExecutarValidacao(new ProdutoValidation(), entity)) return;
            //Executar
            await _clienteRepository.Adicionar(entity);
        }

        public async Task Atualizar(Produto entity)
        {
            //Validar
            if (!ExecutarValidacao(new ProdutoValidation(), entity)) return;
            //Executar
            await _clienteRepository.Atualizar(entity);
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

            await _clienteRepository.Remover(id);
        }
        public void Dispose()
        {
            //_enderecoRepository?.Dispose();
            _clienteRepository?.Dispose();
        }
    }
}