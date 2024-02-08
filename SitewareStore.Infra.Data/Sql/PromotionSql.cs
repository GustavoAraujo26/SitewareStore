namespace SitewareStore.Infra.Data.Sql
{
    /// <summary>
    /// SQL relacionado à promoção
    /// </summary>
    internal static class PromotionSql
    {
        /// <summary>
        /// Verifica se uma promoção já existe
        /// </summary>
        internal const string CheckIfExists = @"SELECT [pk-promotion] FROM [SitewareStoreDB].[dbo].[Promotion] WITH(NOLOCK) WHERE [pk-promotion] = @id";

        /// <summary>
        /// Insere uma promoção
        /// </summary>
        internal const string Insert = @"
        INSERT INTO [dbo].[Promotion]
               ([pk-promotion]
               ,[observation]
               ,[type]
               ,[cut-quantity]
               ,[percentage]
               ,[price]
               ,[status]
               ,[created-at]
               ,[updated-at])
         VALUES
               (@Id
               ,@Observation
               ,@Type
               ,@CutQuantity
               ,@Percentage
               ,@Price
               ,@Status
               ,@CreatedAt
               ,@UpdatedAt)
        ";

        /// <summary>
        /// Atualiza uma promoção
        /// </summary>
        internal const string Update = @"
        UPDATE [dbo].[Promotion]
           SET [observation] = @Observation
              ,[type] = @Type
              ,[cut-quantity] = @CutQuantity
              ,[percentage] = @Percentage
              ,[price] = @Price
              ,[status] = @Status
              ,[created-at] = @CreatedAt
              ,[updated-at] = @UpdatedAt
         WHERE [pk-promotion] = @Id
        ";

        /// <summary>
        /// Lista todas as promoções
        /// </summary>
        internal const string ListAll = @"
        SELECT [pk-promotion] as 'Id'
              ,[observation] as 'Observation'
              ,[type] as 'Type'
              ,[cut-quantity] as 'CutQuantity'
              ,[percentage] as 'Percentage'
              ,[price] as 'Price'
              ,[status] as 'Status'
              ,[created-at] as 'CreatedAt'
              ,[updated-at] as 'UpdatedAt'
          FROM [SitewareStoreDB].[dbo].[Promotion] WITH(NOLOCK)
        ";

        /// <summary>
        /// Lista todas as promoções ativas
        /// </summary>
        internal const string ListActives = @"
        SELECT [pk-promotion] as 'Id'
              ,[observation] as 'Observation'
              ,[type] as 'Type'
              ,[cut-quantity] as 'CutQuantity'
              ,[percentage] as 'Percentage'
              ,[price] as 'Price'
              ,[status] as 'Status'
              ,[created-at] as 'CreatedAt'
              ,[updated-at] as 'UpdatedAt'
          FROM [SitewareStoreDB].[dbo].[Promotion] WITH(NOLOCK)
          WHERE [status] = 1
        ";

        /// <summary>
        /// Busca uma promoção pelo Id
        /// </summary>
        internal const string GetById = @"
        SELECT [pk-promotion] as 'Id'
              ,[observation] as 'Observation'
              ,[type] as 'Type'
              ,[cut-quantity] as 'CutQuantity'
              ,[percentage] as 'Percentage'
              ,[price] as 'Price'
              ,[status] as 'Status'
              ,[created-at] as 'CreatedAt'
              ,[updated-at] as 'UpdatedAt'
          FROM [SitewareStoreDB].[dbo].[Promotion] WITH(NOLOCK)
          WHERE [pk-promotion] = @id
        ";

        /// <summary>
        /// Apaga uma promoção
        /// </summary>
        internal const string Delete = @"DELETE FROM [dbo].[Promotion] WHERE [pk-promotion] = @id";
    }
}
