using Microsoft.Data.SqlClient;
using Moq;
using SitewareStore.Domain.Repositories;
using System.Transactions;

namespace SitewareStore.Tests.Mocks
{
    /// <summary>
    /// Mock do repositório base
    /// </summary>
    internal static class RepositoryBaseMock
    {
        /// <summary>
        /// Gera mock do repositório base
        /// </summary>
        /// <returns></returns>
        public static IRepositoryBase Build()
        {
            var mock = new Mock<IRepositoryBase>();

            mock.Setup(x => x.CreateDbConnection())
                .Returns(new SqlConnection());

            mock.Setup(x => x.CreateTransaction())
                .Returns(new TransactionScope());

            mock.Setup(x => x.CompleteTransaction(It.IsAny<TransactionScope>()));

            return mock.Object;
        }
    }
}
