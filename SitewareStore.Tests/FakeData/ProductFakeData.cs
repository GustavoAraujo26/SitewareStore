using Bogus;
using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;

namespace SitewareStore.Tests.FakeData
{
    /// <summary>
    /// Geração de dados fake para produtos
    /// </summary>
    internal static class ProductFakeData
    {
        public static StatusType StatusType { get; private set; }

        /// <summary>
        /// Retorna lista fake de nomes de produtos
        /// </summary>
        /// <returns></returns>
        public static List<string> BuildFakeProductNameList()
        {
            var faker = new Faker();

            var result = new List<string>();

            for(int i = 1; i <= 5; i++)
                result.Add(faker.Commerce.ProductName());

            return result;
        }

        /// <summary>
        /// Retorna entidade de produto
        /// </summary>
        /// <param name="linkPromotion">Realiza vinculação com promoção?</param>
        /// <returns></returns>
        public static Product BuildEntity(PromotionType? promotionType = null, StatusType? status = null)
        {
            var faker = new Faker();

            Promotion? promotion = null;
            if (promotionType.HasValue)
            {
                switch (promotionType)
                {
                    case PromotionType.FullPriceByQuantity:
                        promotion = PromotionFakeData.BuildFullPriceByQuantity();
                        break;
                    case PromotionType.PayQuantityMinusOne:
                        promotion = PromotionFakeData.BuildPayLessThanQuantity();
                        break;
                    case PromotionType.PercentageDiscount:
                        promotion = PromotionFakeData.BuildPercentageDiscount();
                        break;
                    default:
                        break;
                }
            }

            return new Product(faker.Random.Guid(), faker.Commerce.ProductName(), 
                faker.Random.Decimal(1, 100), status ?? StatusType.Active, promotion, DateTime.Now, DateTime.Now);
        }

        public static List<Product> BuildEntityList()
        {
            var result = new List<Product>();

            for (int i = 1; i <= 5; i++)
                result.Add(BuildEntity());

            return result;
        }

        /// <summary>
        /// Retorna lista de produtos para serem exibidos
        /// </summary>
        /// <returns></returns>
        public static List<ProductListDTO> BuildDtoList()
        {
            var result = new List<ProductListDTO>();

            for(int i = 1; i <= 5; i++)
            {
                Product product = null;
                Guid? promotionApplied = null;

                if (i == 1)
                {
                    product = BuildEntity(PromotionType.FullPriceByQuantity);
                    promotionApplied = product.PromotionApplied.Id;
                }
                else if (i == 2)
                {
                    product = BuildEntity(PromotionType.PayQuantityMinusOne);
                    promotionApplied = product.PromotionApplied.Id;
                }
                else if (i == 3)
                {
                    product = BuildEntity(PromotionType.PercentageDiscount);
                    promotionApplied = product.PromotionApplied.Id;
                }
                else
                {
                    product = BuildEntity();
                    promotionApplied = null;
                }

                result.Add(new ProductListDTO(product.Id, product.Name, product.Price, product.Status.GetDescription(), 
                    promotionApplied, product.UpdatedAt.ToString()));
            }

            return result;
        }
    }
}
