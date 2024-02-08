using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Services.ShoppingCart
{
    /// <summary>
    /// Interface do serviço de alteração de item no carrinho de compras
    /// </summary>
    public interface IUpdateShoppingCartItemService : IComplexServiceBase<UpdateShoppingCartItemRequest, ShoppingCartDTO>
    {
    }
}
