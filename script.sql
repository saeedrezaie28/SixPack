USE [SixPacDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2023/03/04 4:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categries]    Script Date: 2023/03/04 4:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 2023/03/04 4:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CommentText] [nvarchar](max) NOT NULL,
	[UserID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProdcutImages]    Script Date: 2023/03/04 4:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProdcutImages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DownloadPath] [nvarchar](max) NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_ProdcutImages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2023/03/04 4:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Color] [nvarchar](max) NOT NULL,
	[Price] [int] NOT NULL,
	[Desc] [nvarchar](max) NOT NULL,
	[Slag] [nvarchar](max) NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2023/03/04 4:48:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Mobile] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230304112428_init', N'7.0.3')
GO
SET IDENTITY_INSERT [dbo].[Categries] ON 

INSERT [dbo].[Categries] ([ID], [Title], [Description]) VALUES (1, N'دیجیتال', N'دیجیتال خوب')
INSERT [dbo].[Categries] ([ID], [Title], [Description]) VALUES (2, N'برقی', N'برقی خوب')
INSERT [dbo].[Categries] ([ID], [Title], [Description]) VALUES (3, N'لوازم التحریر', N'لوازم التحریر خوب')
INSERT [dbo].[Categries] ([ID], [Title], [Description]) VALUES (4, N'پوشاک', N'پوشاک خوب')
SET IDENTITY_INSERT [dbo].[Categries] OFF
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([ID], [CommentText], [UserID], [ProductID], [CreateTime]) VALUES (1, N'همچین خوب هم که میگن نی', 2, 4, CAST(N'2023-03-04T12:30:32.8940000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ID], [Title], [Color], [Price], [Desc], [Slag], [CategoryID]) VALUES (3, N'لپتاپ', N'قرمز', 2500, N'لپتاپ خوبیه', N'لپتاپ-قرمز', 1)
INSERT [dbo].[Products] ([ID], [Title], [Color], [Price], [Desc], [Slag], [CategoryID]) VALUES (4, N'لامپ', N'سفید', 1000, N'لامپ خوبیه', N'لامپ-سفید', 2)
INSERT [dbo].[Products] ([ID], [Title], [Color], [Price], [Desc], [Slag], [CategoryID]) VALUES (5, N'خودکار', N'آبی', 100, N'خودکار خوبیه', N'خودکار-آبی', 3)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Name], [LastName], [Mobile]) VALUES (1, N'سعید', N'رضایی', N'09376721396')
INSERT [dbo].[Users] ([ID], [Name], [LastName], [Mobile]) VALUES (2, N'محسن', N'دلاوری', N'09120000000')
INSERT [dbo].[Users] ([ID], [Name], [LastName], [Mobile]) VALUES (3, N'مهدی', N'محمدی', N'09130000000')
INSERT [dbo].[Users] ([ID], [Name], [LastName], [Mobile]) VALUES (4, N'علی', N'شیرخدایی', N'09160000000')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Products_ProductID]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users_UserID]
GO
ALTER TABLE [dbo].[ProdcutImages]  WITH CHECK ADD  CONSTRAINT [FK_ProdcutImages_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProdcutImages] CHECK CONSTRAINT [FK_ProdcutImages_Products_ProductID]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categries_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categries] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categries_CategoryID]
GO
