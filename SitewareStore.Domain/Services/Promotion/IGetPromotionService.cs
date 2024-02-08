using SitewareStore.Domain.DTOs.Promotion;

namespace SitewareStore.Domain.Services.Promotion
{
    /// <summary>
    /// Interface do serviço de busca de uma promoção específica
    /// </summary>
    public interface IGetPromotionService : ISimpleServiceBase<PromotionDTO>
    {
    }
}
