using Microsoft.Data.SqlClient;
using System.Transactions;

namespace SitewareStore.Domain.Repositories
{
    /// <summary>
    /// Interface base do repositório
    /// </summary>
    public interface IRepositoryBase
    {
        /// <summary>
        /// Cria nova conexão com o banco de dados
        /// </summary>
        /// <returns></returns>
        SqlConnection CreateDbConnection();

        /// <summary>
        /// Cria nova transação
        /// </summary>
        /// <returns></returns>
        TransactionScope CreateTransaction();

        /// <summary>
        /// Completa a transação atual
        /// </summary>
        /// <param name="transaction">Transação atual</param>
        void CompleteTransaction(TransactionScope transaction);
    }
}
