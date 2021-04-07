using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.App.Areas.Admin.ViewModel;
using ProjetoMVC.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class ClienteController : Controller
    {
      

        private readonly IClienteRepository _contexto;
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;

        public ClienteController(
          //  IClienteRepository clienteRepository,
          //  IMapper mapper
          //  , IClienteService clienteService
          )
        {
            //_mapper = mapper;
           // _contexto = clienteRepository;
            //_clienteService = clienteService;
        }

        [Route("Cliente/lista-de-clientes")]
        //public async Task<IActionResult> Index()
        public IActionResult Index()
        {
            //_mapper.Map<IEnumerable<ClienteViewModel>>(await _contexto.ObterTodos());
            return View();
        }
    }
}
