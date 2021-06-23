using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    [Route("ModeloBancada/")]
    public class ModeloBancadaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IModeloBancadaRepository _contexto;
        private readonly IModeloBancadaService _bancadaService;
        private readonly ICategoriaRepository _categoriaRepository;
        public ModeloBancadaController(IMapper mapper,
                                    IModeloBancadaRepository contexto,
                                    IModeloBancadaService bancadaService,
                                    ICategoriaRepository categoriaRepository
            )
        {
            _mapper = mapper;
            _contexto = contexto;
            _bancadaService = bancadaService;
            _categoriaRepository = categoriaRepository;
        }

        [Route("lista-de-modelos-de-bancadas")]
        public async Task<IActionResult> Index(int? pagina, string pesquisa)
        {   
            var itens = _mapper.Map<IEnumerable<ModeloBancadaViewModel>>(await _contexto.ObterTodos());
            return View(itens);
        }


        [Route("dados-do-modelo-de-bancada/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var modeloViewModel = _mapper.Map<ModeloBancadaViewModel>(await _contexto.ObterPorId(id));

            if (modeloViewModel == null)
            {
                return NotFound();
            }

            return View(modeloViewModel);
        }

        [Route("novo-modelo-de-bancada")]
        public async Task<IActionResult> Create()
        {               
            ViewBag.Categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos()).Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            return View();
        }

        [Route("novo-modelo-bancada")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModeloBancadaViewModel modeloViewModel)
        {
            if (!ModelState.IsValid) return View(modeloViewModel);

            //Criação vai ser pela classe de serviço.
            var modelo = _mapper.Map<ModeloBancada>(modeloViewModel);

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(modeloViewModel.ImagemUpload, imgPrefixo))
            {
                return View(modeloViewModel);
            }

            modelo.Imagem = imgPrefixo + modeloViewModel.ImagemUpload.FileName;
            //modelo.Categoria += 1;
            await _bancadaService.Adicionar(modelo);

            return RedirectToAction("Index");
        }

        [Route("editar-modelo-de-bancada/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var modeloViewModel = _mapper.Map<ModeloBancadaViewModel>(await _contexto.ObterPorId(id));
            ViewBag.Categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos()).Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            //ViewBag.Categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos()).Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            if (modeloViewModel == null) return NotFound();

            return View(modeloViewModel);
        }


        [Route("editar-modelo-de-bancada")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Descricao,Metodo,Metodo,ImagemUpload,CategoriaId,QuantidadePecas")] ModeloBancadaViewModel modeloViewModel)
        {
            if (id != modeloViewModel.Id) return NotFound();

            var modeloAtualizacao = await _contexto.ObterPorId(id);
                       
            if (!ModelState.IsValid) return View(modeloViewModel);

            modeloAtualizacao.Nome = modeloViewModel.Nome;
            modeloAtualizacao.Descricao = modeloViewModel.Descricao;
            modeloAtualizacao.Metodo = modeloViewModel.Metodo;
            modeloAtualizacao.CategoriaId = modeloViewModel.CategoriaId;
            modeloAtualizacao.Imagem = modeloViewModel.Imagem;
            modeloAtualizacao.QuantidadePecas = modeloViewModel.QuantidadePecas;

            if (modeloViewModel.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(modeloViewModel.ImagemUpload, imgPrefixo))
                {
                    return View(modeloViewModel);
                }

                modeloAtualizacao.Imagem = imgPrefixo + modeloViewModel.ImagemUpload.FileName;
            }

            await _contexto.Atualizar(_mapper.Map<ModeloBancada>(modeloAtualizacao));

            return RedirectToAction("Index");
        }

        [Route("excluir-modelo-de-bancada/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var modeloViewModel = _mapper.Map<ModeloBancadaViewModel>(await _contexto.ObterPorId(id));

            if (modeloViewModel == null) return NotFound();

            return View(modeloViewModel);
        }

        [Route("excluir-modelo-de-bancada")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var modeloViewModel = _mapper.Map<ModeloBancadaViewModel>(await _contexto.ObterPorId(id));

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

        [Route("adicionar-modelo-de-bancada/{id:Guid}")]
        [HttpPost]
        public async Task<IActionResult> AdicionarBancada(ModeloBancadaViewModel bancadaViewModel, Guid id)
        {


            var modeloBancada = _mapper.Map<ModeloBancadaViewModel>(await _contexto.ObterPorId(id));


            //bancadaViewModel.Metodo = modeloBancada.Metodo;
            //var pecas = _mapper.Map<List<Peca>>(bancadaViewModel.Pecas);


            ModeloBancada bancada = new ModeloBancada
            {
                //Nome = modeloBancada.Nome,
                //Descricao = modeloBancada.Descricao,
                Nome = bancadaViewModel.Nome,
                Descricao = bancadaViewModel.Descricao,
                Metodo = bancadaViewModel.Metodo,
                Imagem = bancadaViewModel.Imagem,
                CategoriaId = bancadaViewModel.CategoriaId
                
                

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
