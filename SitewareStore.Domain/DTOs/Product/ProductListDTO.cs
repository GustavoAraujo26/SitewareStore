namespace SitewareStore.Domain.DTOs.Product
{
    /// <summary>
    /// DTO de listagem de produtos
    /// </summary>
    public class ProductListDTO
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public ProductListDTO() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Nome</param>
        /// <param name="price">Preço</param>
        /// <param name="status">Status</param>
        /// <param name="promotionApplied">Promoção aplicada</param>
        /// <param name="changeAt">Data de criação</param>
        public ProductListDTO(Guid id, string name, decimal price, string status,
            Guid? promotionApplied, string changeAt)
        {
            Id = id;
            Name = name;
            Price = price;
            Status = status;
            PromotionApplied = promotionApplied;
            ChangeAt = changeAt;
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
        public string Status { get; set; }

        /// <summary>
        /// Promoção aplicada
        /// </summary>
        public Guid? PromotionApplied { get; set; }

        /// <summary>
        /// Data de criação/alteração
        /// </summary>
        public string ChangeAt { get; set; }
    }
}
