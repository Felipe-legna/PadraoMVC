using Microsoft.Extensions.DependencyInjection;
using ProjetoMvc.Data.Repository;
using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Notifications;
using ProjetoMVC.Business.Services;
using ProjetoMVC.Data.Context;
using ProjetoMVC.Data.Repository;

namespace ProjetoMVC.Site.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ProjetoMVCContext>();

            //services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
            //services.AddScoped<ICategoriaProdutoService, CategoriaProdutoService>();
            //services.AddScoped<IProdutoService, ProdutoService>();
            //services.AddScoped<IProdutoRepository, ProdutoRepository>();

            ////services.AddScoped<ICategoriaMaterialRepository, CategoriaMaterialRepository>();
            ////services.AddScoped<ICategoriaMaterialService, CategoriaMaterialService>();
            ////services.AddScoped<IMaterialService, MaterialService>();
            ////services.AddScoped<IMaterialRepository, MaterialRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();


            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            //services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            //services.AddScoped<IClienteService, ClienteService>();




            //services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();


            //services.AddScoped<IServicoRepository, ServicoRepository>();
            //services.AddScoped<IRevendaRepository, RevendaRepository>();


            //services.AddScoped<IBancadaBuilder, BancadaBuilder>();



            //services.AddScoped<IItemService, ItemService>();

            //services.AddScoped<IOrcamentoService, OrcamentoService>();

            //services.AddScoped<IServicoService, ServicoService>();
            //services.AddScoped<IBancadaService, BancadaService>();
            //services.AddScoped<IModeloBancadaService, ModeloBancadaService>();


            //services.AddScoped<IBancadaRetaService, BancadaRetaService>();
            //services.AddScoped<IBancadaEmLService, BancadaEmLService>();
            //services.AddScoped<IBancadaEmTService, BancadaEmTService>();
            //services.AddScoped<IBancadaEmUService, BancadaEmUService>();

            //services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            return services;
        }
    }
}
