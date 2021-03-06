USE [LibraryDBK209]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/20/2021 10:50:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 5/20/2021 10:50:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [decimal](18, 0) NULL,
	[CategoryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[SelectBookCategory]    Script Date: 5/20/2021 10:50:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[SelectBookCategory] as
select bs.Name[Book Name],bs.Price,cs.Name[Category Name] from Books bs
Join Categories cs
on bs.CategoryId=cs.Id
GO
/****** Object:  Table [dbo].[Author_to_Book]    Script Date: 5/20/2021 10:50:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author_to_Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthorID] [int] NULL,
	[BookID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 5/20/2021 10:50:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/20/2021 10:50:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[BookId] [int] NULL,
	[FromDate] [date] NULL,
	[ToDate] [date] NULL,
	[Price] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 5/20/2021 10:50:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SSN] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author_to_Book] ON 

INSERT [dbo].[Author_to_Book] ([Id], [AuthorID], [BookID]) VALUES (2, 1, 7)
INSERT [dbo].[Author_to_Book] ([Id], [AuthorID], [BookID]) VALUES (5, 3, 9)
INSERT [dbo].[Author_to_Book] ([Id], [AuthorID], [BookID]) VALUES (6, 4, 7)
INSERT [dbo].[Author_to_Book] ([Id], [AuthorID], [BookID]) VALUES (7, 5, 10)
INSERT [dbo].[Author_to_Book] ([Id], [AuthorID], [BookID]) VALUES (8, 6, 11)
INSERT [dbo].[Author_to_Book] ([Id], [AuthorID], [BookID]) VALUES (9, 6, 12)
INSERT [dbo].[Author_to_Book] ([Id], [AuthorID], [BookID]) VALUES (12, 2, 15)
INSERT [dbo].[Author_to_Book] ([Id], [AuthorID], [BookID]) VALUES (13, 3, 16)
INSERT [dbo].[Author_to_Book] ([Id], [AuthorID], [BookID]) VALUES (1004, 3, 2004)
INSERT [dbo].[Author_to_Book] ([Id], [AuthorID], [BookID]) VALUES (1005, 1, 14)
INSERT [dbo].[Author_to_Book] ([Id], [AuthorID], [BookID]) VALUES (1006, 5, 13)
SET IDENTITY_INSERT [dbo].[Author_to_Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [Name]) VALUES (1, N'Nizami Gəncəvi')
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (2, N'Dostayevski')
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (3, N'Xaild Hüseyn')
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (4, N'Uydurdum')
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (5, N'Səməd Vurğun')
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (6, N'Qalib Hitler')
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Name], [Price], [CategoryId]) VALUES (7, N'GOTHIC SHORT STORIES', CAST(25 AS Decimal(18, 0)), 1)
INSERT [dbo].[Books] ([Id], [Name], [Price], [CategoryId]) VALUES (9, N'Woomen in White', CAST(7 AS Decimal(18, 0)), 3)
INSERT [dbo].[Books] ([Id], [Name], [Price], [CategoryId]) VALUES (10, N'Çərpələng uçuran', CAST(15 AS Decimal(18, 0)), 2)
INSERT [dbo].[Books] ([Id], [Name], [Price], [CategoryId]) VALUES (11, N'Xosrov və şirin', CAST(10 AS Decimal(18, 0)), 2)
INSERT [dbo].[Books] ([Id], [Name], [Price], [CategoryId]) VALUES (12, N'Cinayət və Cəza', CAST(15 AS Decimal(18, 0)), 3)
INSERT [dbo].[Books] ([Id], [Name], [Price], [CategoryId]) VALUES (13, N'Mine Campf', CAST(8 AS Decimal(18, 0)), 3)
INSERT [dbo].[Books] ([Id], [Name], [Price], [CategoryId]) VALUES (14, N'Gülən adam', CAST(8 AS Decimal(18, 0)), 3)
INSERT [dbo].[Books] ([Id], [Name], [Price], [CategoryId]) VALUES (15, N'Aşağılanmış və hakeret', CAST(20 AS Decimal(18, 0)), 3)
INSERT [dbo].[Books] ([Id], [Name], [Price], [CategoryId]) VALUES (16, N'Vətən', CAST(15 AS Decimal(18, 0)), 2)
INSERT [dbo].[Books] ([Id], [Name], [Price], [CategoryId]) VALUES (1002, N'Yeni Kitab 1', CAST(15 AS Decimal(18, 0)), 1)
INSERT [dbo].[Books] ([Id], [Name], [Price], [CategoryId]) VALUES (1004, N'Yeni Kitab 2', CAST(4 AS Decimal(18, 0)), 2)
INSERT [dbo].[Books] ([Id], [Name], [Price], [CategoryId]) VALUES (2002, N'Yeni kitab K209', CAST(5 AS Decimal(18, 0)), 2)
INSERT [dbo].[Books] ([Id], [Name], [Price], [CategoryId]) VALUES (2003, N'Y1', CAST(32 AS Decimal(18, 0)), 3)
INSERT [dbo].[Books] ([Id], [Name], [Price], [CategoryId]) VALUES (2004, N'Qalib C# ', CAST(13 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Dram')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Bədi əsər')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Klassiklər')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Şeirlər')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
ALTER TABLE [dbo].[Author_to_Book]  WITH CHECK ADD FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([Id])
GO
ALTER TABLE [dbo].[Author_to_Book]  WITH CHECK ADD FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
