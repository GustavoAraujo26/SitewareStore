using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.TypeConverters.Entities
{
    /// <summary>
    /// Conversor do modelo de banco de dados de "item do carrinho" para entidade
    /// </summary>
    internal class ShoppingCartItemEntityTypeConverter : 
        ITypeConverter<Tuple<ShoppingCartItemModel, ProductModel, PromotionModel>, ShoppingCartItem>
    {
        public ShoppingCartItem Convert(Tuple<ShoppingCartItemModel, ProductModel, PromotionModel> source, ShoppingCartItem destination, ResolutionContext context)
        {
            var cartItemModel = source.Item1;
            var productModel = source.Item2;
            var promotionModel = source.Item3;

            var productEntity = context.Mapper.Map<Product>(new Tuple<ProductModel, PromotionModel>(productModel, promotionModel));

            return new ShoppingCartItem(cartItemModel.Id, productEntity, cartItemModel.Quantity);
        }
    }
}
