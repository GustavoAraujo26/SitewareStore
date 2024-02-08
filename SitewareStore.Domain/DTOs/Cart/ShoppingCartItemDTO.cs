namespace SitewareStore.Domain.DTOs.Cart
{
    /// <summary>
    /// DTO do item do carrinho de compras
    /// </summary>
    public class ShoppingCartItemDTO
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public ShoppingCartItemDTO() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="productName">Nome do produto</param>
        /// <param name="quantity">Quantidade</param>
        /// <param name="initialPrice">Preço inicial</param>
        /// <param name="promotionApplied">Promoção aplicada</param>
        /// <param name="finalPrice">Preço final</param>
        public ShoppingCartItemDTO(Guid id, string productName, int quantity, 
            decimal initialPrice, string promotionApplied, decimal finalPrice)
        {
            Id = id;
            ProductName = productName;
            Quantity = quantity;
            InitialPrice = initialPrice;
            PromotionApplied = promotionApplied;
            FinalPrice = finalPrice;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Preço inicial
        /// </summary>
        public decimal InitialPrice { get; set; }

        /// <summary>
        /// Descrição da promoção
        /// </summary>
        public string PromotionApplied { get; set; }

        /// <summary>
        /// Preço final
        /// </summary>
        public decimal FinalPrice { get; set; }
    }
}
