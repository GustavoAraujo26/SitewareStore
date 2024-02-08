using Microsoft.Data.SqlClient;
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
        /// <param name="db">Conexão com o banco de dados</param>
        /// <param name="id">Id do item do carrinho de compras</param>
        /// <returns></returns>
        Task Delete(SqlConnection db, Guid id);

        /// <summary>
        /// Lista todos os itens vinculados à um carrinho de compras
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <param name="cartId">Id do carrinho de compras</param>
        /// <returns></returns>
        Task<List<ShoppingCartItem>> ListItems(SqlConnection db, Guid cartId);

        /// <summary>
        /// Retorna um item específico do carrinho de compras
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <param name="id">Id do item do carrinho de compras</param>
        /// <returns></returns>
        Task<ShoppingCartItem> Get(SqlConnection db, Guid id);

        /// <summary>
        /// Salva lista de itens do carrinho de compras
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <param name="cartId">Id do carrinho de compras</param>
        /// <param name="itemList">Lista de itens do carrinho</param>
        /// <returns></returns>
        Task Save(SqlConnection db, Guid cartId, List<ShoppingCartItem> itemList);
    }
}
