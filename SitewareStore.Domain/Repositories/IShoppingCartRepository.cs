using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Entities;

namespace SitewareStore.Domain.Repositories
{
    /// <summary>
    /// Interface do repositório de carrinho de compras
    /// </summary>
    public interface IShoppingCartRepository
    {
        /// <summary>
        /// Salva carrinho de compras no banco de dados
        /// </summary>
        /// <param name="cart">Carrinho de compras a ser persistido</param>
        /// <returns></returns>
        Task Save(ShoppingCart cart);

        /// <summary>
        /// Retorna carrinho de compras específico
        /// </summary>
        /// <param name="id">Id do carrinho de compras</param>
        /// <returns></returns>
        Task<ShoppingCart> Get(Guid id);

        /// <summary>
        /// Lista todos os carrinhos de compras
        /// </summary>
        /// <returns></returns>
        Task<List<ShoppingCartDTO>> ListAll();
    }
}
