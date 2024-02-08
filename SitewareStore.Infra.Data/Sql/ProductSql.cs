namespace SitewareStore.Infra.Data.Sql
{
    /// <summary>
    /// SQL relacionado ao produto
    /// </summary>
    internal static class ProductSql
    {
        /// <summary>
        /// Verifica se um produto já existe
        /// </summary>
        internal const string CheckIfExists = "SELECT [pk-product] FROM [dbo].[Product] WITH(NOLOCK) WHERE [pk-product] = @id";

        /// <summary>
        /// Apaga um produto
        /// </summary>
        internal const string Delete = "DELETE FROM [dbo].[Product] WHERE [pk-product] = @id";

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        internal const string Update = @"
        UPDATE [dbo].[Product]
           SET [name] = @Name
              ,[price] = @Price
              ,[status] = @Status
              ,[fk-promotion] = @PromotionId
              ,[created-at] = @CreatedAt
              ,[updated-at] = @UpdatedAt
         WHERE [pk-product] = @Id
        ";

        /// <summary>
        /// Insere um produto
        /// </summary>
        internal const string Insert = @"
        INSERT INTO [dbo].[Product]
               ([pk-product]
               ,[name]
               ,[price]
               ,[status]
               ,[fk-promotion]
               ,[created-at]
               ,[updated-at])
         VALUES
               (@Id
               ,@Name
               ,@Price
               ,@Status
               ,@PromotionId
               ,@CreatedAt
               ,@UpdatedAt)
        ";

        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        internal const string ListAll = @"
        SELECT [pk-product] as 'Id'
            ,[name] as 'Name'
            ,[price] as 'Price'
            ,[status] as 'Status'
            ,[fk-promotion] as 'PromotionApplied'
            ,[updated-at] as 'ChangeAt'
        FROM [SitewareStoreDB].[dbo].[Product] WITH(NOLOCK)
        ";

        /// <summary>
        /// Lista todos os produtos ativos
        /// </summary>
        internal const string ListActives = @"
        SELECT [pk-product] as 'Id'
            ,[name] as 'Name'
            ,[price] as 'Price'
            ,[status] as 'Status'
            ,[fk-promotion] as 'PromotionApplied'
            ,[updated-at] as 'ChangeAt'
        FROM [SitewareStoreDB].[dbo].[Product] WITH(NOLOCK)
        WHERE [status] = 1
        ";

        /// <summary>
        /// Busca um produto pelo seu Id
        /// </summary>
        internal const string GetById = @"
        SELECT [pk-product] as 'Id'
            ,[name] as 'Name'
            ,[price] as 'Price'
            ,[status] as 'Status'
            ,[fk-promotion] as 'PromotionId'
            ,[created-at] as 'CreatedAt'
            ,[updated-at] as 'UpdatedAt'
        FROM [SitewareStoreDB].[dbo].[Product] WITH(NOLOCK)
        WHERE [pk-product] = @id
        ";
    }
}
