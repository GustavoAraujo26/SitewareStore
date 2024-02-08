using SitewareStore.Domain.DTOs.Cart;

namespace SitewareStore.Domain.Services.ShoppingCart
{
    /// <summary>
    /// Interface do serviço de busca do carrinho de compras
    /// </summary>
    public interface IGetShoppingCartService : ISimpleServiceBase<ShoppingCartDTO>
    {
    }
}
