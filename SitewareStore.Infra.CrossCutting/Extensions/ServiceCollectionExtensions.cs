using Microsoft.Extensions.DependencyInjection;

namespace SitewareStore.Infra.CrossCutting.Extensions
{
    /// <summary>
    /// Extensão para manipulação do ServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Retorna um serviço específico injetado
        /// </summary>
        /// <typeparam name="T">Tipo do serviço</typeparam>
        /// <param name="services">Interface do ServiceCollection</param>
        /// <returns></returns>
        public static T GetService<T>(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider.GetRequiredService<T>();
        }
    }
}
