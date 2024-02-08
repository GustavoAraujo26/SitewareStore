using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.TypeConverters.Models
{
    /// <summary>
    /// Conversor da entidade "promoção" para modelo de banco de dados
    /// </summary>
    internal class PromotionModelTypeConverter : ITypeConverter<Promotion, PromotionModel>
    {
        public PromotionModel Convert(Promotion source, PromotionModel destination, ResolutionContext context) =>
            new PromotionModel
            {
                Id = source.Id,
                Observation = source.Observation,
                Type = (int)source.Type,
                CutQuantity = source.CutQuantity,
                Percentage = source.Percentage,
                Price = source.Price,
                Status = (int)source.Status,
                CreatedAt = source.CreatedAt,
                UpdatedAt = source.UpdatedAt
            };
    }
}
