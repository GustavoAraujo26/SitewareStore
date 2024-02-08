using Microsoft.Data.SqlClient;
using SitewareStore.Domain.Repositories;
using SitewareStore.Infra.CrossCutting.Models;
using System.Transactions;

namespace SitewareStore.Infra.Data.Contracts
{
    public class RepositoryBase : IRepositoryBase
    {
        private readonly SitewareStoreDbConnection dbConnection;

        public RepositoryBase(SitewareStoreDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public void CompleteTransaction(TransactionScope transaction) =>
            transaction.Complete();

        public SqlConnection CreateDbConnection() =>
            new SqlConnection(dbConnection.DbConnectionString);

        public TransactionScope CreateTransaction() =>
            new TransactionScope();
    }
}
