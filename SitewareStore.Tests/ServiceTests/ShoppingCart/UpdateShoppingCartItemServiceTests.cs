using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Tests.Mocks;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Tests.Helpers;
using SitewareStore.Tests.Mock;
using SitewareStore.Domain.Services.ShoppingCart;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Tests.ServiceTests.ShoppingCart
{
    public class UpdateShoppingCartItemServiceTests
    {
        [Fact]
        public async Task ShouldReturnSuccess_For_QuantityUpdate()
        {
            var request = new UpdateShoppingCartItemRequest(Guid.NewGuid(), Guid.NewGuid(), 10);

            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildSuccess(request.ShoppingCartItemId).Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IUpdateShoppingCartItemService>();

            var serviceResponse = await productService.Execute(request);

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnSuccess_For_RemovingItem()
        {
            var request = new UpdateShoppingCartItemRequest(Guid.NewGuid(), Guid.NewGuid(), 0);

            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildSuccess(request.ShoppingCartItemId).Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IUpdateShoppingCartItemService>();

            var serviceResponse = await productService.Execute(request);

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_InvalidRequest()
        {
            var request = new UpdateShoppingCartItemRequest(Guid.NewGuid(), Guid.NewGuid(), 10);

            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildSuccess(request.ShoppingCartItemId).Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IUpdateShoppingCartItemService>();

            var serviceResponse = await productService.Execute(new UpdateShoppingCartItemRequest());

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_ItemNotFound()
        {
            var request = new UpdateShoppingCartItemRequest(Guid.NewGuid(), Guid.NewGuid(), 10);

            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IUpdateShoppingCartItemService>();

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_CartNotFound()
        {
            var request = new UpdateShoppingCartItemRequest(Guid.NewGuid(), Guid.NewGuid(), 10);

            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildFailure_For_Get().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IUpdateShoppingCartItemService>();

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_Exception()
        {
            var request = new UpdateShoppingCartItemRequest(Guid.NewGuid(), Guid.NewGuid(), 10);

            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildException_For_Get().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IUpdateShoppingCartItemService>();

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }
    }
}
