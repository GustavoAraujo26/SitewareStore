using AutoMapper;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.TypeConverters.DTOs
{
    /// <summary>
    /// Conversor de lista de modelos de promoção para lista de DTO's
    /// </summary>
    internal class PromotionListDtoTypeConverter : ITypeConverter<List<PromotionModel>, List<PromotionListDTO>>
    {
        public List<PromotionListDTO> Convert(List<PromotionModel> source, List<PromotionListDTO> destination, ResolutionContext context)
        {
            var result = new List<PromotionListDTO>();

            if (source is null || !source.Any())
                return result;

            foreach(var promotion in source)
            {
                var dto = Convert(promotion, context);
                if (dto is not null)
                    result.Add(dto);
            }

            return result;
        }

        private PromotionListDTO Convert(PromotionModel model, ResolutionContext context)
        {
            var entity = context.Mapper.Map<Promotion>(model);
            if (entity is null)
                return null;

            var promotionDescription = context.Mapper.Map<string>(entity);

            return new PromotionListDTO(entity.Id, entity.Type.GetDescription(), promotionDescription, 
                entity.Status.GetDescription(), entity.UpdatedAt.ToString());
        }
    }
}
