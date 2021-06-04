using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.App.Areas.Admin.ViewModels;

using ProjetoMVC.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace ProjetoMVC.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly IClienteRepository _clienteContexto;
        private readonly IProdutoRepository _produtoContexto;        
        private readonly IModeloBancadaRepository _modeloBancadaRepository;
        private readonly ICategoriaRepository _categoriaContexto;
        private readonly IMapper _mapper;

        public HomeController( IClienteRepository clienteContexto,
                               IProdutoRepository produtoContexto,
                               IModeloBancadaRepository modeloBancadaRepository,
                               ICategoriaRepository categoriaContexto,
                               IMapper mapper)
        {
            _clienteContexto = clienteContexto;
            _produtoContexto = produtoContexto;
            _modeloBancadaRepository = modeloBancadaRepository;
            _categoriaContexto = categoriaContexto;
            _mapper = mapper;

        }


        [Route("lista-de-clientes")]
        public async Task<IActionResult> ListaDeClientes(int? pagina, string pesquisa)
        {
            IPagedList dadosPaginados = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteContexto.ObterTodosPaginados(pagina, pesquisa)).ToPagedList();
            return View(dadosPaginados);
        }


        [Route("lista-de-produtos")]
        public async Task<IActionResult> ListaDeProdutos(int? pagina, string pesquisa)
        {
            IPagedList dadosPaginados = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoContexto.ObterTodosPaginados(pagina, pesquisa)).ToPagedList();
            return View(dadosPaginados);
        }
                       

        [Route("lista-de-modelos-de-bancadas")]
        public async Task<IActionResult> ListaDeModelosBancadas(int? pagina, string pesquisa)
        {
            IPagedList dadosPaginados = _mapper.Map<IEnumerable<ModeloBancadaViewModel>>(await _modeloBancadaRepository.ObterTodosPaginados(pagina, pesquisa)).ToPagedList();
            return View(dadosPaginados);
        }

    }
}
