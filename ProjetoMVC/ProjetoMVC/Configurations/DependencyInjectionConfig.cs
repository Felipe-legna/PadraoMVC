using Microsoft.Extensions.DependencyInjection;
using ProjetoMvc.Data.Repository;
using ProjetoMVC.Business.Interfaces;
using ProjetoMVC.Business.Interfaces.BancadaBuilder;
using ProjetoMVC.Business.Notifications;
using ProjetoMVC.Business.Services;
using ProjetoMVC.Business.Services.BancadaBuilder;
using ProjetoMVC.Data.Context;
using ProjetoMVC.Data.Repository;
using ProjetoMVC.Site.lib.orcamento;
using ProjetoMVC.wwwroot.lib.cookie;

namespace ProjetoMVC.Site.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ProjetoMVCContext>();
            services.AddScoped<Cookie>();
            services.AddScoped<CookieOrcamento>();

            //services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
            //services.AddScoped<ICategoriaProdutoService, CategoriaProdutoService>();
            //services.AddScoped<IProdutoService, ProdutoService>();
            //services.AddScoped<IProdutoRepository, ProdutoRepository>();


            ////services.AddScoped<IMaterialService, MaterialService>();
            ////services.AddScoped<IMaterialRepository, MaterialRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();


            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<IBancadaRepository, BancadaRepository>();
            services.AddScoped<IBancadaService, BancadaService>();
           
            services.AddScoped<IBancadaBuilder, BancadaBuilder>();
            services.AddScoped<IBancadaReta, BancadaReta>();
            services.AddScoped<IBancadaEmL, BancadaEmL>();
            services.AddScoped<IBancadaEmT, BancadaEmT>();
            services.AddScoped<IBancadaEmU, BancadaEmU>();

            services.AddScoped<IModeloBancadaRepository, ModeloBancadaRepository>();
            services.AddScoped<IModeloBancadaService, ModeloBancadaService>();

            services.AddScoped<IMaterialRepository, MaterialRepository>();
           


            //services.AddScoped<IBancadaRetaService, BancadaRetaService>();
            //services.AddScoped<IBancadaEmLService, BancadaEmLService>();
            //services.AddScoped<IBancadaEmTService, BancadaEmTService>();
            //services.AddScoped<IBancadaEmUService, BancadaEmUService>();

            //services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            return services;
        }
    }
}
