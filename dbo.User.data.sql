SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([Id], [Email], [Password], [PhoneNumber], [RoleId], [Cast]) VALUES (1, N'admin@mail.ru', N'123456', NULL, 1, NULL)
INSERT INTO [dbo].[User] ([Id], [Email], [Password], [PhoneNumber], [RoleId], [Cast]) VALUES (2, N'1', N'1', N'1', 2, N'{"Pizza":[],"Drink":[],"Sushi":[]}')
INSERT INTO [dbo].[User] ([Id], [Email], [Password], [PhoneNumber], [RoleId], [Cast]) VALUES (3, N'colyachepil@gmai.com', N'134', N'123', 2, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
