using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Tests.Helpers;
using SitewareStore.Tests.Mocks;
using SitewareStore.Infra.CrossCutting.Extensions;

namespace SitewareStore.Tests.ServiceTests.Product
{
    public class GetProductServiceTests
    {
        [Fact]
        public async Task ShouldReturnSuccess()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IGetProductService>();

            var serviceResponse = await productService.Execute(Guid.NewGuid());

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_InvalidId()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IGetProductService>();

            var serviceResponse = await productService.Execute(Guid.Empty);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_ProductNotFound()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildFailure_For_Get().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IGetProductService>();

            var serviceResponse = await productService.Execute(Guid.NewGuid());

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_Exception()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildException_For_Get().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IGetProductService>();

            var serviceResponse = await productService.Execute(Guid.NewGuid());

            Assert.False(serviceResponse.IsSuccess());
        }
    }
}
