using Microsoft.Data.SqlClient;
using Moq;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Repositories;
using SitewareStore.Tests.FakeData;

namespace SitewareStore.Tests.Mocks
{
    internal static class ShoppingCartItemRepositoryMock
    {
        public static Mock<IShoppingCartItemRepository> BuildSuccess()
        {
            var mock = new Mock<IShoppingCartItemRepository>();

            mock.Setup(x => x.Get(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .ReturnsAsync(ShoppingCartItemFakeData.BuildCartItem());

            return mock;
        }

        public static Mock<IShoppingCartItemRepository> BuildFailure_For_Get()
        {
            var mock = new Mock<IShoppingCartItemRepository>();

            mock.Setup(x => x.Get(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .ReturnsAsync((ShoppingCartItem)null);

            return mock;
        }

        public static Mock<IShoppingCartItemRepository> BuildFailure_For_Exception()
        {
            var mock = new Mock<IShoppingCartItemRepository>();

            mock.Setup(x => x.Get(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .ThrowsAsync(new Exception("Fatal Error"));

            return mock;
        }
    }
}
