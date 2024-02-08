namespace SitewareStore.Domain.Requests
{
    /// <summary>
    /// Requisição de persistência de produto
    /// </summary>
    public class SaveProductRequest
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public SaveProductRequest() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Nome</param>
        /// <param name="price">Preço</param>
        /// <param name="promotionId">Id da promoção</param>
        public SaveProductRequest(Guid? id, string name, decimal price, Guid? promotionId)
        {
            Id = id;
            Name = name;
            Price = price;
            PromotionId = promotionId;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Preço
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Id da promoção
        /// </summary>
        public Guid? PromotionId { get; set; }
    }
}
