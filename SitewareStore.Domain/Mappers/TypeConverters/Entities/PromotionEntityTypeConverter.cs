using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.TypeConverters.Entities
{
    /// <summary>
    /// Conversor do modelo de banco de dados de "promoção" para entidade
    /// </summary>
    internal class PromotionEntityTypeConverter : ITypeConverter<PromotionModel, Promotion>
    {
        public Promotion Convert(PromotionModel source, Promotion destination, ResolutionContext context) =>
            new Promotion(source.Id, source.Observation, (PromotionType)source.Type, source.CutQuantity, 
                source.Percentage, source.Price, (StatusType)source.Status, source.CreatedAt, source.UpdatedAt);
    }
}
