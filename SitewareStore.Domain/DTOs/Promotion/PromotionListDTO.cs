using SitewareStore.Domain.Enums;

namespace SitewareStore.Domain.DTOs.Promotion
{
    /// <summary>
    /// DTO de listagem de promoção
    /// </summary>
    public class PromotionListDTO
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public PromotionListDTO() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="type">Tipo de promoção</param>
        /// <param name="exibitionText">Texto de exibição</param>
        /// <param name="status">Status</param>
        /// <param name="changeAt">Data de criação/alteração</param>
        public PromotionListDTO(Guid id, string type, string exibitionText, string status, string changeAt)
        {
            Id = id;
            Type = type;
            ExibitionText = exibitionText;
            Status = status;
            ChangeAt = changeAt;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Tipo de promoção
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Texto de exibição
        /// </summary>
        public string ExibitionText { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Data de inclusão/alteração
        /// </summary>
        public string ChangeAt { get; set; }
    }
}
