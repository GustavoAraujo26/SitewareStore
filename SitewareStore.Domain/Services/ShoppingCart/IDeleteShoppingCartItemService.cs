using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Services.ShoppingCart
{
    /// <summary>
    /// Interface do serviço de deleção de item do carrinho de compras
    /// </summary>
    public interface IDeleteShoppingCartItemService : IComplexServiceBase<DeleteShoppingCartItemRequest, ShoppingCartDTO>
    {
    }
}
