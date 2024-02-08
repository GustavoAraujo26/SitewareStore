using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Services.ShoppingCart
{
    /// <summary>
    /// Interface do serviço de persistência de item no carrinho de compras
    /// </summary>
    public interface ISaveShoppingCartItemService : IComplexServiceBase<SaveShoppingCartItemRequest, ShoppingCartDTO>
    {
    }
}
