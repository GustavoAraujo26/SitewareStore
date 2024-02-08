using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Infra.CrossCutting.Models;

namespace SitewareStore.Infra.CrossCutting.Extensions
{
    /// <summary>
    /// Extensões para banco de dados
    /// </summary>
    public static class DbExtensions
    {
        /// <summary>
        /// Configura a injeção de dependência para a string de conexão com o banco de dados
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureDbConnectionString(this IServiceCollection services)
        {
            services.AddSingleton(SitewareStoreDbConnection.Instance);
        }
    }
}
