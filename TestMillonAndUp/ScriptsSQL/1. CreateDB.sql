CREATE DATABASE [BDTestRealCompany]
GO
USE [BDTestRealCompany]
GO
/****** Object:  Schema [RealCompany]    Script Date: 24/04/2021 11:13:34 ******/
CREATE SCHEMA [RealCompany]
GO
/****** Object:  Table [RealCompany].[Owner]    Script Date: 24/04/2021 11:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RealCompany].[Owner](
	[IdOwner] [bigint] IDENTITY(1000,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[NikName] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](150) NOT NULL,
	[Photo] [ntext] NULL,
	[BirthDay] [datetime] NOT NULL,
	[State] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED 
(
	[IdOwner] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [RealCompany].[Property]    Script Date: 24/04/2021 11:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RealCompany].[Property](
	[IdProperty] [bigint] IDENTITY(10000,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Address] [nvarchar](150) NOT NULL,
	[Price] [decimal](22, 2) NOT NULL,
	[CodeInternal] [nchar](10) NOT NULL,
	[Year] [int] NOT NULL,
	[IDOwner] [bigint] NOT NULL,
	[State] [tinyint] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[IdProperty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RealCompany].[PropertyImage]    Script Date: 24/04/2021 11:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RealCompany].[PropertyImage](
	[IdPropertyImage] [bigint] IDENTITY(1,1) NOT NULL,
	[IdProperty] [bigint] NOT NULL,
	[file] [ntext] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_PropertyImage] PRIMARY KEY CLUSTERED 
(
	[IdPropertyImage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [RealCompany].[PropertyTrace]    Script Date: 24/04/2021 11:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RealCompany].[PropertyTrace](
	[IdPropertyTrace] [bigint] IDENTITY(10000,1) NOT NULL,
	[DateSale] [datetime] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Value] [decimal](22, 2) NOT NULL,
	[Tax] [decimal](18, 0) NOT NULL,
	[IdProperty] [bigint] NOT NULL,
 CONSTRAINT [PK_PropertyTrace] PRIMARY KEY CLUSTERED 
(
	[IdPropertyTrace] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [RealCompany].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Owner] FOREIGN KEY([IDOwner])
REFERENCES [RealCompany].[Owner] ([IdOwner])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [RealCompany].[Property] CHECK CONSTRAINT [FK_Property_Owner]
GO
ALTER TABLE [RealCompany].[PropertyImage]  WITH CHECK ADD  CONSTRAINT [FK_PropertyImage_Property] FOREIGN KEY([IdProperty])
REFERENCES [RealCompany].[Property] ([IdProperty])
GO
ALTER TABLE [RealCompany].[PropertyImage] CHECK CONSTRAINT [FK_PropertyImage_Property]
GO
ALTER TABLE [RealCompany].[PropertyTrace]  WITH CHECK ADD  CONSTRAINT [FK_PropertyTrace_Property] FOREIGN KEY([IdProperty])
REFERENCES [RealCompany].[Property] ([IdProperty])
GO
ALTER TABLE [RealCompany].[PropertyTrace] CHECK CONSTRAINT [FK_PropertyTrace_Property]
GO
