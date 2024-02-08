using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Tests.Mocks;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Tests.Helpers;
using SitewareStore.Domain.Services.Promotion;

namespace SitewareStore.Tests.ServiceTests.Promotion
{
    public class ListActivePromotionServiceTests
    {
        [Fact]
        public async Task ShouldReturnSuccess()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IListActivePromotionService>();

            var serviceResponse = await productService.Execute();

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_Exception()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildFailure_For_ExceptionOnListActive().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IListActivePromotionService>();

            var serviceResponse = await productService.Execute();

            Assert.False(serviceResponse.IsSuccess());
        }
    }
}
