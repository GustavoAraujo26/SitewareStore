using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Mappers.TypeConverters.Requests;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Mappers.Profiles
{
    /// <summary>
    /// Configuração dos conversores de requisição
    /// </summary>
    internal class RequestsProfile : Profile
    {
        public RequestsProfile()
        {
            CreateMap<SaveProductRequest, Product>()
                .ConvertUsing<ProductRequestTypeConverter>();
        }
    }
}
