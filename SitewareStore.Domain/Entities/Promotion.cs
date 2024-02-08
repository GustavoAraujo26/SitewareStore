using SitewareStore.Domain.Enums;

namespace SitewareStore.Domain.Entities
{
    /// <summary>
    /// Promoção para produto
    /// </summary>
    public class Promotion
    {
        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="description">Descrição</param>
        /// <param name="type">Tipo de promoção</param>
        /// <param name="cutQuantity">Quantidade de corte</param>
        /// <param name="percentage">Porcentagem de desconto</param>
        /// <param name="price">Valor final aplicado</param>
        /// <param name="status">Status</param>
        /// <param name="createdAt">Data de criação</param>
        /// <param name="updatedAt">Data de atualização</param>
        public Promotion(Guid id, string description, PromotionType type, int? cutQuantity, 
            decimal? percentage, decimal? price, StatusType status, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Description = description;
            Type = type;
            CutQuantity = cutQuantity;
            Percentage = percentage;
            Price = price;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Tipo de promoção
        /// </summary>
        public PromotionType Type { get; private set; }

        /// <summary>
        /// Quantidade de corte
        /// </summary>
        public int? CutQuantity { get; private set; }

        /// <summary>
        /// Porcentagem de desconto
        /// </summary>
        public decimal? Percentage { get; private set; }

        /// <summary>
        /// Valor final aplicado
        /// </summary>
        public decimal? Price { get; private set; }

        /// <summary>
        /// Status
        /// </summary>
        public StatusType Status { get; private set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Data de atualização
        /// </summary>
        public DateTime UpdatedAt { get; private set; }

        /// <summary>
        /// Cria nova promoção de valor cheio por quantidade
        /// </summary>
        /// <param name="quantity">Quantidade de itens limite</param>
        /// <param name="price">Valor final</param>
        /// <returns>Promoção criada</returns>
        public static Promotion BuildFullPriceByQuantity(string description, int quantity, decimal price) =>
            new Promotion(Guid.NewGuid(), description, PromotionType.FullPriceByQuantity, quantity, 
                null, price, StatusType.Active, DateTime.Now, DateTime.Now);

        /// <summary>
        /// Cria nova promoção de "leve mais pague menos"
        /// </summary>
        /// <param name="quantity">Quantidade limite de itens</param>
        /// <returns>Promoção criada</returns>
        public static Promotion BuildPayLessThanQuantity(string description, int quantity) =>
            new Promotion(Guid.NewGuid(), description, PromotionType.PayQuantityMinusOne, quantity, 
                null, null, StatusType.Active, DateTime.Now, DateTime.Now);

        /// <summary>
        /// Cria nova promoção de desconto por porcentagem
        /// </summary>
        /// <param name="percentage">Porcentagem a ser aplicada</param>
        /// <returns>Promoção criada</returns>
        public static Promotion BuildPercentageDiscount(string description, decimal percentage) =>
            new Promotion(Guid.NewGuid(), description, PromotionType.PercentageDiscount, null,
                percentage, null, StatusType.Active, DateTime.Now, DateTime.Now);

        /// <summary>
        /// Realiza o cancelamento de uma promoção
        /// </summary>
        public void Cancel()
        {
            Status = StatusType.Cancelled;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Realiza a ativaão de uma promoção
        /// </summary>
        public void Activate()
        {
            Status = StatusType.Active;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Atualiza dados básicos
        /// </summary>
        /// <param name="description">Descrição</param>
        /// <param name="type">Tipo de promoção</param>
        /// <param name="cutQuantity">Quantidade de corte</param>
        /// <param name="percentage">Porcentagem de desconto</param>
        /// <param name="price">Valor final</param>
        public void UpdateBasicData(string description, PromotionType type, int? cutQuantity, 
            decimal? percentage, decimal? price)
        {
            Description = description;
            Type = type;
            CutQuantity = cutQuantity;
            Percentage = percentage;
            Price = price;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Calcula valor final da compra do(s) item(ns) com base na promoção selecionada
        /// </summary>
        /// <param name="chartItemQuantity">Quantidade de itens no carrinho</param>
        /// <param name="productPrice">Valor do produto</param>
        /// <returns>Preço final da compra do(s) produto(s)</returns>
        public decimal CalculateFinalPrice(int chartItemQuantity, decimal productPrice) =>
            Type switch
            {
                PromotionType.FullPriceByQuantity => CalculateFullPriceByQuantity(chartItemQuantity, productPrice),
                PromotionType.PayQuantityMinusOne => CalculatePayMinusOne(chartItemQuantity, productPrice),
                PromotionType.PercentageDiscount => CalculatePercentageDiscount(chartItemQuantity, productPrice),
                _ => decimal.Round((chartItemQuantity * productPrice), 2)
            };

        /// <summary>
        /// Calcula valor final do produto no carrinho aplicando o tipo de promoção "valor cheio por quantidade"
        /// </summary>
        /// <param name="chartItemQuantity">Quantidade de itens no carrinho</param>
        /// <param name="productPrice">Valor do produto</param>
        /// <returns>Preço final da compra do(s) produto(s)</returns>
        private decimal CalculateFullPriceByQuantity(int chartItemQuantity, decimal productPrice)
        {
            decimal finalPrice = 0;
            if (chartItemQuantity < CutQuantity)
            {
                finalPrice = chartItemQuantity * productPrice;
            }
            else if (chartItemQuantity % CutQuantity == 0)
            {
                int quantityGroup = chartItemQuantity / (CutQuantity ?? 0);
                finalPrice = (Price ?? 0) * quantityGroup;
            }
            else
            {
                int surplusQuantity = chartItemQuantity % (CutQuantity ?? 0);
                decimal surplusPrice = productPrice * surplusQuantity;

                int quantityGroup = chartItemQuantity / (CutQuantity ?? 0);
                finalPrice = ((Price ?? 0) * quantityGroup) + surplusPrice;
            }

            return Decimal.Round(finalPrice, 2);
        }

        /// <summary>
        /// Calcula valor final do produto no carrinho aplicando o tipo de promoção "leve mais pague menos"
        /// </summary>
        /// <param name="chartItemQuantity">Quantidade de itens no carrinho</param>
        /// <param name="productPrice">Valor do produto</param>
        /// <returns>Preço final da compra do(s) produto(s)</returns>
        private decimal CalculatePayMinusOne(int chartItemQuantity, decimal productPrice)
        {
            decimal finalPrice = 0;
            if (chartItemQuantity < CutQuantity)
            {
                finalPrice = chartItemQuantity * productPrice;
            }
            else if (chartItemQuantity == CutQuantity)
            {
                int calculatedQuantity = chartItemQuantity - 1;
                finalPrice = calculatedQuantity * productPrice;
            }
            else
            {
                int quantityDiff = chartItemQuantity - (CutQuantity ?? 0);
                decimal diffPrice = productPrice * quantityDiff;

                int calculatedQuantity = chartItemQuantity - 1;
                finalPrice = (calculatedQuantity * productPrice) + diffPrice;
            }

            return decimal.Round(finalPrice, 2);
        }

        /// <summary>
        /// Calcula valor final do produto no carrinho aplicando o tipo de promoção "desconto de porcentagem"
        /// </summary>
        /// <param name="chartItemQuantity">Quantidade de itens no carrinho</param>
        /// <param name="productPrice">Valor do produto</param>
        /// <returns>Preço final da compra do(s) produto(s)</returns>
        private decimal CalculatePercentageDiscount(int chartItemQuantity, decimal productPrice)
        {
            decimal percentagePrice = ((Percentage ?? 0) * 0.01M) * productPrice;
            decimal finalProductPrice = productPrice - percentagePrice;
            return decimal.Round(chartItemQuantity * finalProductPrice, 2);
        }
    }
}
