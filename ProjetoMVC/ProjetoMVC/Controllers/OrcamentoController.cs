using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Models;
using ProjetoMVC.Site.lib.orcamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.Controllers
{
    public class OrcamentoController : Controller
    {
        private readonly CookieOrcamento _cookieOrcamento;
        private readonly IClienteRepository _contextoCliente;
        private readonly IProdutoRepository _contextoProduto;
        private readonly IModeloBancadaRepository _contextoModeloBancada;
        private readonly IMapper _mapper;
        public OrcamentoController(CookieOrcamento cookieOrcamento,
            IClienteRepository contextoCliente,
            IProdutoRepository contexto,
            IModeloBancadaRepository contextoModeloBancada,
            IMapper mapper) 
        {

            _cookieOrcamento = cookieOrcamento;
            _contextoCliente = contextoCliente;
            _contextoProduto = contexto;
            _contextoModeloBancada = contextoModeloBancada;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            //List<ProdutoItem> produtoItemCompleto = CarregarProdutoDB();

            //return View(produtoItemCompleto);

            List<ProdutoItem> produtosOrcamento = _cookieOrcamento.Consultar();
            
            
            string cliente = _cookieOrcamento.Consultar("cliente");
            List<Bancada> bancadas = JsonConvert.DeserializeObject<List<Bancada>>(_cookieOrcamento.Consultar("bancada"));

           

            return View(produtosOrcamento);
        }


        //cliente ID 
        public async Task<IActionResult> AdicionarCliente(Guid id)
        {
            Cliente cliente = await _contextoCliente.ObterPorId(id);

            if (cliente == null)
            {
                return View("NaoExisteItem");
            }
            else
            {
                var item = new Cliente() { Id = id };
                _cookieOrcamento.CadastrarCliente(item);

                return RedirectToAction("lista-de-modelos-de-bancadas", "Home");               
            }
        }

        public async Task<IActionResult> AdicionarBancada(Guid id, Guid materialId, decimal metroQuadrado, decimal valorTotal)
        {
            var modelo = await _contextoModeloBancada.ObterPorId(id);

            if (modelo == null)
            {
                return View("NaoExisteItem");
            }
            else
            {
                var item = new Bancada() { Id = id, MaterialId = materialId, MetroQuadrado = metroQuadrado, Valor =  valorTotal };
                _cookieOrcamento.CadastrarBancada(item);

                return RedirectToAction("lista-de-produtos", "Home");
            }
        }


        //Item ID = ID Produto
        public async Task<IActionResult> AdicionarItem(Guid id)
        {
            Produto produto = await _contextoProduto.ObterPorId(id);

            if (produto == null)
            {
                return View("NaoExisteItem");
            }
            else
            {
                var item = new ProdutoItem() { Id = id, QuantidadeProdutoCarrinho = 1 };
                _cookieOrcamento.Cadastrar(item);

                return RedirectToAction("lista-de-produtos", "Home");
                //return RedirectToAction(nameof(Index));
            }
        }

       

        public async Task<IActionResult> AlterarQuantidade(Guid id, int quantidade)
        {
            Produto produto = await _contextoProduto.ObterPorId(id);
            if (quantidade < 1)
            {
                return BadRequest(new { mensagem = "" });
            }
            else if (quantidade > produto.Quantidade)
            {
                return BadRequest(new { mensagem = "" });
            }
            else
            {
                var item = new ProdutoItem() { Id = id, QuantidadeProdutoCarrinho = quantidade };
                _cookieOrcamento.Atualizar(item);
                return Ok(new { mensagem = "" });
            }
        }
        public IActionResult RemoverItem(Guid id)
        {
            _cookieOrcamento.Remover(new ProdutoItem() { Id = id });
            return RedirectToAction(nameof(Index));
        }

        

        
    }
}
