USE [SitewareStoreDB]
GO

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
           ('30468c2f-85ba-412f-8bbf-01cc61188de5'
           ,'Padrão Siteware'
           ,2
           ,2
           ,null
           ,null
           ,1
           ,GETDATE()
           ,GETDATE())
GO

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
           ('41706f63-66d5-4f80-b1a8-f8adc5b0d23c'
           ,'Padrão Siteware'
           ,1
           ,3
           ,null
           ,10
           ,1
           ,GETDATE()
           ,GETDATE())
GO
