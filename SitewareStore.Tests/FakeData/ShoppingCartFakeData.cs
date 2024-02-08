using Bogus;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;

namespace SitewareStore.Tests.FakeData
{
    /// <summary>
    /// Geração de dados fake para carrino de compras
    /// </summary>
    internal static class ShoppingCartFakeData
    {
        /// <summary>
        /// Gera um carrinho de compras
        /// </summary>
        /// <returns></returns>
        public static ShoppingCart Build()
        {
            var faker = new Faker();

            var itemList = ShoppingCartItemFakeData.BuildCartItemList();

            return new ShoppingCart(faker.Random.Guid(), ShoppingCartStatus.Pending, 
                itemList, DateTime.Now, DateTime.Now);
        }

        /// <summary>
        /// Gera lista de carrinho de compras para exibição
        /// </summary>
        /// <returns></returns>
        public static List<ShoppingCartListDTO> BuildDtoList()
        {
            var faker = new Faker();

            var result = new List<ShoppingCartListDTO>();

            for(int i = 1; i <= 5; i++)
            {
                var cart = Build();

                result.Add(new ShoppingCartListDTO(cart.Id, cart.Status, cart.InitialPrice, 
                    cart.Discounts, cart.FinalPrice, cart.UpdatedAt.ToString()));
            }

            return result;
        }
    }
}
