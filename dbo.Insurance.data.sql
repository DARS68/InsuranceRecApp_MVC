SET IDENTITY_INSERT [dbo].[Insurance] ON
INSERT INTO [dbo].[Insurance] ([InsuranceID], [InsuranceName], [InsuranceDescription], [InsuranceAmount], [SubjectOfInsurance], [ValidFrom], [ValidTo], [InsuredPersonId]) VALUES (2, N'Pojištění osob', N'pojištění nemovitosti', 0, N'Škoda Fabia', N'2022-01-01 00:00:00', N'2022-01-01 00:00:00', 1)
SET IDENTITY_INSERT [dbo].[Insurance] OFF
