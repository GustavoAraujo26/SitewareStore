namespace SitewareStore.Infra.Data.Sql
{
    /// <summary>
    /// SQL relaciondo ao carrinho de compras
    /// </summary>
    internal static class ShoppingCartSql
    {
        /// <summary>
        /// Verifica se um carrinho de compras existe
        /// </summary>
        internal const string CheckIfExists = @"SELECT [pk-shopping-cart] FROM [SitewareStoreDB].[dbo].[ShoppingCart] WITH(NOLOCK) WHERE [pk-shopping-cart] = @id";
        
        /// <summary>
        /// Insere novo carrinho de compras
        /// </summary>
        internal const string Insert = @"
        INSERT INTO [dbo].[ShoppingCart]
               ([pk-shopping-cart]
               ,[status]
               ,[initial-price]
               ,[discounts]
               ,[final-price]
               ,[created-at]
               ,[updated-at])
         VALUES
               (@Id
               ,@Status
               ,@InitialPrice
               ,@Discounts
               ,@FinalPrice
               ,@CreatedAt
               ,@UpdatedAt)
        ";

        /// <summary>
        /// Atualiza carrinho de compras
        /// </summary>
        internal const string Update = @"
        UPDATE [dbo].[ShoppingCart]
           SET [status] = @Status
              ,[initial-price] = @InitialPrice
              ,[discounts] = @Discounts
              ,[final-price] = @FinalPrice
              ,[created-at] = @CreatedAt
              ,[updated-at] = @UpdatedAt
         WHERE [pk-shopping-cart] = @Id
        ";

        /// <summary>
        /// Lista todos os carrinhos de compras
        /// </summary>
        internal const string ListAll = @"
        SELECT [pk-shopping-cart] as 'Id'
              ,[status] as 'Status'
              ,[initial-price] as 'InitialPrice'
              ,[discounts] as 'Discounts'
              ,[final-price] as 'FinalPrice'
              ,[updated-at] as 'ChangeAt'
          FROM [SitewareStoreDB].[dbo].[ShoppingCart]
        ";

        /// <summary>
        /// Busca carrinho de compras pelo Id
        /// </summary>
        internal const string GetById = @"
        SELECT [pk-shopping-cart] as 'Id'
              ,[status] as 'Status'
              ,[initial-price] as 'InitialPrice'
              ,[discounts] as 'Discounts'
              ,[final-price] as 'FinalPrice'
              ,[created-at] as 'CreatedAt'
              ,[updated-at] as 'UpdatedAt'
          FROM [SitewareStoreDB].[dbo].[ShoppingCart] WITH(NOLOCK)
          WHERE [pk-shopping-cart] = @id
        ";
    }
}
