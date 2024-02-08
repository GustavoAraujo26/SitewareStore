using Microsoft.Extensions.DependencyInjection;
using SitewareStore.Tests.Mocks;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Enums;
using SitewareStore.Tests.Helpers;

namespace SitewareStore.Tests.ServiceTests.Product
{
    public class ChangeProductStatusServiceTests
    {
        [Fact]
        public async Task ShouldReturnSuccess_For_Activation()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildSuccess_For_GetSave());
            services.AddTransient(mock => RepositoryBaseMock.Build());

            var productService = services.GetService<IChangeProductStatusService>();

            var request = new ChangeProductStatusRequest(Guid.NewGuid(), StatusType.Active);

            var serviceResponse = await productService.Execute(request);

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnSuccess_For_Cancellation()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildSuccess_For_GetSave());
            services.AddTransient(mock => RepositoryBaseMock.Build());

            var productService = services.GetService<IChangeProductStatusService>();

            var request = new ChangeProductStatusRequest(Guid.NewGuid(), StatusType.Cancelled);

            var serviceResponse = await productService.Execute(request);

            Assert.True(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_RequestValidation()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildSuccess_For_GetSave());
            services.AddTransient(mock => RepositoryBaseMock.Build());

            var productService = services.GetService<IChangeProductStatusService>();

            var request = new ChangeProductStatusRequest(Guid.Empty, StatusType.Active);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_ProductNotFound()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildFailure_For_Get());
            services.AddTransient(mock => RepositoryBaseMock.Build());

            var productService = services.GetService<IChangeProductStatusService>();

            var request = new ChangeProductStatusRequest(Guid.NewGuid(), StatusType.Active);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }

        [Fact]
        public async Task ShouldReturnFailure_For_ExceptionOnGet()
        {
            var services = ServiceCollectionBuilder.BuildServiceCollection();

            services.AddTransient(mock => ProductRepositoryMock.BuildException_For_GetSave());
            services.AddTransient(mock => RepositoryBaseMock.Build());

            var productService = services.GetService<IChangeProductStatusService>();

            var request = new ChangeProductStatusRequest(Guid.NewGuid(), StatusType.Active);

            var serviceResponse = await productService.Execute(request);

            Assert.False(serviceResponse.IsSuccess());
        }
    }
}
