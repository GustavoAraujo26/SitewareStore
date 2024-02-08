using Microsoft.Data.SqlClient;
using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.Entities;

namespace SitewareStore.Domain.Repositories
{
    /// <summary>
    /// Interface do repositório de produto
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Salva o produto no banco de dados
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <param name="product">Produto a ser persistido</param>
        /// <returns></returns>
        Task Save(SqlConnection db, Product product);

        /// <summary>
        /// Apaga produto do banco de dados
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        Task Delete(SqlConnection db, Guid id);

        /// <summary>
        /// Retorna produto com base em seu ID
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        Task<Product> Get(SqlConnection db, Guid id);

        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <returns></returns>
        Task<List<ProductListDTO>> ListAll(SqlConnection db);

        /// <summary>
        /// Lista todos os produtos ativos
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <returns></returns>
        Task<List<ProductListDTO>> ListActives(SqlConnection db);

        /// <summary>
        /// Lista todos os nomes dos produtos vinculados à uma promoção
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <param name="promotionId">Id da promoção</param>
        /// <returns></returns>
        Task<List<string>> ListNamesByPromotionId(SqlConnection db, Guid promotionId);
    }
}
