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
        /// <param name="promotion">Promoção a ser salva</param>
        /// <returns></returns>
        Task Save(Promotion promotion);

        /// <summary>
        /// Apaga promoção do banco de dados
        /// </summary>
        /// <param name="id">Id da promoção</param>
        /// <returns></returns>
        Task Delete(Guid id);

        /// <summary>
        /// Retorna uma promoção com base no seu Id
        /// </summary>
        /// <param name="id">Id da promoção</param>
        /// <returns></returns>
        Task<Promotion> Get(Guid id);

        /// <summary>
        /// Lista todas as promoções cadastradas
        /// </summary>
        /// <returns></returns>
        Task<List<PromotionListDTO>> ListAll();

        /// <summary>
        /// Lista todas as promoções ativas
        /// </summary>
        /// <returns></returns>
        Task<List<PromotionListDTO>> ListActives();
    }
}
