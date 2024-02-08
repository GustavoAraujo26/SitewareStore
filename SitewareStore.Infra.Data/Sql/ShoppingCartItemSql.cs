namespace SitewareStore.Infra.Data.Sql
{
    /// <summary>
    /// SQL relacionado aos itens do carrinho de compras
    /// </summary>
    internal static class ShoppingCartItemSql
    {
        /// <summary>
        /// Verifica se um item existe
        /// </summary>
        internal const string CheckIfExists = @"SELECT [pk-shopping-cart-item] FROM [SitewareStoreDB].[dbo].[ShoppingCartItem] WITH(NOLOCK) WHERE [pk-shopping-cart-item] = @id";

        /// <summary>
        /// Apaga um item
        /// </summary>
        internal const string Delete = "DELETE FROM [dbo].[ShoppingCartItem] WHERE [pk-shopping-cart-item] = @id";

        /// <summary>
        /// Insere um item
        /// </summary>
        internal const string Insert = @"
        INSERT INTO [dbo].[ShoppingCartItem]
               ([pk-shopping-cart-item]
               ,[fk-shopping-cart]
               ,[fk-product]
               ,[product-name]
               ,[quantity]
               ,[initial-price]
               ,[discount]
               ,[final-price]
               ,[promotion-applied])
         VALUES
               (@Id
               ,@ShoppingCartId
               ,@ProductId
               ,@ProductName
               ,@Quantity
               ,@InitialPrice
               ,@Discount
               ,@FinalPrice
               ,@PromotionApplied)
        ";

        /// <summary>
        /// Atualiza um item
        /// </summary>
        internal const string Update = @"
        UPDATE [dbo].[ShoppingCartItem]
           SET [fk-shopping-cart] = @ShoppingCartId
              ,[fk-product] = @ProductId
              ,[product-name] = @ProductName
              ,[quantity] = @Quantity
              ,[initial-price] = @InitialPrice
              ,[discount] = @Discount
              ,[final-price] = @FinalPrice
              ,[promotion-applied] = @PromotionApplied
         WHERE [pk-shopping-cart-item] = @Id
        ";

        /// <summary>
        /// Lista itens pelo ID do carrinho
        /// </summary>
        internal const string ListByCartId = @"
        SELECT [pk-shopping-cart-item] as 'Id'
              ,[fk-shopping-cart] as 'ShoppingCartId'
              ,[fk-product] as 'ProductId'
              ,[product-name] as 'ProductName'
              ,[quantity] as 'Quantity'
              ,[initial-price] as 'InitialPrice'
              ,[discount] as 'Discount'
              ,[final-price] as 'FinalPrice'
              ,[promotion-applied] as 'PromotionApplied'
          FROM [SitewareStoreDB].[dbo].[ShoppingCartItem] WITH(NOLOCK)
          WHERE [fk-shopping-cart] = @cartId
        ";

        /// <summary>
        /// Busca item pelo Id
        /// </summary>
        internal const string GetById = @"
        SELECT [pk-shopping-cart-item] as 'Id'
              ,[fk-shopping-cart] as 'ShoppingCartId'
              ,[fk-product] as 'ProductId'
              ,[product-name] as 'ProductName'
              ,[quantity] as 'Quantity'
              ,[initial-price] as 'InitialPrice'
              ,[discount] as 'Discount'
              ,[final-price] as 'FinalPrice'
              ,[promotion-applied] as 'PromotionApplied'
          FROM [SitewareStoreDB].[dbo].[ShoppingCartItem] WITH(NOLOCK)
          WHERE [pk-shopping-cart-item] = @id
        ";
    }
}
