using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Tests.Mocks;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Tests.Helpers;
using SitewareStore.Tests.Mock;
using SitewareStore.Domain.Services.ShoppingCart;

namespace SitewareStore.Tests.ServiceTests.ShoppingCart
{
    public class ListShoppingCartServiceTests
    {
        [Fact]
        public async Task ShouldReturnSuccess()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IListShoppingCartService>();

            var serviceResponse = await productService.Execute();

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_Exception()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ShoppingCartRepositoryMock.BuildException_For_List().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IListShoppingCartService>();

            var serviceResponse = await productService.Execute();

            Assert.False(serviceResponse.IsSuccess());
        }
    }
}
