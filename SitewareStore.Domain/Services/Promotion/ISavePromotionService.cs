using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Services.Promotion
{
    /// <summary>
    /// Interface do serviço de persistência de promoção
    /// </summary>
    public interface ISavePromotionService : IComplexServiceBase<SavePromotionRequest, PromotionDTO>
    {
    }
}
