using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Mappers.TypeConverters.Requests
{
    /// <summary>
    /// Conversor de requisição de persistência de promoção para entidade
    /// </summary>
    internal class PromotionRequestTypeConverter : ITypeConverter<SavePromotionRequest, Promotion>
    {
        public Promotion Convert(SavePromotionRequest source, Promotion destination, ResolutionContext context)
        {
            var newId = Guid.NewGuid();
            if (source.Id is not null && !source.Id.Value.Equals(Guid.Empty))
                newId = source.Id.Value;

            return new Promotion(newId, source.Observation, source.Type, source.CutQuantity, source.Percentage, 
                source.Price, StatusType.Active, DateTime.Now, DateTime.Now);
        }
    }
}
