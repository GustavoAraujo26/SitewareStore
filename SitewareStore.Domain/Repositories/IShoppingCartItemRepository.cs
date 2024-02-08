using SitewareStore.Domain.Entities;

namespace SitewareStore.Domain.Repositories
{
    /// <summary>
    /// Interface do repositóriode itens do carrinho de compras
    /// </summary>
    public interface IShoppingCartItemRepository
    {
        /// <summary>
        /// Apaga item do carrinho no banco de dados
        /// </summary>
        /// <param name="id">Id do item do carrinho de compras</param>
        /// <returns></returns>
        Task Delete(Guid id);

        /// <summary>
        /// Lista todos os itens vinculados à um carrinho de compras
        /// </summary>
        /// <param name="cartId">Id do carrinho de compras</param>
        /// <returns></returns>
        Task<List<ShoppingCartItem>> ListItems(Guid cartId);

        /// <summary>
        /// Retorna um item específico do carrinho de compras
        /// </summary>
        /// <param name="id">Id do item do carrinho de compras</param>
        /// <returns></returns>
        Task<ShoppingCartItem> Get(Guid id);

        /// <summary>
        /// Salva lista de itens do carrinho de compras
        /// </summary>
        /// <param name="cartId">Id do carrinho de compras</param>
        /// <param name="itemList">Lista de itens do carrinho</param>
        /// <returns></returns>
        Task Save(Guid cartId, List<ShoppingCartItem> itemList);
    }
}
