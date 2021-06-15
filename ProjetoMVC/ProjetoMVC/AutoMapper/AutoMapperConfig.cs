using AutoMapper;
using ProjetoMVC.App.Areas.Admin.ViewModels;
using ProjetoMVC.Business.Models;
using ProjetoMVC.ViewModels;
using System.Collections.Generic;

namespace MgMarmore.Site.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //CreateMap<CategoriaProduto, CategoriaProdutoViewModel>().ReverseMap();
            //CreateMap<CategoriaMaterial, CategoriaMaterialViewModel>().ReverseMap();
            
            //CreateMap<Material, MaterialViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<List<Categoria>, List<CategoriaViewModel>>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Peca, Peca2ViewModel>().ReverseMap();
           
            CreateMap<Bancada, BancadaViewModel>().ReverseMap();
            CreateMap<ModeloBancada, ModeloBancadaViewModel>().ReverseMap();

            CreateMap<Material, MaterialViewModel>().ReverseMap();



            // Area Cliente
            CreateMap<Peca, PecaViewModel>().ReverseMap();


        }
    }
}