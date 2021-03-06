USE [E-store]
GO
/****** Object:  Schema [COMMON]    Script Date: 6/19/2022 11:33:22 AM ******/
CREATE SCHEMA [COMMON]
GO
/****** Object:  Schema [CONTENT_MANAGEMENT]    Script Date: 6/19/2022 11:33:22 AM ******/
CREATE SCHEMA [CONTENT_MANAGEMENT]
GO
/****** Object:  Schema [LT_COMMON]    Script Date: 6/19/2022 11:33:22 AM ******/
CREATE SCHEMA [LT_COMMON]
GO
/****** Object:  Schema [LT_CONTENT_MANAGEMENT]    Script Date: 6/19/2022 11:33:22 AM ******/
CREATE SCHEMA [LT_CONTENT_MANAGEMENT]
GO
/****** Object:  Table [COMMON].[Users]    Script Date: 6/19/2022 11:33:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [COMMON].[Users](
	[UsersKey] [uniqueidentifier] NOT NULL,
	[UserType] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](20) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UsersKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [CONTENT_MANAGEMENT].[Cart]    Script Date: 6/19/2022 11:33:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CONTENT_MANAGEMENT].[Cart](
	[UserKey] [uniqueidentifier] NOT NULL,
	[ProductKey] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[UserKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [CONTENT_MANAGEMENT].[Product]    Script Date: 6/19/2022 11:33:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CONTENT_MANAGEMENT].[Product](
	[ProductKey] [uniqueidentifier] NOT NULL,
	[Title] [varchar](500) NULL,
	[Price] [int] NOT NULL,
	[Type] [varchar](50) NULL,
	[DateCreated] [date] NULL,
	[GraphicCard] [varchar](50) NULL,
	[Cpu] [varchar](50) NULL,
	[Ram] [varchar](50) NULL,
	[OtherFeatures] [varchar](5000) NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [PK_Product_1] PRIMARY KEY CLUSTERED 
(
	[ProductKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [CONTENT_MANAGEMENT].[ProductComments]    Script Date: 6/19/2022 11:33:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CONTENT_MANAGEMENT].[ProductComments](
	[ProductCommentsKey] [uniqueidentifier] NOT NULL,
	[ProductKey] [uniqueidentifier] NOT NULL,
	[UsersKey] [uniqueidentifier] NOT NULL,
	[CommentTitle] [varchar](100) NULL,
	[CommentText] [varchar](5000) NULL,
	[CommentDate] [date] NOT NULL,
 CONSTRAINT [PK_ProductComments] PRIMARY KEY CLUSTERED 
(
	[ProductCommentsKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [CONTENT_MANAGEMENT].[ProductImages]    Script Date: 6/19/2022 11:33:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CONTENT_MANAGEMENT].[ProductImages](
	[ProductImageKey] [uniqueidentifier] NOT NULL,
	[ProductKey] [uniqueidentifier] NOT NULL,
	[picture] [nchar](500) NULL,
	[Image] [image] NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[ProductImageKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [CONTENT_MANAGEMENT].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Product] FOREIGN KEY([ProductKey])
REFERENCES [CONTENT_MANAGEMENT].[Product] ([ProductKey])
GO
ALTER TABLE [CONTENT_MANAGEMENT].[Cart] CHECK CONSTRAINT [FK_Cart_Product]
GO
ALTER TABLE [CONTENT_MANAGEMENT].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Users] FOREIGN KEY([UserKey])
REFERENCES [COMMON].[Users] ([UsersKey])
GO
ALTER TABLE [CONTENT_MANAGEMENT].[Cart] CHECK CONSTRAINT [FK_Cart_Users]
GO
ALTER TABLE [CONTENT_MANAGEMENT].[ProductComments]  WITH CHECK ADD  CONSTRAINT [FK_ProductComments_Product] FOREIGN KEY([ProductKey])
REFERENCES [CONTENT_MANAGEMENT].[Product] ([ProductKey])
GO
ALTER TABLE [CONTENT_MANAGEMENT].[ProductComments] CHECK CONSTRAINT [FK_ProductComments_Product]
GO
ALTER TABLE [CONTENT_MANAGEMENT].[ProductComments]  WITH CHECK ADD  CONSTRAINT [FK_ProductComments_Users] FOREIGN KEY([UsersKey])
REFERENCES [COMMON].[Users] ([UsersKey])
GO
ALTER TABLE [CONTENT_MANAGEMENT].[ProductComments] CHECK CONSTRAINT [FK_ProductComments_Users]
GO
ALTER TABLE [CONTENT_MANAGEMENT].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_ProductImages_Product] FOREIGN KEY([ProductKey])
REFERENCES [CONTENT_MANAGEMENT].[Product] ([ProductKey])
GO
ALTER TABLE [CONTENT_MANAGEMENT].[ProductImages] CHECK CONSTRAINT [FK_ProductImages_Product]
GO
