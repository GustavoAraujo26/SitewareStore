using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Services.ShoppingCart
{
    /// <summary>
    /// Interface do serviço de inserção de item no carrinho de compras
    /// </summary>
    public interface IAddShoppingCartItemService : IComplexServiceBase<AddShoppingCartItemRequest, ShoppingCartDTO>
    {
    }
}
