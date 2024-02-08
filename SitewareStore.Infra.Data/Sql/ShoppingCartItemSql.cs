using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitewareStore.Infra.Data.Sql
{
    internal static class ShoppingCartItemSql
    {
        internal const string CheckIfExists = @"SELECT [pk-shopping-cart-item] FROM [SitewareStoreDB].[dbo].[ShoppingCartItem] WITH(NOLOCK) WHERE [pk-shopping-cart-item] = @id";

        internal const string Delete = "DELETE FROM [dbo].[ShoppingCartItem] WHERE [pk-shopping-cart-item] = @id";

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
    }
}
