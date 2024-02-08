using Microsoft.Data.SqlClient;
using Moq;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Repositories;
using SitewareStore.Tests.FakeData;

namespace SitewareStore.Tests.Mocks
{
    internal static class ProductRepositoryMock
    {
        public static Mock<IProductRepository> BuildSuccess()
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(x => x.Get(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .ReturnsAsync(ProductFakeData.BuildEntity(PromotionType.FullPriceByQuantity, StatusType.Active));

            mock.Setup(x => x.Save(It.IsAny<SqlConnection>(), It.IsAny<Product>()))
                .Returns(Task.CompletedTask);

            mock.Setup(x => x.Delete(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .Returns(Task.CompletedTask);

            mock.Setup(x => x.ListActives(It.IsAny<SqlConnection>()))
                .ReturnsAsync(ProductFakeData.BuildDtoList());

            mock.Setup(x => x.ListAll(It.IsAny<SqlConnection>()))
                .ReturnsAsync(ProductFakeData.BuildDtoList());

            mock.Setup(x => x.ListNamesByPromotionId(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .ReturnsAsync(ProductFakeData.BuildFakeProductNameList());

            return mock;
        }

        public static Mock<IProductRepository> BuildFailure_For_Get()
        {
            var mock = BuildSuccess();

            mock.Setup(x => x.Get(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .ReturnsAsync((Product)null);

            return mock;
        }

        public static Mock<IProductRepository> BuildException_For_Get()
        {
            var mock = BuildSuccess();

            mock.Setup(x => x.Get(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .ThrowsAsync(new Exception("Fatal error"));

            return mock;
        }

        public static Mock<IProductRepository> BuildException_For_ListActives()
        {
            var mock = BuildSuccess();

            mock.Setup(x => x.ListActives(It.IsAny<SqlConnection>()))
                .ThrowsAsync(new Exception("Fatal Error"));

            return mock;
        }

        public static Mock<IProductRepository> BuildException_For_ListAll()
        {
            var mock = BuildSuccess();

            mock.Setup(x => x.ListAll(It.IsAny<SqlConnection>()))
                .ThrowsAsync(new Exception("Fatal Error"));

            return mock;
        }
    }
}
