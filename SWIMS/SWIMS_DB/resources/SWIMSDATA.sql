USE [SWIMS_CUSTOMER]
GO
/****** Object:  Table [dbo].[contract]    Script Date: 07/08/2020 14:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contract](
	[contract_id] [int] NOT NULL,
	[contract_code] [nvarchar](50) NOT NULL,
	[contract_desc] [nvarchar](50) NULL,
	[contract_canimport] [nvarchar](50) NULL,
	[contract_inactive] [bigint] NOT NULL,
	[contract_taskvaluation] [smallint] NULL,
	[contract_nillrevenue] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[district]    Script Date: 07/08/2020 14:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[district](
	[district_id] [int] NOT NULL,
	[contract_id] [int] NOT NULL,
	[district_code] [nvarchar](50) NOT NULL,
	[district_desc] [nvarchar](50) NULL,
	[district_address] [nvarchar](255) NULL,
	[district_postcode] [nvarchar](12) NULL,
	[district_primary] [int] NULL,
 CONSTRAINT [PK_district] PRIMARY KEY CLUSTERED 
(
	[district_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[job]    Script Date: 07/08/2020 14:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[job](
	[job_id] [int] NOT NULL,
	[application_id] [nvarchar](50) NULL,
	[contract_id] [int] NOT NULL,
	[district_id] [int] NOT NULL,
	[masterjob_id] [int] NULL,
	[job_address] [nvarchar](255) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[contract] ([contract_id], [contract_code], [contract_desc], [contract_canimport], [contract_inactive], [contract_taskvaluation], [contract_nillrevenue]) VALUES (1, N'CONT1', N'Road Project', N'1', 0, 0, 0)
INSERT [dbo].[contract] ([contract_id], [contract_code], [contract_desc], [contract_canimport], [contract_inactive], [contract_taskvaluation], [contract_nillrevenue]) VALUES (2, N'CONT2', N'New Bridge', N'0', 0, 0, 0)
INSERT [dbo].[contract] ([contract_id], [contract_code], [contract_desc], [contract_canimport], [contract_inactive], [contract_taskvaluation], [contract_nillrevenue]) VALUES (3, N'CONT3', N'New motorwa extension', N'0', 0, 0, 0)
INSERT [dbo].[district] ([district_id], [contract_id], [district_code], [district_desc], [district_address], [district_postcode], [district_primary]) VALUES (1, 1, N'RED', N'The Red District', N'The Avenue', N'DY88UU', 1)
INSERT [dbo].[district] ([district_id], [contract_id], [district_code], [district_desc], [district_address], [district_postcode], [district_primary]) VALUES (2, 2, N'BLUE', N'Avenue District', N'Beer Road', N'WV09LK', 1)
INSERT [dbo].[district] ([district_id], [contract_id], [district_code], [district_desc], [district_address], [district_postcode], [district_primary]) VALUES (3, 3, N'YELLOW', N'Yellow District', N'New Avenue', N'BN98UU', 0)
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (1, NULL, 1, 1, 100, NULL)
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (2, NULL, 1, 1, 100, NULL)
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (3, NULL, 2, 2, 300, NULL)
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (4, NULL, 3, 3, 308, NULL)
/****** Object:  Index [PK_contract]    Script Date: 07/08/2020 14:44:55 ******/
ALTER TABLE [dbo].[contract] ADD  CONSTRAINT [PK_contract] PRIMARY KEY NONCLUSTERED 
(
	[contract_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_job]    Script Date: 07/08/2020 14:44:55 ******/
ALTER TABLE [dbo].[job] ADD  CONSTRAINT [PK_job] PRIMARY KEY NONCLUSTERED 
(
	[job_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[contract] ADD  CONSTRAINT [InactiveYesOrNo]  DEFAULT ((0)) FOR [contract_inactive]
GO
ALTER TABLE [dbo].[contract] ADD  CONSTRAINT [Value1to10]  DEFAULT ((0)) FOR [contract_taskvaluation]
GO
ALTER TABLE [dbo].[contract] ADD  CONSTRAINT [value-1000to1000]  DEFAULT ((0)) FOR [contract_nillrevenue]
GO
ALTER TABLE [dbo].[district] ADD  CONSTRAINT [IsPrimaryYesOrNo]  DEFAULT ((0)) FOR [district_primary]
GO
ALTER TABLE [dbo].[district]  WITH CHECK ADD  CONSTRAINT [FK_district_To_Contract] FOREIGN KEY([contract_id])
REFERENCES [dbo].[contract] ([contract_id])
GO
ALTER TABLE [dbo].[district] CHECK CONSTRAINT [FK_district_To_Contract]
GO
ALTER TABLE [dbo].[job]  WITH CHECK ADD  CONSTRAINT [FK_job_To_Contract] FOREIGN KEY([contract_id])
REFERENCES [dbo].[contract] ([contract_id])
GO
ALTER TABLE [dbo].[job] CHECK CONSTRAINT [FK_job_To_Contract]
GO
ALTER TABLE [dbo].[job]  WITH CHECK ADD  CONSTRAINT [FK_job_To_District] FOREIGN KEY([district_id])
REFERENCES [dbo].[district] ([district_id])
GO
ALTER TABLE [dbo].[job] CHECK CONSTRAINT [FK_job_To_District]
GO
