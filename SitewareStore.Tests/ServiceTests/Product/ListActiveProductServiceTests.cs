using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Tests.Helpers;
using SitewareStore.Tests.Mocks;
using SitewareStore.Infra.CrossCutting.Extensions;

namespace SitewareStore.Tests.ServiceTests.Product
{
    public class ListActiveProductServiceTests
    {
        [Fact]
        public async Task ShouldReturnSuccess()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IListActiveProductService>();

            var serviceResponse = await productService.Execute();

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_Exception()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildException_For_ListActives().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IListActiveProductService>();

            var serviceResponse = await productService.Execute();

            Assert.False(serviceResponse.IsSuccess());
        }
    }
}
