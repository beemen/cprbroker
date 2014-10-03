/****** Object:  Table [dbo].[BudgetInterval]    Script Date: 11/28/2013 16:33:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BudgetInterval](
	[IntervalMilliseconds] [bigint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CallThreshold] [int] NULL,
	[CostThreshold] [decimal](18, 4) NULL,
	[LastChecked] [datetime] NULL,
 CONSTRAINT [PK_BudgetInterval] PRIMARY KEY CLUSTERED 
(
	[IntervalMilliseconds] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DataChangeEvent]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DataChangeEvent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DataChangeEvent](
	[DataChangeEventId] [uniqueidentifier] NOT NULL,
	[PersonUuid] [uniqueidentifier] NOT NULL,
	[PersonRegistrationId] [uniqueidentifier] NOT NULL,
	[ReceivedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_DataChangeEvent] PRIMARY KEY CLUSTERED 
(
	[DataChangeEventId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Country]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Country]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Country](
	[Alpha2Code] [varchar](2) NOT NULL,
	[Alpha3Code] [varchar](3) NOT NULL,
	[NumericCode] [int] NOT NULL,
	[CountryName] [nvarchar](60) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[DanishCountryName] [nvarchar](60) NOT NULL,
	[DanishCountryName2] [nvarchar](50) NULL,
	[KmdCode] [int] NULL,
	[KmdCode2] [int] NULL,
	[KmdCode3] [int] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Alpha2Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'Notes' , N'SCHEMA',N'dbo', N'TABLE',N'Country', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'Notes', @value=N'This is a list of iso3166 Standard Country Codes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Country'
GO
/****** Object:  Table [dbo].[Authority]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Authority]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Authority](
	[AuthorityCode] [varchar](4) NOT NULL,
	[AuthorityType] [varchar](2) NOT NULL,
	[AuthorityGroup] [char](10) NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[AuthorityPhone] [varchar](8) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[AuthorityName] [nvarchar](20) NULL,
	[Address] [nvarchar](34) NULL,
	[AddressLine1] [nvarchar](34) NULL,
	[AddressLine2] [nvarchar](34) NULL,
	[AddressLine3] [nvarchar](34) NULL,
	[AddressLine4] [nvarchar](34) NULL,
	[Telefax] [varchar](8) NULL,
	[FullName] [nvarchar](60) NULL,
	[Email] [nvarchar](100) NULL,
	[Alpha2CountryCode] [char](2) NOT NULL,
	[Alpha3CountryCode] [char](3) NOT NULL,
	[NumericCountryCode] [char](3) NOT NULL,
 CONSTRAINT [PK_Authority] PRIMARY KEY CLUSTERED 
(
	[AuthorityCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Application]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Application]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Application](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Token] [varchar](50) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[ApprovedDate] [datetime] NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ActorRef]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ActorRef]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ActorRef](
	[ActorRefId] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[Value] [varchar](50) NULL,
 CONSTRAINT [PK_ActorRef] PRIMARY KEY CLUSTERED 
(
	[ActorRefId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LifecycleStatus]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LifecycleStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LifecycleStatus](
	[LifecycleStatusId] [int] NOT NULL,
	[LifecycleStatusName] [varchar](50) NULL,
 CONSTRAINT [PK_LifecycleStatus] PRIMARY KEY CLUSTERED 
(
	[LifecycleStatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PersonMapping]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PersonMapping]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PersonMapping](
	[UUID] [uniqueidentifier] NOT NULL,
	[CprNumber] [varchar](10) NOT NULL,
 CONSTRAINT [PK_PersonMapping] PRIMARY KEY CLUSTERED 
(
	[UUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_PersonMapping] UNIQUE NONCLUSTERED 
(
	[CprNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Person]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Person]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Person](
	[UUID] [uniqueidentifier] NOT NULL,
	[UserInterfaceKeyText] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Object] PRIMARY KEY CLUSTERED 
(
	[UUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LogType]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LogType](
	[LogTypeId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LogType] PRIMARY KEY CLUSTERED 
(
	[LogTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PersonRegistration]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PersonRegistration]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PersonRegistration](
	[PersonRegistrationId] [uniqueidentifier] NOT NULL,
	[UUID] [uniqueidentifier] NOT NULL,
	[ActorRefId] [uniqueidentifier] NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[BrokerUpdateDate] [datetime] NOT NULL,
	[CommentText] [varchar](50) NULL,
	[LifecycleStatusId] [int] NOT NULL,
	[Contents] [xml] NULL,
	[SourceObjects] [xml] NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY NONCLUSTERED 
(
	[PersonRegistrationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PersonRegistration]') AND name = N'IX_PersonRegistration_UUID')
CREATE CLUSTERED INDEX [IX_PersonRegistration_UUID] ON [dbo].[PersonRegistration] 
(
	[UUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogEntry]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogEntry]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LogEntry](
	[LogEntryId] [uniqueidentifier] NOT NULL,
	[LogTypeId] [int] NOT NULL,
	[ApplicationId] [uniqueidentifier] NULL,
	[UserToken] [varchar](250) NULL,
	[UserId] [varchar](250) NULL,
	[MethodName] [varchar](250) NULL,
	[Text] [nvarchar](max) NULL,
	[DataObjectType] [varchar](250) NULL,
	[DataObjectXml] [ntext] NULL,
	[LogDate] [datetime] NOT NULL,
	[ActivityId] [uniqueidentifier] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LogEntry]') AND name = N'IX_LogEntry_LogDate')
CREATE CLUSTERED INDEX [IX_LogEntry_LogDate] ON [dbo].[LogEntry] 
(
	[LogDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[LogEntry]') AND name = N'PK_LogEntry')
CREATE UNIQUE NONCLUSTERED INDEX [PK_LogEntry] ON [dbo].[LogEntry] 
(
	[LogEntryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtractPersonStaging]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExtractPersonStaging]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExtractPersonStaging](
	[ExtractPersonStagingId] [uniqueidentifier] NOT NULL,
	[ExtractId] [uniqueidentifier] NOT NULL,
	[PNR] [varchar](10) NOT NULL,
 CONSTRAINT [PK_ExtractPersonStaging] PRIMARY KEY CLUSTERED 
(
	[ExtractPersonStagingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ExtractPersonStaging]') AND name = N'IX_ExtractPersonStaging_ExtractId')
CREATE NONCLUSTERED INDEX [IX_ExtractPersonStaging_ExtractId] ON [dbo].[ExtractPersonStaging] 
(
	[ExtractId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtractItem]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExtractItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExtractItem](
	[ExtractItemId] [uniqueidentifier] NOT NULL,
	[ExtractId] [uniqueidentifier] NOT NULL,
	[PNR] [varchar](10) NOT NULL,
	[RelationPNR] [varchar](10) NULL,
	[RelationPNR2] [varchar](10) NULL,
	[DataTypeCode] [varchar](10) NOT NULL,
	[Contents] [nvarchar](max) NOT NULL,
 CONSTRAINT [UK_ExtractItem_ExtractItemId] UNIQUE NONCLUSTERED 
(
	[ExtractItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ExtractItem]') AND name = N'IX_ExtractItem_PNR_ExtractId')
CREATE CLUSTERED INDEX [IX_ExtractItem_PNR_ExtractId] ON [dbo].[ExtractItem] 
(
	[PNR] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ExtractItem]') AND name = N'IX_ExtractItem_ExtractId')
CREATE NONCLUSTERED INDEX [IX_ExtractItem_ExtractId] ON [dbo].[ExtractItem] 
(
	[ExtractId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ExtractItem]') AND name = N'IX_ExtractItem_RelationPNR')
CREATE NONCLUSTERED INDEX [IX_ExtractItem_RelationPNR] ON [dbo].[ExtractItem] 
(
	[RelationPNR] ASC
)
INCLUDE ( [DataTypeCode]) 
WHERE ([PNR] IS NOT NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtractError]    Script Date: 11/21/2013 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExtractError]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExtractError](
	[ExtractErrorId] [uniqueidentifier] NOT NULL,
	[ExtractId] [uniqueidentifier] NOT NULL,
	[Contents] [nvarchar](157) NOT NULL,
 CONSTRAINT [PK_ExtractError] PRIMARY KEY CLUSTERED 
(
	[ExtractErrorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Default [DF_Application_ApplicationId]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Application_ApplicationId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Application]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Application_ApplicationId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_ApplicationId]  DEFAULT (newid()) FOR [ApplicationId]
END


End
GO
/****** Object:  Default [DF_Application_IsApproved]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Application_IsApproved]') AND parent_object_id = OBJECT_ID(N'[dbo].[Application]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Application_IsApproved]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_IsApproved]  DEFAULT ((0)) FOR [IsApproved]
END


End
GO
/****** Object:  Default [DF_ActorRef_ActorRefId]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ActorRef_ActorRefId]') AND parent_object_id = OBJECT_ID(N'[dbo].[ActorRef]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ActorRef_ActorRefId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ActorRef] ADD  CONSTRAINT [DF_ActorRef_ActorRefId]  DEFAULT (newid()) FOR [ActorRefId]
END


End
GO
/****** Object:  Default [DF_Person_UUID]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Person_UUID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Person]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Person_UUID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_UUID]  DEFAULT (newid()) FOR [UUID]
END


End
GO
/****** Object:  Default [DF_PersonRegistration_PersonRegistrationId]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_PersonRegistration_PersonRegistrationId]') AND parent_object_id = OBJECT_ID(N'[dbo].[PersonRegistration]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PersonRegistration_PersonRegistrationId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PersonRegistration] ADD  CONSTRAINT [DF_PersonRegistration_PersonRegistrationId]  DEFAULT (newid()) FOR [PersonRegistrationId]
END


End
GO
/****** Object:  Default [DF_ExtractPersonStaging_ExtractPersonStagingId]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ExtractPersonStaging_ExtractPersonStagingId]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractPersonStaging]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ExtractPersonStaging_ExtractPersonStagingId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExtractPersonStaging] ADD  CONSTRAINT [DF_ExtractPersonStaging_ExtractPersonStagingId]  DEFAULT (newid()) FOR [ExtractPersonStagingId]
END


End
GO
/****** Object:  Default [DF_ExtractItem_ExtractItemId]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ExtractItem_ExtractItemId]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractItem]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ExtractItem_ExtractItemId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExtractItem] ADD  CONSTRAINT [DF_ExtractItem_ExtractItemId]  DEFAULT (newid()) FOR [ExtractItemId]
END


End
GO
/****** Object:  Default [DF__ExtractEr__Extra__75586032]    Script Date: 11/21/2013 10:16:51 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__ExtractEr__Extra__75586032]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractError]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ExtractEr__Extra__75586032]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExtractError] ADD  DEFAULT (newid()) FOR [ExtractErrorId]
END


End
GO
/****** Object:  ForeignKey [FK_PersonRegistration_ActorRef]    Script Date: 11/21/2013 10:16:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PersonRegistration_ActorRef]') AND parent_object_id = OBJECT_ID(N'[dbo].[PersonRegistration]'))
ALTER TABLE [dbo].[PersonRegistration]  WITH CHECK ADD  CONSTRAINT [FK_PersonRegistration_ActorRef] FOREIGN KEY([ActorRefId])
REFERENCES [dbo].[ActorRef] ([ActorRefId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PersonRegistration_ActorRef]') AND parent_object_id = OBJECT_ID(N'[dbo].[PersonRegistration]'))
ALTER TABLE [dbo].[PersonRegistration] CHECK CONSTRAINT [FK_PersonRegistration_ActorRef]
GO
/****** Object:  ForeignKey [FK_PersonRegistration_LifecycleStatus]    Script Date: 11/21/2013 10:16:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PersonRegistration_LifecycleStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[PersonRegistration]'))
ALTER TABLE [dbo].[PersonRegistration]  WITH CHECK ADD  CONSTRAINT [FK_PersonRegistration_LifecycleStatus] FOREIGN KEY([LifecycleStatusId])
REFERENCES [dbo].[LifecycleStatus] ([LifecycleStatusId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PersonRegistration_LifecycleStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[PersonRegistration]'))
ALTER TABLE [dbo].[PersonRegistration] CHECK CONSTRAINT [FK_PersonRegistration_LifecycleStatus]
GO
/****** Object:  ForeignKey [FK_PersonRegistration_Person]    Script Date: 11/21/2013 10:16:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PersonRegistration_Person]') AND parent_object_id = OBJECT_ID(N'[dbo].[PersonRegistration]'))
ALTER TABLE [dbo].[PersonRegistration]  WITH CHECK ADD  CONSTRAINT [FK_PersonRegistration_Person] FOREIGN KEY([UUID])
REFERENCES [dbo].[Person] ([UUID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PersonRegistration_Person]') AND parent_object_id = OBJECT_ID(N'[dbo].[PersonRegistration]'))
ALTER TABLE [dbo].[PersonRegistration] CHECK CONSTRAINT [FK_PersonRegistration_Person]
GO
/****** Object:  ForeignKey [FK_LogEntry_Application]    Script Date: 11/21/2013 10:16:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LogEntry_Application]') AND parent_object_id = OBJECT_ID(N'[dbo].[LogEntry]'))
ALTER TABLE [dbo].[LogEntry]  WITH NOCHECK ADD  CONSTRAINT [FK_LogEntry_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Application] ([ApplicationId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LogEntry_Application]') AND parent_object_id = OBJECT_ID(N'[dbo].[LogEntry]'))
ALTER TABLE [dbo].[LogEntry] NOCHECK CONSTRAINT [FK_LogEntry_Application]
GO
/****** Object:  ForeignKey [FK_LogEntry_LogType]    Script Date: 11/21/2013 10:16:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LogEntry_LogType]') AND parent_object_id = OBJECT_ID(N'[dbo].[LogEntry]'))
ALTER TABLE [dbo].[LogEntry]  WITH CHECK ADD  CONSTRAINT [FK_LogEntry_LogType] FOREIGN KEY([LogTypeId])
REFERENCES [dbo].[LogType] ([LogTypeId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LogEntry_LogType]') AND parent_object_id = OBJECT_ID(N'[dbo].[LogEntry]'))
ALTER TABLE [dbo].[LogEntry] CHECK CONSTRAINT [FK_LogEntry_LogType]
GO
/****** Object:  ForeignKey [FK_ExtractPersonStaging_Extract]    Script Date: 11/21/2013 10:16:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExtractPersonStaging_Extract]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractPersonStaging]'))
ALTER TABLE [dbo].[ExtractPersonStaging]  WITH CHECK ADD  CONSTRAINT [FK_ExtractPersonStaging_Extract] FOREIGN KEY([ExtractId])
REFERENCES [dbo].[Extract] ([ExtractId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExtractPersonStaging_Extract]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractPersonStaging]'))
ALTER TABLE [dbo].[ExtractPersonStaging] CHECK CONSTRAINT [FK_ExtractPersonStaging_Extract]
GO
/****** Object:  ForeignKey [FK_ExtractItem_Extract]    Script Date: 11/21/2013 10:16:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExtractItem_Extract]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractItem]'))
ALTER TABLE [dbo].[ExtractItem]  WITH NOCHECK ADD  CONSTRAINT [FK_ExtractItem_Extract] FOREIGN KEY([ExtractId])
REFERENCES [dbo].[Extract] ([ExtractId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExtractItem_Extract]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractItem]'))
ALTER TABLE [dbo].[ExtractItem] CHECK CONSTRAINT [FK_ExtractItem_Extract]
GO
/****** Object:  ForeignKey [FK_ExtractError_Extract]    Script Date: 11/21/2013 10:16:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExtractError_Extract]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractError]'))
ALTER TABLE [dbo].[ExtractError]  WITH CHECK ADD  CONSTRAINT [FK_ExtractError_Extract] FOREIGN KEY([ExtractId])
REFERENCES [dbo].[Extract] ([ExtractId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExtractError_Extract]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtractError]'))
ALTER TABLE [dbo].[ExtractError] CHECK CONSTRAINT [FK_ExtractError_Extract]
GO


-- ========================================================
-- Table  : PersonSearchCache
-- ========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE Name = 'PersonSearchCache')
BEGIN
	CREATE TABLE [dbo].[PersonSearchCache](
		[PersonRegistrationId] [uniqueidentifier] NULL,
		[UUID] [uniqueidentifier] NOT NULL,
		[UserInterfaceKeyText] [varchar](max) NULL,
		[Birthdate] [varchar](max) NULL,
		[NickName] [varchar](max) NULL,
		[Note] [varchar](max) NULL,
		[AddressingName] [varchar](max) NULL,
		[PersonGivenName] [varchar](max) NULL,
		[PersonMiddleName] [varchar](max) NULL,
		[PersonSurnameName] [varchar](max) NULL,
		[PersonGenderCode] [varchar](max) NULL,
		[LivscyklusKode] [varchar](max) NULL,
	 CONSTRAINT [PK_PersonSearchCache] PRIMARY KEY CLUSTERED 
	(
		[UUID] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

GO


-- =============================================
-- Procedure:   InitializePersonSearchCache
-- Author:		Beemen Beshara
-- Create date: 24-Jan-2014
-- Description:	Initializes the cashed version of persons' searchable fields
-- =============================================
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'InitializePersonSearchCache')
	DROP PROCEDURE dbo.InitializePersonSearchCache
GO

CREATE PROCEDURE [dbo].[InitializePersonSearchCache]
	@UUID UNIQUEIDENTIFIER, 
	@PersonRegistrationId UNIQUEIDENTIFIER, 
	@RegistrationDate DATETIME, 
	@Contents XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
	SET NOCOUNT ON;
    
    -- Determine if this is the latest registration
	IF NOT EXISTS (
		SELECT PersonRegistrationId 
		FROM PersonRegistration 
		WHERE 
			UUID = @UUID 
			AND RegistrationDate > @RegistrationDate
		)
	BEGIN
		-- Ensure record exists
		IF NOT EXISTS (SELECT UUID FROM PersonSearchCache WHERE UUID = @UUID)
		BEGIN
			DECLARE @C INT		
			INSERT INTO PersonSearchCache(UUID) VALUES (@UUID)
		END
		
		-- Fill the data
		UPDATE  PersonSearchCache
		SET 
			PersonRegistrationId = @PersonRegistrationId,
			UserInterfaceKeyText = Convert(VARCHAR(MAX), tmp_UserInterfaceKeyText.Value.query('text()')),
			BirthDate = Convert(VARCHAR(MAX), tmp_BirthDate.Value.query('text()')),
			NickName = Convert(VARCHAR(MAX), tmp_NickName.Value.query('text()')),
			Note = Convert(VARCHAR(MAX), tmp_Note.Value.query('text()')),
			AddressingName = Convert(VARCHAR(MAX), tmp_AddressingName.Value.query('text()')),
			PersonGivenName = CONVERT(VARCHAR(MAX), tmp_PersonGivenName.Value.query('text()')), 
			PersonMiddleName = CONVERT(VARCHAR(MAX), tmp_PersonMiddleName.Value.query('text()')), 
			PersonSurnameName = CONVERT(VARCHAR(MAX), tmp_PersonSurnameName.Value.query('text()')), 
			PersonGenderCode = CONVERT(VARCHAR(MAX), tmp_PersonGenderCode.Value.query('text()')), 
			LivscyklusKode = CONVERT(VARCHAR(MAX), tmp_LivscyklusKode.Value.query('text()'))

		FROM 
			PersonSearchCache
			
			OUTER APPLY @Contents.nodes ('declare namespace ns0="urn:oio:sagdok:person:1.0.0";
			declare namespace ns1="http://rep.oio.dk/cpr.dk/xml/schemas/core/2005/03/18/";
			(/ns0:Registrering/ns0:AttributListe/ns0:RegisterOplysning/ns0:CprBorger/ns1:PersonCivilRegistrationIdentifier)[last()]'
			) AS tmp_UserInterfaceKeyText (Value)
			
			OUTER APPLY @Contents.nodes ('declare namespace ns0="urn:oio:sagdok:person:1.0.0";
			declare namespace ns1="http://rep.oio.dk/ebxml/xml/schemas/dkcc/2005/03/15/";
			(/ns0:Registrering/ns0:AttributListe/ns0:Egenskab/ns1:BirthDate)[last()]'
			) AS tmp_BirthDate (Value)
			
			OUTER APPLY @Contents.nodes ('declare namespace ns0="urn:oio:sagdok:person:1.0.0";
			declare namespace ns1="urn:oio:sagdok:2.0.0";
			(/ns0:Registrering/ns0:AttributListe/ns0:Egenskab/ns0:NavnStruktur/ns1:KaldenavnTekst)[last()]'
			) AS tmp_NickName (Value)
			
			OUTER APPLY @Contents.nodes ('declare namespace ns0="urn:oio:sagdok:person:1.0.0";
			declare namespace ns1="urn:oio:sagdok:2.0.0";
			(/ns0:Registrering/ns0:AttributListe/ns0:Egenskab/ns0:NavnStruktur/ns1:NoteTekst)[last()]'
			) AS tmp_Note (Value)
			
			OUTER APPLY @Contents.nodes ('declare namespace ns0="urn:oio:sagdok:person:1.0.0";
			declare namespace ns1="http://rep.oio.dk/itst.dk/xml/schemas/2005/02/22/";
			(/ns0:Registrering/ns0:AttributListe/ns0:Egenskab/ns0:NavnStruktur/ns1:PersonNameForAddressingName)[last()]'
			) AS tmp_AddressingName (Value)
			
			OUTER APPLY @Contents.nodes ('declare namespace ns0="urn:oio:sagdok:person:1.0.0";
			declare namespace ns1="http://rep.oio.dk/itst.dk/xml/schemas/2006/01/17/";
			declare namespace ns2="http://rep.oio.dk/ebxml/xml/schemas/dkcc/2003/02/13/";
			(/ns0:Registrering/ns0:AttributListe/ns0:Egenskab/ns0:NavnStruktur/ns1:PersonNameStructure/ns2:PersonGivenName)[last()]'
			) AS tmp_PersonGivenName (Value)

			OUTER APPLY @Contents.nodes ('declare namespace ns0="urn:oio:sagdok:person:1.0.0";
			declare namespace ns1="http://rep.oio.dk/itst.dk/xml/schemas/2006/01/17/";
			declare namespace ns2="http://rep.oio.dk/ebxml/xml/schemas/dkcc/2003/02/13/";
			(/ns0:Registrering/ns0:AttributListe/ns0:Egenskab/ns0:NavnStruktur/ns1:PersonNameStructure/ns2:PersonMiddleName)[last()]'
			) AS tmp_PersonMiddleName (Value)

			OUTER APPLY @Contents.nodes ('declare namespace ns0="urn:oio:sagdok:person:1.0.0";
			declare namespace ns1="http://rep.oio.dk/itst.dk/xml/schemas/2006/01/17/";
			declare namespace ns2="http://rep.oio.dk/ebxml/xml/schemas/dkcc/2003/02/13/";
			(/ns0:Registrering/ns0:AttributListe/ns0:Egenskab/ns0:NavnStruktur/ns1:PersonNameStructure/ns2:PersonSurnameName)[last()]'
			) AS tmp_PersonSurnameName (Value)

			OUTER APPLY @Contents.nodes ('declare namespace ns0="urn:oio:sagdok:person:1.0.0";
			declare namespace ns1="http://rep.oio.dk/ebxml/xml/schemas/dkcc/2006/01/23/";
			(/ns0:Registrering/ns0:AttributListe/ns0:Egenskab/ns1:PersonGenderCode)[last()]'
			) AS tmp_PersonGenderCode (Value)

			OUTER APPLY @Contents.nodes ('declare namespace ns0="urn:oio:sagdok:person:1.0.0";
			declare namespace ns1="urn:oio:sagdok:2.0.0";
			(/ns0:Registrering/ns1:LivscyklusKode)[last()]'
			) AS tmp_LivscyklusKode (Value)

			

		WHERE
			UUID = @UUID
	END
		
END
GO

-- =============================================
-- Author:		Beemen Beshara
-- Description:	Trigger for changes in PersonRegistration, 
--  refreshes the cached serach table by calling InitializePersonSearchCache for 
--  each record being inserted or updated
-- =============================================

IF EXISTS (SELECT * FROM sys.triggers where name='PersonRegistration_PopulateSearchCache')
BEGIN
	DROP TRIGGER dbo.PersonRegistration_PopulateSearchCache
END
GO

CREATE TRIGGER dbo.PersonRegistration_PopulateSearchCache
   ON  dbo.PersonRegistration
   AFTER INSERT,UPDATE
AS 
BEGIN
	--SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @UUID UNIQUEIDENTIFIER, @PersonRegistrationId UNIQUEIDENTIFIER, @RegistrationDate DATETIME, @Contents XML
	
	DECLARE CUR Cursor FOR
	SELECT UUID, PersonRegistrationId, RegistrationDate , Contents
	FROM    INSERTED
	
	OPEN CUR
	FETCH NEXT FROM CUR INTO @UUID, @PersonRegistrationId, @RegistrationDate, @Contents
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		EXEC dbo.InitializePersonSearchCache @UUID, @PersonRegistrationId, @RegistrationDate, @Contents
		FETCH NEXT FROM CUR INTO @UUID, @PersonRegistrationId, @RegistrationDate, @Contents
	END
	
	CLOSE CUR
	DEALLOCATE CUR

END
GO



