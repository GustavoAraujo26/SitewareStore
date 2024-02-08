using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.TypeConverters.Models
{
    /// <summary>
    /// Conversor da entidade "item do carrinho de compras" para modelo de banco de dados
    /// </summary>
    internal class ShoppingCartItemModelTypeConverter : ITypeConverter<Tuple<Guid, List<ShoppingCartItem>>, List<ShoppingCartItemModel>>
    {
        public List<ShoppingCartItemModel> Convert(Tuple<Guid, List<ShoppingCartItem>> source, List<ShoppingCartItemModel> destination, ResolutionContext context)
        {
            var result = new List<ShoppingCartItemModel>();

            var cartId = source.Item1;
            var cartItems = source.Item2;

            if (cartItems is null || !cartItems.Any())
                return new List<ShoppingCartItemModel>();

            foreach (var item in cartItems)
            {
                var initialPrice = decimal.Round(item.Quantity * item.Product.Price, 2);
                var finalPrice = item.FinalPrice;
                var discount = finalPrice - initialPrice;

                result.Add(new ShoppingCartItemModel
                {
                    Id = item.Id,
                    ShoppingCartId = cartId,
                    ProductId = item.Product.Id,
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    InitialPrice = initialPrice,
                    Discount = discount,
                    FinalPrice = finalPrice,
                    PromotionApplied = context.Mapper.Map<string>(item)
                });
            }

            return result;
        }
    }
}
