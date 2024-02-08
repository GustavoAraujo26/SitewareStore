using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Services.ShoppingCart
{
    /// <summary>
    /// Interface do serviço de alteração de status do carrinho de compras
    /// </summary>
    public interface IChangeShoppingCartStatusService : IComplexServiceBase<ChangeShoppingCartStatusRequest, ShoppingCartDTO>
    {
    }
}
