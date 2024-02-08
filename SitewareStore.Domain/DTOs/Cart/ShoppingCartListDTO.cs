using SitewareStore.Domain.Enums;

namespace SitewareStore.Domain.DTOs.Cart
{
    /// <summary>
    /// DTO de listagem de carrinho de compras
    /// </summary>
    public class ShoppingCartListDTO
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public ShoppingCartListDTO() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="status">Status</param>
        /// <param name="initialPrice">Preço inicial</param>
        /// <param name="discounts">Descontos</param>
        /// <param name="finalPrice">Preço final</param>
        /// <param name="changeAt">Data de criação/atualização</param>
        public ShoppingCartListDTO(Guid id, StatusType status, decimal initialPrice, 
            decimal discounts, decimal finalPrice, string changeAt)
        {
            Id = id;
            Status = status;
            InitialPrice = initialPrice;
            Discounts = discounts;
            FinalPrice = finalPrice;
            ChangeAt = changeAt;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public StatusType Status { get; set; }

        /// <summary>
        /// Descrição do status
        /// </summary>
        public string StatusDescription
        {
            get
            {
                return Status.GetDescription();
            }
        }

        /// <summary>
        /// Preço inicial
        /// </summary>
        public decimal InitialPrice { get; set; }

        /// <summary>
        /// Descontos
        /// </summary>
        public decimal Discounts { get; set; }

        /// <summary>
        /// Preço final
        /// </summary>
        public decimal FinalPrice { get; set; }

        /// <summary>
        /// Data de criação/atualização
        /// </summary>
        public string ChangeAt { get; set; }
    }
}
