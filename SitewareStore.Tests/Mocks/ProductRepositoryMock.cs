using Microsoft.Data.SqlClient;
using Moq;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Repositories;
using SitewareStore.Tests.FakeData;

namespace SitewareStore.Tests.Mocks
{
    /// <summary>
    /// Mock do repositório de produto
    /// </summary>
    internal static class ProductRepositoryMock
    {
        /// <summary>
        /// Gera repositório para caso de sucesso ao buscar e salvar produto
        /// </summary>
        /// <returns></returns>
        public static IProductRepository BuildSuccess_For_GetSave()
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(x => x.Get(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .ReturnsAsync(ProductFakeData.BuildEntity(PromotionType.FullPriceByQuantity, StatusType.Active));

            mock.Setup(x => x.Save(It.IsAny<SqlConnection>(), It.IsAny<Product>()))
                .Returns(Task.CompletedTask);

            return mock.Object;
        }

        /// <summary>
        /// Gera repositório para caso de retorno nulo do método GET
        /// </summary>
        /// <returns></returns>
        public static IProductRepository BuildFailure_For_Get()
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(x => x.Get(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .ReturnsAsync((Product)null);

            mock.Setup(x => x.Save(It.IsAny<SqlConnection>(), It.IsAny<Product>()))
                .Returns(Task.CompletedTask);

            return mock.Object;
        }

        /// <summary>
        /// Gera repositório para caso de falha do método GET
        /// </summary>
        /// <returns></returns>
        public static IProductRepository BuildException_For_Get()
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(x => x.Get(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .ThrowsAsync(new Exception("Fatal error"));

            mock.Setup(x => x.Save(It.IsAny<SqlConnection>(), It.IsAny<Product>()))
                .Returns(Task.CompletedTask);

            return mock.Object;
        }
    }
}
