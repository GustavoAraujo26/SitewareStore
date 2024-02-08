using SitewareStore.Domain.Enums;

namespace SitewareStore.Domain.DTOs.Cart
{
    /// <summary>
    /// DTO do carrinho de compras
    /// </summary>
    public class ShoppingCartDTO
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public ShoppingCartDTO() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="status">Status</param>
        /// <param name="changeAt">Data de criação/atualização</param>
        /// <param name="items">Lista de itens do carrinho de compras</param>
        public ShoppingCartDTO(Guid id, ShoppingCartStatus status, DateTime changeAt, List<ShoppingCartItemDTO> items)
        {
            Id = id;
            Status = status;
            ChangeAt = changeAt;
            Items = items;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public ShoppingCartStatus Status { get; set; }

        /// <summary>
        /// Data de criação/atualização
        /// </summary>
        public DateTime ChangeAt { get; set; }

        /// <summary>
        /// Lista de itens do carrinho de compras
        /// </summary>
        public List<ShoppingCartItemDTO> Items { get; set; }

        /// <summary>
        /// Preço inicial
        /// </summary>
        public decimal InitialPrice
        {
            get
            {
                if (Items is null || !Items.Any())
                    return 0;

                return Items.Sum(x => decimal.Round(x.Quantity * x.InitialPrice, 2));
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
    }
}
