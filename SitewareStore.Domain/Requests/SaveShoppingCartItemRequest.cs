namespace SitewareStore.Domain.Requests
{
    /// <summary>
    /// Requisição para adicionar item ao carrinho
    /// </summary>
    public class SaveShoppingCartItemRequest
    {
        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="shoppingCartId">Id do carrinho de compras</param>
        /// <param name="productId">Id do produto</param>
        /// <param name="quantity">Quantidade</param>
        public SaveShoppingCartItemRequest(Guid? shoppingCartId, Guid productId, int quantity)
        {
            ShoppingCartId = shoppingCartId;
            ProductId = productId;
            Quantity = quantity;
        }

        /// <summary>
        /// Id do carrinho de compras
        /// </summary>
        public Guid? ShoppingCartId { get; set; }

        /// <summary>
        /// Id do produto
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        public int Quantity { get; set; }
    }
}
