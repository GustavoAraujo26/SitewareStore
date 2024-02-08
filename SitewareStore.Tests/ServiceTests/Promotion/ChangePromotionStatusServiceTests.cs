using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Tests.Mocks;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Enums;
using SitewareStore.Tests.Helpers;
using SitewareStore.Domain.Services.Promotion;

namespace SitewareStore.Tests.ServiceTests.Promotion
{
    public class ChangePromotionStatusServiceTests
    {
        [Fact]
        public async Task ShouldReturnSuccess_For_Activation()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IChangePromotionStatusService>();

            var request = new ChangePromotionStatusRequest(Guid.NewGuid(), StatusType.Active);

            var serviceResponse = await productService.Execute(request);

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnSuccess_For_Cancellation()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IChangePromotionStatusService>();

            var request = new ChangePromotionStatusRequest(Guid.NewGuid(), StatusType.Cancelled);

            var serviceResponse = await productService.Execute(request);

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_InvalidRequest()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildSuccess().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IChangePromotionStatusService>();

            var request = new ChangePromotionStatusRequest(Guid.Empty, StatusType.Cancelled);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_Exception()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => PromotionRepositoryMock.BuildException_For_Get().Object);
            services.AddTransient(mock => RepositoryBaseMock.Build().Object);

            var productService = services.GetService<IChangePromotionStatusService>();

            var request = new ChangePromotionStatusRequest(Guid.NewGuid(), StatusType.Active);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }
    }
}
