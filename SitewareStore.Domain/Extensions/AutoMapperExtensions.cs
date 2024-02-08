using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Domain.Mappers.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitewareStore.Domain.Extensions
{
    /// <summary>
    /// Extensões relacionadas ao AutoMapper
    /// </summary>
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// Configura a injeção de dependência do AutoMapper relacionado às conversões dentro do sub-projeto Infra.Data
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureStoreAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EntitiesProfile), typeof(ModelsProfile));
        }
    }
}
