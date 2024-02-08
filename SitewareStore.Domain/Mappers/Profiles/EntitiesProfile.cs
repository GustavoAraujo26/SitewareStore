using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Mappers.TypeConverters.Entities;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.Profiles
{
    /// <summary>
    /// Configuração dos conversores de modelo para entidade
    /// </summary>
    internal class EntitiesProfile : Profile
    {
        public EntitiesProfile()
        {
            CreateMap<Tuple<ProductModel, Promotion>, Product>()
                .ConvertUsing<ProductEntityTypeConverter>();

            CreateMap<PromotionModel, Promotion>()
                .ConvertUsing<PromotionEntityTypeConverter>();

            CreateMap<Tuple<ShoppingCartModel, List<ShoppingCartItemModel>>, ShoppingCart>()
                .ConvertUsing<ShoppingCartEntityTypeConverter>();

            CreateMap<Tuple<ShoppingCartItemModel, Product>, ShoppingCartItem>()
                .ConvertUsing<ShoppingCartItemEntityTypeConverter>();
        }
    }
}
