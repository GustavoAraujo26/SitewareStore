namespace SitewareStore.Infra.CrossCutting.Models
{
    /// <summary>
    /// Classe de criação de conexão com o banco de dados
    /// </summary>
    public sealed class SitewareStoreDbConnection
    {
        private static SitewareStoreDbConnection _instance = null;
        private static readonly object locker = new object();

        SitewareStoreDbConnection() { }

        /// <summary>
        /// Instância da classe
        /// </summary>
        public static SitewareStoreDbConnection Instance
        {
            get
            {
                lock (locker)
                {
                    if (_instance is null)
                        _instance = new SitewareStoreDbConnection();

                    return _instance;
                }
            }
        }

        /// <summary>
        /// String de conexão com o banco de dados
        /// </summary>
        public string DbConnectionString
        {
            get
            {
                return Environment.GetEnvironmentVariable("LOCALDB_CONNECTION_STRING");
            }
        }
    }
}
