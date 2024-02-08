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
        /// <param name="product">Produto a ser persistido</param>
        /// <returns></returns>
        Task Save(Product product);

        /// <summary>
        /// Apaga produto do banco de dados
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        Task Delete(Guid id);

        /// <summary>
        /// Retorna produto com base em seu ID
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        Task<Product> Get(Guid id);

        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns></returns>
        Task<List<ProductListDTO>> ListAll();

        /// <summary>
        /// Lista todos os produtos ativos
        /// </summary>
        /// <returns></returns>
        Task<List<ProductListDTO>> ListActives();
    }
}
