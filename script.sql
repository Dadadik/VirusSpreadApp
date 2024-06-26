SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetAllocation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NOT NULL,
	[PossibleStrategyId] [int] NOT NULL,
	[Payment] [float] NOT NULL,
	[DateTime] [date] NOT NULL,
 CONSTRAINT [PK_BudgetAllocation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 26.05.2024 17:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](50) NOT NULL,
	[Population] [int] NOT NULL,
	[PercentInfected] [int] NOT NULL,
	[PercentVaccinated] [int] NOT NULL,
	[VaccinationPrice] [float] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PossibleStrategy]    Script Date: 26.05.2024 17:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PossibleStrategy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PossibleStrategy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BudgetAllocation] ON 

INSERT [dbo].[BudgetAllocation] ([Id], [CityId], [PossibleStrategyId], [Payment], [DateTime]) VALUES (1, 1, 1, 2000000, CAST(N'2023-05-12' AS Date))
INSERT [dbo].[BudgetAllocation] ([Id], [CityId], [PossibleStrategyId], [Payment], [DateTime]) VALUES (10, 1003, 2, 100000, CAST(N'2023-09-13' AS Date))
INSERT [dbo].[BudgetAllocation] ([Id], [CityId], [PossibleStrategyId], [Payment], [DateTime]) VALUES (12, 1004, 3, 500000, CAST(N'2023-07-02' AS Date))
SET IDENTITY_INSERT [dbo].[BudgetAllocation] OFF
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [CityName], [Population], [PercentInfected], [PercentVaccinated], [VaccinationPrice]) VALUES (1, N'Москва', 1200000, 15, 5, 1000)
INSERT [dbo].[City] ([Id], [CityName], [Population], [PercentInfected], [PercentVaccinated], [VaccinationPrice]) VALUES (1003, N'Казань', 1040000, 10, 2, 500)
INSERT [dbo].[City] ([Id], [CityName], [Population], [PercentInfected], [PercentVaccinated], [VaccinationPrice]) VALUES (1004, N'Тула', 400000, 5, 1, 250)
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[PossibleStrategy] ON 

INSERT [dbo].[PossibleStrategy] ([Id], [Name], [Description]) VALUES (1, N'Маски', N'Носите маски')
INSERT [dbo].[PossibleStrategy] ([Id], [Name], [Description]) VALUES (2, N'Дистанцирование', N'Держите дистанцию с людьми')
INSERT [dbo].[PossibleStrategy] ([Id], [Name], [Description]) VALUES (3, N'Дезинфекция', N'Мойте руки с мылом')
SET IDENTITY_INSERT [dbo].[PossibleStrategy] OFF
GO
ALTER TABLE [dbo].[BudgetAllocation]  WITH CHECK ADD  CONSTRAINT [FK_BudgetAllocation_City1] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BudgetAllocation] CHECK CONSTRAINT [FK_BudgetAllocation_City1]
GO
ALTER TABLE [dbo].[BudgetAllocation]  WITH CHECK ADD  CONSTRAINT [FK_BudgetAllocation_PossibleStrategy1] FOREIGN KEY([PossibleStrategyId])
REFERENCES [dbo].[PossibleStrategy] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
