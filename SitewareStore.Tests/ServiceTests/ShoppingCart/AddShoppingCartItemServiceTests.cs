using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Tests.Mocks;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Tests.Helpers;
using SitewareStore.Domain.Requests;
using SitewareStore.Tests.Mock;
using SitewareStore.Domain.Services.ShoppingCart;

namespace SitewareStore.Tests.ServiceTests.ShoppingCart
{
    public class AddShoppingCartItemServiceTests
    {
        [Fact]
        public async Task ShouldReturnSuccess()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => ProductRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IAddShoppingCartItemService>();

            var request = new AddShoppingCartItemRequest(Guid.NewGuid(), Guid.NewGuid(), 10);

            var serviceResponse = await productService.Execute(request);

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_InvalidRequest()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => ProductRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IAddShoppingCartItemService>();

            var request = new AddShoppingCartItemRequest(Guid.Empty, Guid.Empty, 10);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_CartNotFound()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildFailure_For_Get().Object);
            services.AddTransient(mock => ProductRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IAddShoppingCartItemService>();

            var request = new AddShoppingCartItemRequest(Guid.NewGuid(), Guid.NewGuid(), 10);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_ProductNotFound()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => ProductRepositoryMock.BuildFailure_For_Get().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IAddShoppingCartItemService>();

            var request = new AddShoppingCartItemRequest(Guid.NewGuid(), Guid.NewGuid(), 10);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_Exception()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildException_For_Get().Object);
            services.AddTransient(mock => ProductRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IAddShoppingCartItemService>();

            var request = new AddShoppingCartItemRequest(Guid.NewGuid(), Guid.NewGuid(), 10);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }
    }
}
