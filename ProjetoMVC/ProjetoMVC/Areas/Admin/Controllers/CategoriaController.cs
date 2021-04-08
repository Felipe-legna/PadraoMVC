using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.App.Areas.Admin.ViewModels;
using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Categoria/")]
    public class CategoriaController : Controller
    {

        private readonly ICategoriaRepository _contexto;
        private readonly IMapper _mapper;
        private readonly ICategoriaService _clienteService;

        public CategoriaController(
            ICategoriaRepository clienteRepository,
            IMapper mapper
            , ICategoriaService clienteService)
        {
            _mapper = mapper;
            _contexto = clienteRepository;
            _clienteService = clienteService;
        }

        [Route("lista-de-categorias")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CategoriaViewModel>>(await _contexto.ObterTodos()));
        }

        [Route("dados-da-categoria/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var clienteViewModel = _mapper.Map<CategoriaViewModel>(await _contexto.ObterPorId(id));

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }


        [Route("nova-categoria")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("nova-categoria")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            //Criação vai ser pela classe de serviço.
            var cliente = _mapper.Map<Categoria>(clienteViewModel);

            await _clienteService.Adicionar(cliente);

            return RedirectToAction("Index");
        }

        [Route("editar-categoria/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var clienteViewModel = _mapper.Map<CategoriaViewModel>(await _contexto.ObterPorId(id));

            if (clienteViewModel == null) return NotFound();

            return View(clienteViewModel);
        }

        [Route("editar-categoria/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CategoriaViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = _mapper.Map<Categoria>(clienteViewModel);
            await _clienteService.Atualizar(cliente);


            return RedirectToAction("Index");
        }

        [Route("excluir-categoria/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteViewModel = _mapper.Map<CategoriaViewModel>(await _contexto.ObterPorId(id));

            if (clienteViewModel == null) return NotFound();

            return View(clienteViewModel);
        }

        [Route("excluir-categoria/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var clienteViewModel = _mapper.Map<CategoriaViewModel>(await _contexto.ObterPorId(id));

            if (clienteViewModel == null) return NotFound();

            await _clienteService.Remover(id);

            return RedirectToAction("Index");
        }

    }
}
