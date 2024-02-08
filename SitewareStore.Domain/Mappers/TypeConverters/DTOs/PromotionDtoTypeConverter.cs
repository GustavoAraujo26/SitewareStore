using AutoMapper;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Entities;

namespace SitewareStore.Domain.Mappers.TypeConverters.DTOs
{
    /// <summary>
    /// Conversor de entidade de promoção para DTO
    /// </summary>
    internal class PromotionDtoTypeConverter : ITypeConverter<Promotion, PromotionDTO>
    {
        public PromotionDTO Convert(Promotion source, PromotionDTO destination, ResolutionContext context) =>
            new PromotionDTO(source.Id, source.Observation, source.Type, source.CutQuantity, source.Percentage, source.Price, source.Status);
    }
}
