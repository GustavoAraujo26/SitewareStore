using Microsoft.Data.SqlClient;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Entities;

namespace SitewareStore.Domain.Repositories
{
    /// <summary>
    /// Interface do repositório de promoções
    /// </summary>
    public interface IPromotionRepository
    {
        /// <summary>
        /// Persiste promoção no banco de dados
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <param name="promotion">Promoção a ser salva</param>
        /// <returns></returns>
        Task Save(SqlConnection db, Promotion promotion);

        /// <summary>
        /// Apaga promoção do banco de dados
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <param name="id">Id da promoção</param>
        /// <returns></returns>
        Task Delete(SqlConnection db, Guid id);

        /// <summary>
        /// Retorna uma promoção com base no seu Id
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <param name="id">Id da promoção</param>
        /// <returns></returns>
        Task<Promotion> Get(SqlConnection db, Guid id);

        /// <summary>
        /// Lista todas as promoções cadastradas
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <returns></returns>
        Task<List<PromotionListDTO>> ListAll(SqlConnection db);

        /// <summary>
        /// Lista todas as promoções ativas
        /// </summary>
        /// <param name="db">Conexão com o banco de dados</param>
        /// <returns></returns>
        Task<List<PromotionListDTO>> ListActives(SqlConnection db);
    }
}
