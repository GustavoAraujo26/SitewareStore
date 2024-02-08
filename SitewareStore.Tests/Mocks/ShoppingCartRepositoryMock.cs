using Microsoft.Data.SqlClient;
using Moq;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Repositories;
using SitewareStore.Tests.FakeData;

namespace SitewareStore.Tests.Mock
{
    internal static class ShoppingCartRepositoryMock
    {
        internal static Mock<IShoppingCartRepository> BuildSuccess()
        {
            var mock = new Mock<IShoppingCartRepository>();

            mock.Setup(x => x.Save(It.IsAny<SqlConnection>(), It.IsAny<ShoppingCart>()))
                .Returns(Task.CompletedTask);

            mock.Setup(x => x.Get(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .ReturnsAsync(ShoppingCartFakeData.Build());

            mock.Setup(x => x.ListAll(It.IsAny<SqlConnection>()))
                .ReturnsAsync(ShoppingCartFakeData.BuildDtoList());

            return mock;
        }

        internal static Mock<IShoppingCartRepository> BuildFailure_For_Get()
        {
            var mock = BuildSuccess();

            mock.Setup(x => x.Get(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .ReturnsAsync((ShoppingCart)null);

            return mock;
        }

        internal static Mock<IShoppingCartRepository> BuildException_For_Get()
        {
            var mock = BuildSuccess();

            mock.Setup(x => x.Get(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .ThrowsAsync(new Exception("Fatal Error"));

            return mock;
        }

        internal static Mock<IShoppingCartRepository> BuildException_For_List()
        {
            var mock = BuildSuccess();

            mock.Setup(x => x.ListAll(It.IsAny<SqlConnection>()))
                .ThrowsAsync(new Exception("Fatal Error"));

            return mock;
        }
    }
}
