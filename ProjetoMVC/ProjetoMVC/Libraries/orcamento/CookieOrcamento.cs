﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Models;
using ProjetoMVC.wwwroot.lib.cookie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.Site.lib.orcamento
{
    public class CookieOrcamento : ICookieOrcamento 
    {
        private readonly string Key = "Orcamento";
        private readonly Cookie _cookie;

        public CookieOrcamento(Cookie cookie)
        {
            _cookie = cookie;
        }

        /*
         * CRUD - Cadastrar, Read, Update, Delete
         * Adicionar Item, Remover Item, Alterar Quantidade
         */
        public void Cadastrar(ProdutoItem item)
        {
            List<ProdutoItem> Lista;
            if (_cookie.Existe(Key))
            {
                Lista = Consultar();
                var ItemLocalizado = Lista.SingleOrDefault(a => a.Id == item.Id);

                if (ItemLocalizado == null)
                {
                    Lista.Add(item);
                }
                else
                {
                    ItemLocalizado.QuantidadeProdutoCarrinho++;
                }
            }
            else
            {
                Lista = new List<ProdutoItem>();
                Lista.Add(item);
            }

            Salvar(Lista);
        }


        // Usado no cliente
        public void CadastrarCliente(Cliente item)
        {
           
            if (_cookie.Existe("cliente"))
            {
                Atualizar("cliente", item.Id.ToString());                
            }
            else
            {
                Salvar("cliente", item.Id.ToString());
            }
            
        }

        public void CadastrarBancada(Bancada item)
        {

            List<Bancada> Lista;
            if (_cookie.Existe("bancada"))
            {
                Lista = JsonConvert.DeserializeObject<List<Bancada>>(Consultar("bancada"));
                var ItemLocalizado = Lista.SingleOrDefault(a => a.Id == item.Id);

                if (ItemLocalizado == null)
                {
                    Lista.Add(item);
                }
               
            }
            else
            {
                Lista = new List<Bancada>();
                Lista.Add(item);
            }


            Salvar("bancada", JsonConvert.SerializeObject(Lista));            
        }



        public void Atualizar(string key, string valor)
        {
            _cookie.Atualizar(key, valor);
        }

        public void Atualizar(ProdutoItem item)
        {
            var Lista = Consultar();
            var ItemLocalizado = Lista.SingleOrDefault(a => a.Id == item.Id);

            if (ItemLocalizado != null)
            {
                ItemLocalizado.QuantidadeProdutoCarrinho = item.QuantidadeProdutoCarrinho;
                Salvar(Lista);
            }
        }
        public void Remover(ProdutoItem item)
        {
            var Lista = Consultar();
            var ItemLocalizado = Lista.SingleOrDefault(a => a.Id == item.Id);

            if (ItemLocalizado != null)
            {
                Lista.Remove(ItemLocalizado);
                Salvar(Lista);
            }
        }


        public string Consultar(string key)
        {
            if (_cookie.Existe(key))
            {
                string valor = _cookie.Consultar(key);
                return valor;
            }
            else
            {
                return "Não definido";
            }          
        }
        public List<ProdutoItem> Consultar()
        {
            if (_cookie.Existe(Key))
            {
                string valor = _cookie.Consultar(Key);
                return JsonConvert.DeserializeObject<List<ProdutoItem>>(valor);
            }
            else
            {
                return new List<ProdutoItem>();
            }
        }

        public void Salvar(string key, string valor)
        {          
            _cookie.Cadastrar(key, valor);
        }
        public void Salvar(List<ProdutoItem> Lista)
        {
            string Valor = JsonConvert.SerializeObject(Lista);
            _cookie.Cadastrar(Key, Valor);
        }

        
        public bool Existe(string Key)
        {
            if (_cookie.Existe(Key))
            {
                return false;
            }

            return true;
        }
        public void RemoverTodos()
        {
            _cookie.Remover(Key);
        }

    }
}

