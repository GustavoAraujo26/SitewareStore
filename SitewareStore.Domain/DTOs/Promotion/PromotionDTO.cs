using SitewareStore.Domain.Enums;

namespace SitewareStore.Domain.DTOs.Promotion
{
    /// <summary>
    /// DTO de promoção
    /// </summary>
    public class PromotionDTO
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public PromotionDTO() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="observation">Observação</param>
        /// <param name="type">Tipo</param>
        /// <param name="cutQuantity">Quantidade de corte</param>
        /// <param name="percentage">Porcentagem de desconto</param>
        /// <param name="price">Valor final atribuido</param>
        /// <param name="status">Status</param>
        public PromotionDTO(Guid id, string observation, PromotionType type, int? cutQuantity, 
            decimal? percentage, decimal? price, StatusType status)
        {
            Id = id;
            Observation = observation;
            Type = type;
            CutQuantity = cutQuantity;
            Percentage = percentage;
            Price = price;
            Status = status;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Observação
        /// </summary>
        public string Observation { get; set; }

        /// <summary>
        /// Tipo
        /// </summary>
        public PromotionType Type { get; set; }

        /// <summary>
        /// Quantidade de corte
        /// </summary>
        public int? CutQuantity { get; set; }

        /// <summary>
        /// Porcentagem de desconto
        /// </summary>
        public decimal? Percentage { get; set; }

        /// <summary>
        /// Valor final atribuido
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public StatusType Status { get; set; }
    }
}
