using Bogus;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;
using System.Globalization;

namespace SitewareStore.Tests.FakeData
{
    /// <summary>
    /// Geração de dados fake para promoções
    /// </summary>
    internal static class PromotionFakeData
    {
        /// <summary>
        /// Cria promoção de valor cheio por quantidade
        /// </summary>
        /// <returns></returns>
        public static Promotion BuildFullPriceByQuantity()
        {
            var faker = new Faker();

            return Promotion.BuildFullPriceByQuantity(faker.Commerce.ProductMaterial(),
                faker.Random.Int(1, 100), faker.Random.Decimal(1, 1000));
        }

        /// <summary>
        /// Cria promoção de "leve mais pague menos"
        /// </summary>
        /// <returns></returns>
        public static Promotion BuildPayLessThanQuantity()
        {
            var faker = new Faker();

            return Promotion.BuildPayLessThanQuantity(faker.Commerce.ProductMaterial(),
                faker.Random.Int(1, 100));
        }

        /// <summary>
        /// Cria promoção de porcentagem de desconto
        /// </summary>
        /// <returns></returns>
        public static Promotion BuildPercentageDiscount()
        {
            var faker = new Faker();

            return Promotion.BuildPercentageDiscount(faker.Commerce.ProductMaterial(),
                faker.Random.Decimal(0, 100));
        }

        /// <summary>
        /// Cria lista de promoções a serem exibidas
        /// </summary>
        /// <returns></returns>
        public static List<PromotionListDTO> BuildDtoList()
        {
            var result = new List<PromotionListDTO>();

            var fullPriceByQuantity = BuildFullPriceByQuantity();
            result.Add(new PromotionListDTO(fullPriceByQuantity.Id, fullPriceByQuantity.Type.GetDescription(), 
                GetFullPriceByQuantityDescription(fullPriceByQuantity), fullPriceByQuantity.Status.GetDescription(), 
                fullPriceByQuantity.UpdatedAt.ToString()));

            var payLessThanQuantity = BuildPayLessThanQuantity();
            result.Add(new PromotionListDTO(payLessThanQuantity.Id, payLessThanQuantity.Type.GetDescription(),
                GetPayQuantityMinusOneDescription(payLessThanQuantity), payLessThanQuantity.Status.GetDescription(),
                payLessThanQuantity.UpdatedAt.ToString()));

            var percentageDiscount = BuildPercentageDiscount();
            result.Add(new PromotionListDTO(percentageDiscount.Id, percentageDiscount.Type.GetDescription(),
                GetPercentageDiscountDescription(percentageDiscount), percentageDiscount.Status.GetDescription(),
                percentageDiscount.UpdatedAt.ToString()));

            return result;
        }

        public static string GetFullPriceByQuantityDescription(Promotion promotion)
        {
            string priceFormatted = promotion.Price?.ToString("C", CultureInfo.CreateSpecificCulture("pt-Br"));
            return $"{(promotion.CutQuantity ?? 0)} itens por {priceFormatted}";
        }

        public static string GetPayQuantityMinusOneDescription(Promotion promotion)
        {
            var finalQuantity = (promotion.CutQuantity ?? 0) - 1;
            return $"Leve {(promotion.CutQuantity ?? 0)} pague {finalQuantity}";
        }

        public static string GetPercentageDiscountDescription(Promotion promotion) =>
            $"{(promotion.Percentage ?? 0)}% de desconto";
    }
}
