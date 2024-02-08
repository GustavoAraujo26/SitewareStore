using Bogus;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;

namespace SitewareStore.Tests.FakeData
{
    /// <summary>
    /// Geração de dados fake de itens de um carrinho de compras
    /// </summary>
    internal static class ShoppingCartItemFakeData
    {
        /// <summary>
        /// Gera um item de carrinho de compras
        /// </summary>
        /// <param name="promotionType">Tipo da promoção</param>
        /// <returns></returns>
        public static ShoppingCartItem BuildCartItem(PromotionType? promotionType = null)
        {
            var faker = new Faker();

            var product = ProductFakeData.BuildEntity(promotionType);

            return new ShoppingCartItem(faker.Random.Guid(), product, faker.Random.Int(1, 100));
        }

        /// <summary>
        /// Gera lista de itens de um carrinho de compras
        /// </summary>
        /// <returns></returns>
        public static List<ShoppingCartItem> BuildCartItemList()
        {
            var result = new List<ShoppingCartItem>();

            for(int i = 1; i <= 5; i++)
            {
                if (i == 1)
                    result.Add(BuildCartItem(PromotionType.FullPriceByQuantity));
                else if (i == 2)
                    result.Add(BuildCartItem(PromotionType.PayQuantityMinusOne));
                else if (i == 3)
                    result.Add(BuildCartItem(PromotionType.PercentageDiscount));
                else
                    result.Add(BuildCartItem());
            }

            return result;
        }
    }
}
