namespace SitewareStore.Domain.Models
{
    /// <summary>
    /// Modelo para banco de dados de produto
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public ProductModel() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Nome</param>
        /// <param name="price">Preço</param>
        /// <param name="status">Status</param>
        /// <param name="promotionId">Id da promoção</param>
        /// <param name="createdAt">Data de criação</param>
        /// <param name="updatedAt">Data de atualização</param>
        public ProductModel(Guid id, string name, string price, int status, 
            Guid? promotionId, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Price = price;
            Status = status;
            PromotionId = promotionId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Preço
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Id da promoção
        /// </summary>
        public Guid? PromotionId { get; set; }

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
