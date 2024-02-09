USE [SitewareStoreDB]
GO

/****** Object:  Table [dbo].[ShoppingCart]    Script Date: 09/02/2024 15:58:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ShoppingCart](
	[pk-shopping-cart] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[initial-price] [decimal](18, 2) NOT NULL,
	[discounts] [decimal](18, 2) NOT NULL,
	[final-price] [decimal](18, 2) NOT NULL,
	[created-at] [datetime] NOT NULL,
	[updated-at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pk-shopping-cart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


