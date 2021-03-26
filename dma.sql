USE [DMS]
GO
INSERT [dbo].[Status] ([StatusId], [StatusName], [LastModifiedTimestamp], [CreatedTimestamp]) VALUES (1, N'Active', CAST(N'2021-03-26T12:39:38.737' AS DateTime), CAST(N'2021-03-26T12:39:38.737' AS DateTime))
INSERT [dbo].[Status] ([StatusId], [StatusName], [LastModifiedTimestamp], [CreatedTimestamp]) VALUES (2, N'Inactive', CAST(N'2021-03-26T12:39:38.737' AS DateTime), CAST(N'2021-03-26T12:39:38.737' AS DateTime))
GO
INSERT [dbo].[User] ([UserId], [FirstName], [MiddleName], [LastName], [Password], [LoginName], [StatusId], [LastModifiedTimestamp], [CreatedTimestamp], [date_last_login]) VALUES (1, N'Admin', NULL, N'System', N'123456     ', N'admin', 1, CAST(N'2021-03-26T12:39:38.737' AS DateTime), CAST(N'2021-03-26T12:39:38.737' AS DateTime), CAST(N'2021-03-26T12:39:38.737' AS DateTime))
GO
