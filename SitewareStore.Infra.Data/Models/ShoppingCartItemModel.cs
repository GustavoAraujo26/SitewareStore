namespace SitewareStore.Infra.Data.Models
{
    /// <summary>
    /// Modelo de banco de dados para item do carrinho de compras
    /// </summary>
    public class ShoppingCartItemModel
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public ShoppingCartItemModel() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="shoppingCartId">Id do carrinho de compras</param>
        /// <param name="productId">Id do produto</param>
        /// <param name="productName">Nome do produto</param>
        /// <param name="quantity">Quantidade</param>
        /// <param name="initialPrice">Preço inicial</param>
        /// <param name="discount">Desconto</param>
        /// <param name="finalPrice">Preço final</param>
        /// <param name="promotionApplied">Promoção aplicada</param>
        public ShoppingCartItemModel(Guid id, Guid shoppingCartId, Guid productId, string productName, int quantity,
            decimal initialPrice, decimal discount, decimal finalPrice, string promotionApplied)
        {
            Id = id;
            ShoppingCartId = shoppingCartId;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            InitialPrice = initialPrice;
            Discount = discount;
            FinalPrice = finalPrice;
            PromotionApplied = promotionApplied;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id do carrinho de compras
        /// </summary>
        public Guid ShoppingCartId { get; set; }

        /// <summary>
        /// Id do produto
        /// </summary>
        public Guid ProductId { get; set; }

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
        /// Desconto
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Preço final
        /// </summary>
        public decimal FinalPrice { get; set; }

        /// <summary>
        /// Promoção aplicada
        /// </summary>
        public string PromotionApplied { get; set; }
    }
}
