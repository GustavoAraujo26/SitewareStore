using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Tests.Mocks;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Tests.Helpers;
using SitewareStore.Domain.Services.Promotion;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Enums;

namespace SitewareStore.Tests.ServiceTests.Promotion
{
    public class SavePromotionServiceTests
    {
        [Fact]
        public async Task ShouldReturnSuccess_For_NewPromotion()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<ISavePromotionService>();

            var request = new SavePromotionRequest(null, "test", PromotionType.FullPriceByQuantity, 10, null, 10);

            var serviceResponse = await productService.Execute(request);

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnSuccess_For_OldPromotion()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<ISavePromotionService>();

            var request = new SavePromotionRequest(Guid.NewGuid(), "test", PromotionType.FullPriceByQuantity, 10, null, 10);

            var serviceResponse = await productService.Execute(request);

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_PromotionNotFound()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildFailure_For_Get().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<ISavePromotionService>();

            var request = new SavePromotionRequest(Guid.NewGuid(), "test", PromotionType.FullPriceByQuantity, 10, null, 10);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_InvalidRequest()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<ISavePromotionService>();

            var request = new SavePromotionRequest(Guid.NewGuid(), "test", PromotionType.FullPriceByQuantity, null, null, null);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_Exception()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildException_For_Get().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<ISavePromotionService>();

            var request = new SavePromotionRequest(Guid.NewGuid(), "test", PromotionType.FullPriceByQuantity, 10, null, 10);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }
    }
}
