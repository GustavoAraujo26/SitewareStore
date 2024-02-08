using SitewareStore.Domain.DTOs.Promotion;

namespace SitewareStore.Domain.Services.Promotion
{
    /// <summary>
    /// Interface do serviço de listagem de promoções ativas
    /// </summary>
    public interface IListActivePromotionService : IListServiceBase<PromotionListDTO>
    {
    }
}
