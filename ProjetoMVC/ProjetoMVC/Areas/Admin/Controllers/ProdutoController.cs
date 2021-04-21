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

namespace ProjetoMVC.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Produto/")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _contexto;        
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaRepository _categoriaContexto;
        private readonly IMapper _mapper;
       

        public ProdutoController(IProdutoRepository context,                                         
                                         IProdutoService produtoService,
                                         ICategoriaRepository categoriaContexto,
                                         IMapper mapper)
        {
            _contexto = context;
            _produtoService = produtoService;
            _categoriaContexto = categoriaContexto;
            _mapper = mapper;
          
        }

        [Route("lista-de-produtos")]
        public async Task<IActionResult> Index(int? pagina, string pesquisa)
        {
            IPagedList dadosPaginados = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _contexto.ObterTodosPaginados(pagina, pesquisa)).ToPagedList();
            return View(dadosPaginados);
            
        }


        [Route("dados-do-produto/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(await _contexto.ObterPorId(id));

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [Route("novo-produto")]
        public async Task<IActionResult> Create()
        {
            //ViewBag.TiposBancadas = _produtoService.ObterTiposBancadas();
            ViewBag.Categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaContexto.ObterTodos()).Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            return View();
        }

        [Route("novo-produto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return View(produtoViewModel);

            //Criação vai ser pela classe de serviço.
            var produto = _mapper.Map<Produto>(produtoViewModel);

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(produtoViewModel.ImagemUpload, imgPrefixo))
            {
                return View(produtoViewModel);
            }

            produto.Imagem = imgPrefixo + produtoViewModel.ImagemUpload.FileName;
           
            await _produtoService.Adicionar(produto);

            return RedirectToAction("Index");
        }

        [Route("editar-produto/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaContexto.ObterTodos()).Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(await _contexto.ObterPorId(id));

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }


        [Route("editar-produto/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            var produtoAtualizacao = await _contexto.ObterPorId(id);
            produtoViewModel.Imagem = produtoAtualizacao.Imagem;
            if (!ModelState.IsValid) return View(produtoViewModel);

            if (produtoViewModel.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(produtoViewModel.ImagemUpload, imgPrefixo))
                {
                    return View(produtoViewModel);
                }

                produtoAtualizacao.Imagem = imgPrefixo + produtoViewModel.ImagemUpload.FileName;
            }
                                   
            await _contexto.Atualizar(_mapper.Map<Produto>(produtoViewModel));


            return RedirectToAction("Index");
        }

        [Route("excluir-produto/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(await _contexto.ObterPorId(id));

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [Route("excluir-produto/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(await _contexto.ObterPorId(id));

            if (produtoViewModel == null) return NotFound();

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

       

       
    }
}
