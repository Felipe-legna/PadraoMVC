using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.App.Areas.Admin.ViewModels;

using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace ProjetoMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Bancada/")]
    public class BancadaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBancadaRepository _contexto;
        private readonly IBancadaService _bancadaService;
        private readonly ICategoriaRepository _categoriaRepository;
        public BancadaController(IMapper mapper,
                                 IBancadaRepository bancadaRepository,
                                    IBancadaService bancadaService,
                                    ICategoriaRepository categoriaRepository
            )
        {
            _mapper = mapper;
            _contexto = bancadaRepository;
            _bancadaService = bancadaService;
            _categoriaRepository = categoriaRepository;
        }

        [Route("lista-de-bancadas")]
        public async Task<IActionResult> Index(int? pagina, string pesquisa)
        {
            IPagedList dadosPaginados = _mapper.Map<IEnumerable<BancadaViewModel>>(await _contexto.ObterTodosPaginados(pagina, pesquisa)).ToPagedList();

            return View(_mapper.Map<IEnumerable<BancadaViewModel>>(await _contexto.ObterTodos()));
        }


        [Route("dados-da-bancada/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var modeloViewModel = _mapper.Map<BancadaViewModel>(await _contexto.ObterPorId(id));

            if (modeloViewModel == null)
            {
                return NotFound();
            }

            return View(modeloViewModel);
        }

        [Route("nova-bancada")]
        public async Task<IActionResult> Create()
        {
            //ViewBag.TiposBancadas = _bancadaService.ObterTiposBancadas();
            ViewBag.Categorias = _mapper.Map<List<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());
            return View();
        }

        [Route("nova-bancada")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BancadaViewModel modeloViewModel)
        {
            if (!ModelState.IsValid) return View(modeloViewModel);

            //Criação vai ser pela classe de serviço.
            var modelo = _mapper.Map<Bancada>(modeloViewModel);

            //var imgPrefixo = Guid.NewGuid() + "_";
            //if (!await UploadArquivo(modeloViewModel.ImagemUpload, imgPrefixo))
            //{
            //    return View(modeloViewModel);
            //}

            //modelo.Imagem = imgPrefixo + modeloViewModel.ImagemUpload.FileName;
            ////modelo.Categoria += 1;
            //await _bancadaService.Adicionar(modelo);

            return RedirectToAction("Index");
        }

        [Route("editar-bancada/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var modeloViewModel = _mapper.Map<BancadaViewModel>(await _contexto.ObterPorId(id));

            if (modeloViewModel == null) return NotFound();

            return View(modeloViewModel);
        }


        [Route("editar-bancada/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Categoria,Frontao,Saia,Metodo,Imagem,QuantidadePecas,MetroQuadrado")] BancadaViewModel modeloViewModel)
        {
            if (id != modeloViewModel.Id) return NotFound();

            //var modeloAtualizacao = await _contexto.ObterPorId(id);
            //modeloViewModel.Imagem = modeloAtualizacao.Imagem;
            //if (!ModelState.IsValid) return View(modeloViewModel);

            //if (modeloViewModel.ImagemUpload != null)
            //{
            //    var imgPrefixo = Guid.NewGuid() + "_";
            //    if (!await UploadArquivo(modeloViewModel.ImagemUpload, imgPrefixo))
            //    {
            //        return View(modeloViewModel);
            //    }

            //    modeloAtualizacao.Imagem = imgPrefixo + modeloViewModel.ImagemUpload.FileName;
            //}


            ////modeloAtualizacao.QuantidadePecas = modeloViewModel.QuantidadePecas;



            //await _contexto.Atualizar(_mapper.Map<Bancada>(modeloAtualizacao));


            return RedirectToAction("Index");
        }

        [Route("excluir-bancada/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var modeloViewModel = _mapper.Map<BancadaViewModel>(await _contexto.ObterPorId(id));

            if (modeloViewModel == null) return NotFound();

            return View(modeloViewModel);
        }

        [Route("excluir-bancada/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var modeloViewModel = _mapper.Map<BancadaViewModel>(await _contexto.ObterPorId(id));

            if (modeloViewModel == null) return NotFound();

            await _contexto.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }

        [Route("adicionar-bancada/{id:Guid}")]
        [HttpPost]
        public async Task<IActionResult> AdicionarBancada(BancadaViewModel bancadaViewModel, Guid id)
        {


            var modeloBancada = _mapper.Map<BancadaViewModel>(await _contexto.ObterPorId(id));


            //bancadaViewModel.Metodo = modeloBancada.Metodo;
            //var pecas = _mapper.Map<List<Peca>>(bancadaViewModel.Pecas);


            Bancada bancada = new Bancada
            {
                //Nome = modeloBancada.Nome,
                //Descricao = modeloBancada.Descricao,
                Frontao = bancadaViewModel.Frontao,
                Saia = bancadaViewModel.Saia,
                //Pecas = _mapper.Map<List<Peca>>(bancadaViewModel.Pecas),
                //QuantidadePecas = bancadaViewModel.QuantidadePecas
            };
            //bancada.Pecas = new List<Peca>();
            //foreach (var p in bancadaViewModel.Pecas)
            //{
            //    bancada.Pecas.Add(new Peca() { LarguraPeca = p.LarguraPeca, ComprimentoPeca = p.ComprimentoPeca });
            //}

            //_bancadaService.DefinirTipoBancada("Reta", bancada);

            //if (!OperacaoValida()) return PartialView("_AtualizarEndereco", clienteViewModel);
            await _bancadaService.Adicionar(bancada);

            return Json(bancadaViewModel);
        }
    }
}
