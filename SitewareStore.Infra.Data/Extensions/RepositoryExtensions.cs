using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Domain.Repositories;
using SitewareStore.Infra.Data.Contracts;

namespace SitewareStore.Infra.Data.Extensions
{
    /// <summary>
    /// Extensões relacionadas ao repositório
    /// </summary>
    public static class RepositoryExtensions
    {
        /// <summary>
        /// Configura a injeção de dependência dos repositórios
        /// </summary>
        /// <param name="services">Interface do ServiceCollection</param>
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IRepositoryBase, RepositoryBase>();
            services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
        }
    }
}
