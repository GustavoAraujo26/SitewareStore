using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Service.Extensions;
using SitewareStore.Domain.Extensions;

namespace SitewareStore.Tests.Helpers
{
    /// <summary>
    /// Gerador de coleção de serviços
    /// </summary>
    internal static class ServiceCollectionBuilder
    {
        /// <summary>
        /// Configurando as injeções de dependência para os testes unitários
        /// </summary>
        public static IServiceCollection BuildServiceCollection()
        {
            var services = new ServiceCollection();
            
            services.ConfigureApplicationServices();
            services.ConfigureStoreAutoMapper();

            return services;
        }
    }
}
