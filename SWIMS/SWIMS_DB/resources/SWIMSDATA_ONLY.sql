USE [SWIMS_CUSTOMER]


DELETE FROM [SWIMS_CUSTOMER].[dbo].district
DELETE FROM [SWIMS_CUSTOMER].[dbo].contract
DELETE FROM [SWIMS_CUSTOMER].[dbo].job

GO
INSERT [dbo].[contract] ([contract_id], [contract_code], [contract_desc], [contract_canimport], [contract_inactive], [contract_taskvaluation], [contract_nillrevenue]) VALUES (1, N'CONT1', N'Road Project', N'1', 0, 0, 0)
INSERT [dbo].[contract] ([contract_id], [contract_code], [contract_desc], [contract_canimport], [contract_inactive], [contract_taskvaluation], [contract_nillrevenue]) VALUES (2, N'CONT2', N'New Bridge', N'0', 0, 0, 0)
INSERT [dbo].[contract] ([contract_id], [contract_code], [contract_desc], [contract_canimport], [contract_inactive], [contract_taskvaluation], [contract_nillrevenue]) VALUES (3, N'CONT3', N'New motorwa extension', N'0', 0, 0, 0)
INSERT [dbo].[district] ([district_id], [contract_id], [district_code], [district_desc], [district_address], [district_postcode], [district_primary]) VALUES (1, 1, N'RED', N'The Red District', N'The Avenue', N'DY88UU', 1)
INSERT [dbo].[district] ([district_id], [contract_id], [district_code], [district_desc], [district_address], [district_postcode], [district_primary]) VALUES (2, 2, N'BLUE', N'Avenue District', N'Beer Road', N'WV09LK', 1)
INSERT [dbo].[district] ([district_id], [contract_id], [district_code], [district_desc], [district_address], [district_postcode], [district_primary]) VALUES (3, 3, N'YELLOW', N'Yellow District', N'New Avenue', N'BN98UU', 0)
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (NEWID(), NULL, 1, 1, 100, 'Job Address One')
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (NEWID(), NULL, 1, 1, 100, 'Job Address TWO')
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (NEWID(), NULL, 2, 2, 300, 'Job Address Red')
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (NEWID(), NULL, 3, 3, 308, 'Job Address Blue')

USE [SWIMS_CUSTOMER]
INSERT [dbo].[contract] ([contract_id], [contract_code], [contract_desc], [contract_canimport], [contract_inactive], [contract_taskvaluation], [contract_nillrevenue]) VALUES (4, N'CONT4', N'Road Project 2', N'1', 0, 0, 0)
INSERT [dbo].[contract] ([contract_id], [contract_code], [contract_desc], [contract_canimport], [contract_inactive], [contract_taskvaluation], [contract_nillrevenue]) VALUES (5, N'CONT5', N'New Bridge 2', N'0', 0, 0, 0)
INSERT [dbo].[contract] ([contract_id], [contract_code], [contract_desc], [contract_canimport], [contract_inactive], [contract_taskvaluation], [contract_nillrevenue]) VALUES (6, N'CONT6', N'New motorwa extension 2', N'1', 0, 0, 0)
INSERT [dbo].[district] ([district_id], [contract_id], [district_code], [district_desc], [district_address], [district_postcode], [district_primary]) VALUES (4, 4, N'RED', N'The Red District', N'The Avenue', N'DY88UU', 1)
INSERT [dbo].[district] ([district_id], [contract_id], [district_code], [district_desc], [district_address], [district_postcode], [district_primary]) VALUES (5, 5, N'BLUE', N'Avenue District', N'Beer Road', N'WV09LK', 1)
INSERT [dbo].[district] ([district_id], [contract_id], [district_code], [district_desc], [district_address], [district_postcode], [district_primary]) VALUES (6, 6, N'YELLOW', N'Yellow District', N'New Avenue', N'BN98UU', 0)
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (NEWID(), NULL, 4, 4, 400, 'Job Address Four')
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (NEWID(), NULL, 4, 4, 400, 'Job Address Five')
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (NEWID(), NULL, 5, 5, 500, 'Job Address Six')
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (NEWID(), NULL, 6, 6, 600, 'Job Address Six A')

USE [SWIMS_CUSTOMER]
INSERT [dbo].[contract] ([contract_id], [contract_code], [contract_desc], [contract_canimport], [contract_inactive], [contract_taskvaluation], [contract_nillrevenue]) VALUES (7, N'CONT4', N'Road Project 2', N'1', 0, 0, 0)
INSERT [dbo].[contract] ([contract_id], [contract_code], [contract_desc], [contract_canimport], [contract_inactive], [contract_taskvaluation], [contract_nillrevenue]) VALUES (8, N'CONT5', N'New Bridge 2', N'0', 0, 0, 0)
INSERT [dbo].[contract] ([contract_id], [contract_code], [contract_desc], [contract_canimport], [contract_inactive], [contract_taskvaluation], [contract_nillrevenue]) VALUES (9, N'CONT6', N'New motorwa extension 2', N'1', 0, 0, 0)
INSERT [dbo].[district] ([district_id], [contract_id], [district_code], [district_desc], [district_address], [district_postcode], [district_primary]) VALUES (7, 7, N'Yellow', N'The Red District', N'The Avenue', N'DY88UU', 1)
INSERT [dbo].[district] ([district_id], [contract_id], [district_code], [district_desc], [district_address], [district_postcode], [district_primary]) VALUES (8, 8, N'Cyan', N'Avenue District', N'Beer Road', N'WV09LK', 1)
INSERT [dbo].[district] ([district_id], [contract_id], [district_code], [district_desc], [district_address], [district_postcode], [district_primary]) VALUES (9, 9, N'Magenta', N'Yellow District', N'New Avenue', N'BN98UU', 0)
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (NEWID(), NULL, 7, 7, 700, 'Job Address Four')
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (NEWID(), NULL, 8, 8, 800, 'Job Address Five')
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (NEWID(), NULL, 9, 9, 900, 'Job Address Six')
INSERT [dbo].[job] ([job_id], [application_id], [contract_id], [district_id], [masterjob_id], [job_address]) VALUES (NEWID(), NULL, 9, 9, 900, 'Job Address Six A')


