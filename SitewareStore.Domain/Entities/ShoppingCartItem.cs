namespace SitewareStore.Domain.Entities
{
    /// <summary>
    /// Item do carrinho
    /// </summary>
    public class ShoppingCartItem
    {
        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="product">Produto</param>
        /// <param name="quantity">Quantidade</param>
        /// <param name="finalPrice">Preço final</param>
        public ShoppingCartItem(Guid id, Product product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;

            CalculateFinalPrice();
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Produto
        /// </summary>
        public Product Product { get; private set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Preço final
        /// </summary>
        public decimal FinalPrice { get; private set; }

        /// <summary>
        /// Atualiza quantidade de itens no carrinho
        /// </summary>
        /// <param name="newQuantity">Nova quantidade de itens</param>
        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity;

            CalculateFinalPrice();
        }

        /// <summary>
        /// Calcula valor final do item do carrinho
        /// </summary>
        private void CalculateFinalPrice()
        {
            if (Product.PromotionApplied is null)
            {
                FinalPrice = Decimal.Round(Quantity * Product.Price, 2);
            }
            else
            {
                FinalPrice = Product.PromotionApplied.CalculateFinalPrice(Quantity, Product.Price);
            }
        }
    }
}
