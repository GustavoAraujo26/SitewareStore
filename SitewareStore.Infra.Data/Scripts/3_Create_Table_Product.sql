USE [SitewareStoreDB]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 09/02/2024 15:58:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[pk-product] [uniqueidentifier] NOT NULL,
	[name] [varchar](500) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[status] [int] NOT NULL,
	[fk-promotion] [uniqueidentifier] NULL,
	[created-at] [datetime] NOT NULL,
	[updated-at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pk-product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_To_Promotion] FOREIGN KEY([fk-promotion])
REFERENCES [dbo].[Promotion] ([pk-promotion])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_To_Promotion]
GO


