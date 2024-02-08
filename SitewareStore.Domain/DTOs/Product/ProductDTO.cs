using SitewareStore.Domain.Enums;

namespace SitewareStore.Domain.DTOs.Product
{
    /// <summary>
    /// DTO de produto
    /// </summary>
    public class ProductDTO
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public ProductDTO() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Nome</param>
        /// <param name="price">Preço</param>
        /// <param name="status">Status</param>
        /// <param name="promotionId">Id da promoção</param>
        public ProductDTO(Guid id, string name, decimal price, 
            StatusType status, Guid? promotionId)
        {
            Id = id;
            Name = name;
            Price = price;
            Status = status;
            PromotionId = promotionId;
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
        public decimal Price { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public StatusType Status { get; set; }

        /// <summary>
        /// Id da promoção
        /// </summary>
        public Guid? PromotionId { get; set; }
    }
}
