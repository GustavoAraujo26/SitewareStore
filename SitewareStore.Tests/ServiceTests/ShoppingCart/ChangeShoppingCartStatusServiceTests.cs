using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Tests.Mocks;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Tests.Helpers;
using SitewareStore.Domain.Requests;
using SitewareStore.Tests.Mock;
using SitewareStore.Domain.Services.ShoppingCart;
using SitewareStore.Domain.Enums;

namespace SitewareStore.Tests.ServiceTests.ShoppingCart
{
    public class ChangeShoppingCartStatusServiceTests
    {
        [Fact]
        public async Task ShouldReturnSuccess_For_Finished()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IChangeShoppingCartStatusService>();

            var request = new ChangeShoppingCartStatusRequest(Guid.NewGuid(), ShoppingCartStatus.Finished);

            var serviceResponse = await productService.Execute(request);

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnSuccess_For_Canceled()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IChangeShoppingCartStatusService>();

            var request = new ChangeShoppingCartStatusRequest(Guid.NewGuid(), ShoppingCartStatus.Canceled);

            var serviceResponse = await productService.Execute(request);

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_InvalidRequest()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IChangeShoppingCartStatusService>();

            var request = new ChangeShoppingCartStatusRequest(Guid.Empty, ShoppingCartStatus.Finished);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_CartNotFound()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildFailure_For_Get().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IChangeShoppingCartStatusService>();

            var request = new ChangeShoppingCartStatusRequest(Guid.NewGuid(), ShoppingCartStatus.Finished);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_Exception()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildException_For_Get().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IChangeShoppingCartStatusService>();

            var request = new ChangeShoppingCartStatusRequest(Guid.NewGuid(), ShoppingCartStatus.Finished);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }
    }
}
