using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitewareStore.Domain.Models
{
    /// <summary>
    /// Modelo de banco de dados para carrinho de compras
    /// </summary>
    public class ShoppingCartModel
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public ShoppingCartModel() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="status">Status</param>
        /// <param name="initialPrice">Preço inicial</param>
        /// <param name="discounts">Descontos</param>
        /// <param name="finalPrice">Preço final</param>
        /// <param name="createdAt">Data de criação</param>
        /// <param name="updatedAt">Data de alteração</param>
        public ShoppingCartModel(Guid id, int status, decimal initialPrice, decimal discounts, 
            decimal finalPrice, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Status = status;
            InitialPrice = initialPrice;
            Discounts = discounts;
            FinalPrice = finalPrice;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public int Status { get; set; }

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
        /// Data de criação
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data de alteração
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
