/****** Object:  Table [dbo].[SubscriptionType]    Script Date: 02/13/2011 17:59:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubscriptionType]') AND type in (N'U'))
DROP TABLE [dbo].[SubscriptionType]
GO

/****** Object:  Table [dbo].[SubscriptionType]    Script Date: 02/13/2011 17:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubscriptionType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SubscriptionType](
	[SubscriptionTypeId] [int] NOT NULL,
	[TypeName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_SubscriptionType] PRIMARY KEY CLUSTERED 
(
	[SubscriptionTypeId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
