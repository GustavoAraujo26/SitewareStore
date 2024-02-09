using AutoMapper;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Entities;

namespace SitewareStore.Domain.Mappers.TypeConverters.DTOs
{
    /// <summary>
    /// Conversão das entidades de item do carrinho de compras em DTO's
    /// </summary>
    internal class ShoppingCartItemDtoTypeConverter : ITypeConverter<ShoppingCart, List<ShoppingCartItemDTO>>
    {
        public List<ShoppingCartItemDTO> Convert(ShoppingCart source, List<ShoppingCartItemDTO> destination, ResolutionContext context)
        {
            var result = new List<ShoppingCartItemDTO>();

            if (source.Items is null || !source.Items.Any())
                return result;

            foreach(var itemEntity in source.Items)
            {
                decimal initialPrice = decimal.Round(itemEntity.Quantity * itemEntity.Product.Price, 2);
                string promotionDescription = null;
                if (itemEntity.Product.PromotionApplied is not null)
                    promotionDescription = context.Mapper.Map<string>(itemEntity.Product.PromotionApplied);

                result.Add(new ShoppingCartItemDTO(itemEntity.Id, itemEntity.Product.Name, 
                    itemEntity.Quantity, itemEntity.Product.Price, promotionDescription, itemEntity.FinalPrice));
            }

            return result;
        }
    }
}
