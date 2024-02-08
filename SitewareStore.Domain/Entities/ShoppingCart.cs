using SitewareStore.Domain.Enums;

namespace SitewareStore.Domain.Entities
{
    /// <summary>
    /// Carrinho de compras
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="status">Status</param>
        /// <param name="items">Lista de itens do carrinho</param>
        /// <param name="createdAt">Data de criação</param>
        /// <param name="updatedAt">Data de atualização</param>
        public ShoppingCart(Guid id, ShoppingCartStatus status, List<ShoppingCartItem> items, 
            DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Status = status;
            Items = items;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Status
        /// </summary>
        public ShoppingCartStatus Status { get; private set; }

        /// <summary>
        /// Lista de itens do carrinho
        /// </summary>
        public List<ShoppingCartItem> Items { get; private set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Data de atualização
        /// </summary>
        public DateTime UpdatedAt { get; private set; }

        /// <summary>
        /// Preço inicial
        /// </summary>
        public decimal InitialPrice
        {
            get
            {
                if (Items is null || !Items.Any())
                    return 0;

                return Items.Sum(x => decimal.Round(x.Quantity * x.Product.Price, 2));
            }
        }

        /// <summary>
        /// Descontos
        /// </summary>
        public decimal Discounts
        {
            get
            {
                if (Items is null || !Items.Any())
                    return 0;

                return InitialPrice - FinalPrice;
            }
        }

        /// <summary>
        /// Preço final
        /// </summary>
        public decimal FinalPrice
        {
            get
            {
                if (Items is null || !Items.Any())
                    return 0;

                return Items.Sum(x => x.FinalPrice);
            }
        }

        /// <summary>
        /// Cria um novo carrinho
        /// </summary>
        /// <returns>Retorna carrinho criado</returns>
        public static ShoppingCart Create() =>
            new ShoppingCart(Guid.NewGuid(), ShoppingCartStatus.Pending, new List<ShoppingCartItem>(), DateTime.Now, DateTime.Now);

        /// <summary>
        /// Limpa carrinho
        /// </summary>
        public void ClearChart()
        {
            Items = new List<ShoppingCartItem>();
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Adiciona item ao carrinho
        /// </summary>
        /// <param name="item">Item do carrinho</param>
        public void AddItem(ShoppingCartItem item)
        {
            Items.Add(item);
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Remove item do carrinho
        /// </summary>
        /// <param name="item">Item do carrinho</param>
        public void RemoveItem(ShoppingCartItem item)
        {
            Items.Remove(item);
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Remove item do carrinho
        /// </summary>
        /// <param name="item">Item do carrinho</param>
        public void RemoveItem(Guid itemId)
        {
            var currentItem = Items.FirstOrDefault(x => x.Id.Equals(itemId));
            if (currentItem == null)
                return;

            Items.Remove(currentItem);
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Marca o carrinho como finalizado
        /// </summary>
        public void Finish()
        {
            Status = ShoppingCartStatus.Finished;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Marca o carrinho como cancelado
        /// </summary>
        public void Cancel()
        {
            Status = ShoppingCartStatus.Canceled;
            UpdatedAt = DateTime.Now;
        }
    }
}
