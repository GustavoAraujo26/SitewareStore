using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;
using System.Globalization;

namespace SitewareStore.Domain.Mappers.TypeConverters
{
    /// <summary>
    /// Conversor da entidade "promoção" para "descrição da promoção"
    /// </summary>
    internal class PromotionDescriptionTypeConverter : ITypeConverter<Promotion, string>
    {
        public string Convert(Promotion source, string destination, ResolutionContext context) =>
            source.Type switch
            {
                PromotionType.FullPriceByQuantity => GetFullPriceByQuantityDescription(source),
                PromotionType.PayQuantityMinusOne => GetPayQuantityMinusOneDescription(source),
                PromotionType.PercentageDiscount => GetPercentageDiscountDescription(source),
                _ => "Sem desconto"
            };

        private string GetFullPriceByQuantityDescription(Promotion promotion)
        {
            string priceFormatted = promotion.Price?.ToString("C", CultureInfo.CreateSpecificCulture("pt-Br"));
            return $"{(promotion.CutQuantity ?? 0)} itens por {priceFormatted}";
        }

        private string GetPayQuantityMinusOneDescription(Promotion promotion)
        {
            var finalQuantity = (promotion.CutQuantity ?? 0) - 1;
            return $"Leve {(promotion.CutQuantity ?? 0)} pague {finalQuantity}";
        }

        private string GetPercentageDiscountDescription(Promotion promotion) =>
            $"{(promotion.Percentage ?? 0)}% de desconto";
    }
}
