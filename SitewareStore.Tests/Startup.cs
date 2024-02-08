using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Service.Extensions;

namespace SitewareStore.Tests
{
    /// <summary>
    /// Classe de inicialização para injeção de dependências no XUnit
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configurando as injeções de dependência para os testes unitários
        /// </summary>
        public IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.ConfigureApplicationServices();

            return services;
        }
    }
}
