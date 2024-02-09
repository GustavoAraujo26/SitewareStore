USE [SitewareStoreDB]
GO

/****** Object:  Table [dbo].[Promotion]    Script Date: 09/02/2024 15:57:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Promotion](
	[pk-promotion] [uniqueidentifier] NOT NULL,
	[observation] [varchar](500) NOT NULL,
	[type] [int] NOT NULL,
	[cut-quantity] [int] NULL,
	[percentage] [decimal](18, 2) NULL,
	[price] [decimal](18, 2) NULL,
	[status] [int] NOT NULL,
	[created-at] [datetime] NOT NULL,
	[updated-at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pk-promotion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


