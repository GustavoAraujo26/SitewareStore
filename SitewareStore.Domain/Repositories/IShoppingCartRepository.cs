using Microsoft.Data.SqlClient;
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
        /// <param name="db">Conexão com o banco de dados</param>
        /// <param name="cart">Carrinho de compras a ser persistido</param>
        /// <returns></returns>
        Task Save(SqlConnection db, ShoppingCart cart);

        /// <summary>
        /// Retorna carrinho de compras específico
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <param name="id">Id do carrinho de compras</param>
        /// <returns></returns>
        Task<ShoppingCart> Get(SqlConnection db, Guid id);

        /// <summary>
        /// Lista todos os carrinhos de compras
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <returns></returns>
        Task<List<ShoppingCartListDTO>> ListAll(SqlConnection db);
    }
}
