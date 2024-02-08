using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Services.Promotion
{
    /// <summary>
    /// Interface do serviço de alteração de status de promoção
    /// </summary>
    public interface IChangePromotionStatusService : IComplexServiceBase<ChangePromotionStatusRequest, PromotionDTO>
    {
    }
}
