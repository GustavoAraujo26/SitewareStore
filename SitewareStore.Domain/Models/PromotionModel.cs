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
        /// <param name="description">Descrição</param>
        /// <param name="type">Tipo de promoção</param>
        /// <param name="cutQuantity">Quantidade de corte</param>
        /// <param name="percentage">Porcentagem</param>
        /// <param name="price">Valor final aplicado</param>
        /// <param name="status">Status</param>
        /// <param name="createdAt">Data de criação</param>
        /// <param name="updatedAt">Data de atualização</param>
        public PromotionModel(Guid id, string description, int type, int? cutQuantity, 
            int? percentage, int? price, int? status, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Description = description;
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
        /// Descrição
        /// </summary>
        public string Description { get; set; }

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
        public int? Percentage { get; set; }

        /// <summary>
        /// Valor final aplicado
        /// </summary>
        public int? Price { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public int? Status { get; set; }

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
