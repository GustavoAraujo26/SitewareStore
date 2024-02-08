using AutoMapper;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Mappers.TypeConverters.DTOs;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.Profiles
{
    /// <summary>
    /// Configuração dos conversores de DTO's
    /// </summary>
    internal class DtosProfile : Profile
    {
        public DtosProfile()
        {
            CreateMap<List<PromotionModel>, List<PromotionListDTO>>()
                .ConvertUsing<PromotionListDtoTypeConverter>();
        }
    }
}
