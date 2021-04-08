using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.App.Areas.Admin.ViewModels;
using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace ProjetoMVC.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Cliente/")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _contexto;
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;

        public ClienteController(
            IClienteRepository clienteRepository,
            IMapper mapper
            , IClienteService clienteService)
        {
            _mapper = mapper;
            _contexto = clienteRepository;
            _clienteService = clienteService;

        }

        [Route("lista-de-clientes")]
        public async Task<IActionResult> Index(int? pagina)
        {
            IPagedList dadosPaginados = _mapper.Map<IEnumerable<ClienteViewModel>>(await _contexto.ObterTodosPaginados(pagina)).ToPagedList();
            return View(dadosPaginados);
        }

        [Route("dados-do-cliente/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _contexto.ObterPorId(id));

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }


        [Route("novo-cliente")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-cliente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            //Criação vai ser pela classe de serviço.
            var cliente = _mapper.Map<Cliente>(clienteViewModel);

            await _clienteService.Adicionar(cliente);

            return RedirectToAction("Index");
        }

        [Route("editar-cliente/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _contexto.ObterPorId(id)); 

            if (clienteViewModel == null) return NotFound();

            return View(clienteViewModel);
        }

        [Route("editar-cliente/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            await _clienteService.Atualizar(cliente);


            return RedirectToAction("Index");
        }

        [Route("excluir-cliente/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _contexto.ObterPorId(id)); 

            if (clienteViewModel == null) return NotFound();

            return View(clienteViewModel);
        }

        [Route("excluir-cliente/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _contexto.ObterPorId(id));

            if (clienteViewModel == null) return NotFound();

            await _clienteService.Remover(id);

            return RedirectToAction("Index");
        }



        //[Route("obter-endereco-cliente/{id:guid}")]
        //public async Task<IActionResult> ObterEndereco(Guid id)
        //{
        //    var cliente = await ObterClienteEnderecos(id);

        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    return PartialView("_DetalhesEndereco", cliente);
        //}

        //[Route("atualizar-endereco-cliente/{id:guid}")]
        //public async Task<IActionResult> AtualizarEndereco(Guid id)
        //{
        //    var cliente = await ObterClienteEnderecos(id);

        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    return PartialView("_DetalhesEndereco", new ClienteViewModel { Endereco = cliente.Endereco });
        //}


        //[Route("atualizar-endereco-cliente/{id:guid}")]
        //[HttpPost]
        //public async Task<IActionResult> AtualizarEndereco(ClienteViewModel ClienteViewModel)
        //{
        //    ModelState.Remove("Nome");
        //    ModelState.Remove("Documento");
        //    ModelState.Remove("Telefone");

        //    if (!ModelState.IsValid) return PartialView("_AtualizarEndereco", ClienteViewModel);

        //    await _clienteService.AtualizarEndereco(_mapper.Map<Endereco>(ClienteViewModel.Endereco));

        //    //if (!OperacaoValida()) return PartialView("_AtualizarEndereco", ClienteViewModel);

        //    var url = Url.Action("ObterClienteEnderecos", "Clientes", new { id = ClienteViewModel.Endereco.ClienteId });
        //    return Json(new { success = true, url });
        //}


        //[Route("atualizar-endereco-cliente/{id:guid}")]
        //[HttpPost]
        //public async Task<IActionResult> AtualizarEndereco(ClienteViewModel clienteViewModel)
        //{
        //    ModelState.Remove("Nome");
        //    ModelState.Remove("Documento");
        //    ModelState.Remove("Telefone");

        //    if (!ModelState.IsValid) return PartialView("_DetalhesEndereco", clienteViewModel);

        //    await _clienteService.AtualizarEndereco(_mapper.Map<Endereco>(clienteViewModel.Endereco));

        //    //if (!OperacaoValida()) return PartialView("_AtualizarEndereco", clienteViewModel);

        //    var url = Url.Action("ObterEndereco", "Clientes", new { id = clienteViewModel.Endereco.ClienteId });
        //    return Json(new { success = true, url });
        //}


        //private async Task<ClienteViewModel> ObterClienteEnderecos(Guid id)
        //{
        //    return _mapper.Map<ClienteViewModel>(await _contexto.ObterClienteEnderecos(id));
        //}
    }
}
