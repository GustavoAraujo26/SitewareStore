using SitewareStore.Domain.Enums;

namespace SitewareStore.Domain.Entities
{
    /// <summary>
    /// Produto
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Nome</param>
        /// <param name="price">Preço</param>
        /// <param name="status">Status</param>
        /// <param name="promotionApplied">Promoção aplicada</param>
        /// <param name="createdAt">Data de criação</param>
        /// <param name="updatedAt">Data de atualização</param>
        public Product(Guid id, string name, decimal price, StatusType status, 
            Promotion? promotionApplied, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Price = price;
            Status = status;
            PromotionApplied = promotionApplied;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Preço
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Status
        /// </summary>
        public StatusType Status { get; private set; }

        /// <summary>
        /// Promoção aplicada
        /// </summary>
        public Promotion? PromotionApplied { get; private set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Data de atualização
        /// </summary>
        public DateTime UpdatedAt { get; private set; }

        /// <summary>
        /// Adiciona uma promoção
        /// </summary>
        /// <param name="promotion">Promoção nova</param>
        public void AddPromotion(Promotion promotion)
        {
            PromotionApplied = promotion;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Remove uma promoção
        /// </summary>
        public void RemovePromotion()
        {
            PromotionApplied = null;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Atualiza dados básicos
        /// </summary>
        /// <param name="name">Nome</param>
        /// <param name="price">Preço</param>
        /// <param name="promotion">Promoção a ser aplicada</param>
        public void UpdateBasicData(string name, decimal price, Promotion? promotion = null)
        {
            Name = name;
            Price = price;

            if (promotion is not null)
                AddPromotion(promotion);
            else
                RemovePromotion();

            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Altera o status para "Cancelado"
        /// </summary>
        public void Cancel()
        {
            Status = StatusType.Cancelled;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Altera o status para "Ativo"
        /// </summary>
        public void Activate()
        {
            Status = StatusType.Active;
            UpdatedAt = DateTime.Now;
        }
    }
}
