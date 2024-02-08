using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Mappers.TypeConverters;
using SitewareStore.Domain.Mappers.TypeConverters.Models;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.Profiles
{
    /// <summary>
    /// Configuração dos conversores de entidades para modelos
    /// </summary>
    internal class ModelsProfile : Profile
    {
        public ModelsProfile()
        {
            CreateMap<Product, ProductModel>()
                .ConvertUsing<ProductModelTypeConverter>();

            CreateMap<Promotion, PromotionModel>()
                .ConvertUsing<PromotionModelTypeConverter>();

            CreateMap<ShoppingCart, List<ShoppingCartItemModel>>()
                .ConvertUsing<ShoppingCartItemModelTypeConverter>();

            CreateMap<ShoppingCart, ShoppingCartModel>()
                .ConvertUsing<ShoppingCartModelTypeConverter>();

            CreateMap<Promotion, string>()
                .ConvertUsing<PromotionDescriptionTypeConverter>();
        }
    }
}
