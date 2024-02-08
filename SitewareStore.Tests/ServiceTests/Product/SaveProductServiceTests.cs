using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Tests.Mocks;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Enums;
using SitewareStore.Tests.Helpers;

namespace SitewareStore.Tests.ServiceTests.Product
{
    public class SaveProductServiceTests
    {
        [Fact]
        public async Task ShouldReturnSuccess_For_NewProduct()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<ISaveProductService>();

            var request = new SaveProductRequest(null, "Test", 22.50M, Guid.NewGuid());

            var serviceResponse = await productService.Execute(request);

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnSuccess_For_OldProduct()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<ISaveProductService>();

            var request = new SaveProductRequest(Guid.NewGuid(), "Test", 22.50M, Guid.NewGuid());

            var serviceResponse = await productService.Execute(request);

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnSuccess_For_OldProductWithoutPromotion()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<ISaveProductService>();

            var request = new SaveProductRequest(Guid.NewGuid(), "Test", 22.50M, null);

            var serviceResponse = await productService.Execute(request);

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_InvalidRequest()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<ISaveProductService>();

            var request = new SaveProductRequest(null, null, 22.50M, Guid.NewGuid());

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_ProductNotFound()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildFailure_For_Get().Object);
            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<ISaveProductService>();

            var request = new SaveProductRequest(Guid.NewGuid(), "Test", 22.50M, Guid.NewGuid());

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_Exception()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildException_For_Get().Object);
            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<ISaveProductService>();

            var request = new SaveProductRequest(Guid.NewGuid(), "Test", 22.50M, Guid.NewGuid());

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }
    }
}
