using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Domain.Services.Promotion;
using SitewareStore.Domain.Services.ShoppingCart;
using SitewareStore.Service.Contracts.Product;
using SitewareStore.Service.Contracts.Promotion;
using SitewareStore.Service.Contracts.ShoppingCart;

namespace SitewareStore.Service.Extensions
{
    /// <summary>
    /// Extensões para a camada de serviço
    /// </summary>
    public static class ServiceExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IChangeProductStatusService, ChangeProductStatusService>();
            services.AddScoped<IDeleteProductService, DeleteProductService>();
            services.AddScoped<IGetProductService, GetProductService>();
            services.AddScoped<IListActiveProductService, ListActiveProductService>();
            services.AddScoped<IListProductService, ListProductService>();
            services.AddScoped<ISaveProductService, SaveProductService>();

            services.AddScoped<IChangePromotionStatusService, ChangePromotionStatusService>();
            services.AddScoped<IDeletePromotionService, DeletePromotionService>();
            services.AddScoped<IGetPromotionService, GetPromotionService>();
            services.AddScoped<IListActivePromotionService, ListActivePromotionService>();
            services.AddScoped<IListPromotionService, ListPromotionService>();
            services.AddScoped<ISavePromotionService, SavePromotionService>();

            services.AddScoped<IAddShoppingCartItemService, AddShoppingCartItemService>();
            services.AddScoped<IChangeShoppingCartStatusService, ChangeShoppingCartStatusService>();
            services.AddScoped<IDeleteShoppingCartItemService, DeleteShoppingCartItemService>();
            services.AddScoped<IGetShoppingCartService, GetShoppingCartService>();
            services.AddScoped<IInitializeShoppingCartService, InitializeShoppingCartService>();
            services.AddScoped<IListShoppingCartService, ListShoppingCartService>();
            services.AddScoped<IUpdateShoppingCartItemService, UpdateShoppingCartItemService>();
        }
    }
}
