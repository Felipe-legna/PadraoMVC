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
    [Route("Material/")]
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _contexto;        
        private readonly IBancadaService _service;
        private readonly ICategoriaRepository _categoriaContexto;
        private readonly IMapper _mapper;
       

        public MaterialController(IMaterialRepository context,                                         
                                         IBancadaService service,
                                         ICategoriaRepository categoriaContexto,
                                         IMapper mapper)
        {
            _contexto = context;
            _service = service;
            _categoriaContexto = categoriaContexto;
            _mapper = mapper;
          
        }

        [Route("lista-de-materiais")]
        public async Task<IActionResult> Index(int? pagina, string pesquisa)
        {
            IPagedList dadosPaginados = _mapper.Map<IEnumerable<MaterialViewModel>>(await _contexto.ObterTodosPaginados(pagina, pesquisa)).ToPagedList();
            return View(dadosPaginados);
            
        }


        [Route("dados-do-material/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var materialViewModel = _mapper.Map<MaterialViewModel>(await _contexto.ObterPorId(id));

            if (materialViewModel == null)
            {
                return NotFound();
            }

            return View(materialViewModel);
        }

        [Route("novo-material")]
        public async Task<IActionResult> Create()
        {
            //ViewBag.TiposBancadas = _materialService.ObterTiposBancadas();
            
            ViewBag.Categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaContexto.ObterTodos()).Where(p=> p.CategoriaPai != null &&  p.CategoriaPai.Nome == "Pedra").Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            return View();
        }

        [Route("novo-material")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaterialViewModel materialViewModel)
        {
            if (!ModelState.IsValid) return View(materialViewModel);

            //Criação vai ser pela classe de serviço.
            var material = _mapper.Map<Material>(materialViewModel);

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(materialViewModel.ImagemUpload, imgPrefixo))
            {
                return View(materialViewModel);
            }

            material.Imagem = imgPrefixo + materialViewModel.ImagemUpload.FileName;
           
            await _service.AdicionarMaterial(material);

            return RedirectToAction("Index");
        }

        [Route("editar-material/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaContexto.ObterTodos()).Where(p => p.CategoriaPai != null && p.CategoriaPai.Nome == "Pedra").Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            var materialViewModel = _mapper.Map<MaterialViewModel>(await _contexto.ObterPorId(id));

            if (materialViewModel == null) return NotFound();

            return View(materialViewModel);
        }


        [Route("editar-material/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MaterialViewModel materialViewModel)
        {
            if (id != materialViewModel.Id) return NotFound();

            var materialAtualizacao = await _contexto.ObterPorId(id);
            materialViewModel.Imagem = materialAtualizacao.Imagem;
            if (!ModelState.IsValid) return View(materialViewModel);

            if (materialViewModel.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(materialViewModel.ImagemUpload, imgPrefixo))
                {
                    return View(materialViewModel);
                }

                materialAtualizacao.Imagem = imgPrefixo + materialViewModel.ImagemUpload.FileName;
            }
                                   
            await _contexto.Atualizar(_mapper.Map<Material>(materialViewModel));


            return RedirectToAction("Index");
        }

        [Route("excluir-material/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var materialViewModel = _mapper.Map<MaterialViewModel>(await _contexto.ObterPorId(id));

            if (materialViewModel == null) return NotFound();

            return View(materialViewModel);
        }

        [Route("excluir-material/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var materialViewModel = _mapper.Map<MaterialViewModel>(await _contexto.ObterPorId(id));

            if (materialViewModel == null) return NotFound();

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
