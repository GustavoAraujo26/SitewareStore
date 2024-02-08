using SitewareStore.Domain.DTOs.Cart;

namespace SitewareStore.Domain.Services.ShoppingCart
{
    /// <summary>
    /// Interface do serviço de inicialização do carrinho de compras
    /// </summary>
    public interface IInitializeShoppingCartService : ISimpleServiceBase<ShoppingCartDTO>
    {
    }
}
