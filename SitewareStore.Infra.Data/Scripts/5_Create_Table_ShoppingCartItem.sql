USE [SitewareStoreDB]
GO

/****** Object:  Table [dbo].[ShoppingCartItem]    Script Date: 09/02/2024 15:59:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ShoppingCartItem](
	[pk-shopping-cart-item] [uniqueidentifier] NOT NULL,
	[fk-shopping-cart] [uniqueidentifier] NOT NULL,
	[fk-product] [uniqueidentifier] NOT NULL,
	[product-name] [varchar](500) NOT NULL,
	[quantity] [int] NOT NULL,
	[initial-price] [decimal](18, 2) NOT NULL,
	[discount] [decimal](18, 2) NOT NULL,
	[final-price] [decimal](18, 2) NOT NULL,
	[promotion-applied] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[pk-shopping-cart-item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ShoppingCartItem]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCartItem_ShoppingCart] FOREIGN KEY([fk-shopping-cart])
REFERENCES [dbo].[ShoppingCart] ([pk-shopping-cart])
GO

ALTER TABLE [dbo].[ShoppingCartItem] CHECK CONSTRAINT [FK_ShoppingCartItem_ShoppingCart]
GO


