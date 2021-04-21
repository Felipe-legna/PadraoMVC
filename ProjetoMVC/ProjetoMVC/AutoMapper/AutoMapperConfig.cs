using AutoMapper;
using ProjetoMVC.App.Areas.Admin.ViewModels;

using ProjetoMVC.Business.Models;

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
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            //CreateMap<Item, ItemViewModel>().ReverseMap();
            //CreateMap<Endereco, EnderecoViewModel>().ReverseMap();

            //CreateMap<Orcamento, OrcamentoViewModel>().ReverseMap();


            //CreateMap<Servico, ServicoViewModel>().ReverseMap();
            //CreateMap<Bancada, BancadaViewModel>().ReverseMap();
            //CreateMap<ModeloBancada, ModeloBancadaViewModel>().ReverseMap();
            //CreateMap<Bancada, ModeloBancadaViewModel>().ReverseMap();

        }
    }
}