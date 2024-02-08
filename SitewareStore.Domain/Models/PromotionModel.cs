namespace SitewareStore.Domain.Models
{
    /// <summary>
    /// Modelo de banco de dados para promoção
    /// </summary>
    public class PromotionModel
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public PromotionModel() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="observation">Observação</param>
        /// <param name="type">Tipo de promoção</param>
        /// <param name="cutQuantity">Quantidade de corte</param>
        /// <param name="percentage">Porcentagem</param>
        /// <param name="price">Valor final aplicado</param>
        /// <param name="status">Status</param>
        /// <param name="createdAt">Data de criação</param>
        /// <param name="updatedAt">Data de atualização</param>
        public PromotionModel(Guid id, string observation, int type, int? cutQuantity,
            decimal? percentage, decimal? price, int status, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Observation = observation;
            Type = type;
            CutQuantity = cutQuantity;
            Percentage = percentage;
            Price = price;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
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
        /// Tipo de promoção
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Quantidade de corte
        /// </summary>
        public int? CutQuantity { get; set; }

        /// <summary>
        /// Porcentagem
        /// </summary>
        public decimal? Percentage { get; set; }

        /// <summary>
        /// Valor final aplicado
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data de alteração
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
