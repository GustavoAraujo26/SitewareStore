using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.TypeConverters.Models
{
    /// <summary>
    /// Conversor da entidade "item do carrinho de compras" para modelo de banco de dados
    /// </summary>
    internal class ShoppingCartItemModelTypeConverter : ITypeConverter<ShoppingCart, List<ShoppingCartItemModel>>
    {
        public List<ShoppingCartItemModel> Convert(ShoppingCart source, List<ShoppingCartItemModel> destination, ResolutionContext context)
        {
            var result = new List<ShoppingCartItemModel>();

            if (source.Items is null || !source.Items.Any())
                return new List<ShoppingCartItemModel>();

            foreach (var item in source.Items)
            {
                var initialPrice = decimal.Round(item.Quantity * item.Product.Price, 2);
                var finalPrice = item.FinalPrice;
                var discount = finalPrice - initialPrice;

                result.Add(new ShoppingCartItemModel
                {
                    Id = item.Id,
                    ShoppingCartId = source.Id,
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
