USE [master]
GO


/****** Object:  Database [IngredientChecklist]    Script Date: 2/3/2019 5:52:54 AM ******/
CREATE DATABASE [IngredientChecklist]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IngredientChecklist', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\IngredientChecklist.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IngredientChecklist_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\IngredientChecklist_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [IngredientChecklist] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IngredientChecklist].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IngredientChecklist] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IngredientChecklist] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IngredientChecklist] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IngredientChecklist] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IngredientChecklist] SET ARITHABORT OFF 
GO
ALTER DATABASE [IngredientChecklist] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IngredientChecklist] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IngredientChecklist] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IngredientChecklist] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IngredientChecklist] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IngredientChecklist] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IngredientChecklist] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IngredientChecklist] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IngredientChecklist] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IngredientChecklist] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IngredientChecklist] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IngredientChecklist] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IngredientChecklist] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IngredientChecklist] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IngredientChecklist] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IngredientChecklist] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IngredientChecklist] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IngredientChecklist] SET RECOVERY FULL 
GO
ALTER DATABASE [IngredientChecklist] SET  MULTI_USER 
GO
ALTER DATABASE [IngredientChecklist] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IngredientChecklist] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IngredientChecklist] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IngredientChecklist] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IngredientChecklist] SET DELAYED_DURABILITY = DISABLED 
GO
USE [IngredientChecklist]
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 2/3/2019 5:52:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ingredient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](1000) NOT NULL,
	[IsChecked] [bit] NULL,
	[RecipeId] [int] NOT NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Recipe]    Script Date: 2/3/2019 5:52:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recipe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/3/2019 5:52:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](100) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Ingredient] ON 

INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (1, N'Bread', 0, 6)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (2, N'Butter', 0, 6)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (3, N'Cheese', 0, 6)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (4, N'Chilled Pasta', 0, 7)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (5, N'Vinegar', 0, 7)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (6, N'Oil', 0, 7)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (7, N'Sugar', 0, 8)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (8, N'Butter', 0, 8)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (9, N'Flour', 0, 8)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (10, N'Eggs', 0, 8)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (11, N'Vanilla Extract', 0, 8)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (12, N'Milk', 0, 8)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (13, N'Baking Powder', 0, 8)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (14, N'Eggs', 0, 9)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (15, N'Confectioners’ Sugar', 0, 9)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (16, N'Almond Flour', 0, 9)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (17, N'Salt', 0, 9)
INSERT [dbo].[Ingredient] ([Id], [Name], [IsChecked], [RecipeId]) VALUES (18, N'Castor sugar', 0, 9)
SET IDENTITY_INSERT [dbo].[Ingredient] OFF
SET IDENTITY_INSERT [dbo].[Recipe] ON 

INSERT [dbo].[Recipe] ([Id], [Name], [UserId]) VALUES (6, N'Grilled Cheese', 3)
INSERT [dbo].[Recipe] ([Id], [Name], [UserId]) VALUES (7, N'Pasta Salad', 3)
INSERT [dbo].[Recipe] ([Id], [Name], [UserId]) VALUES (8, N'Cake', 4)
INSERT [dbo].[Recipe] ([Id], [Name], [UserId]) VALUES (9, N'Macarons', 4)
SET IDENTITY_INSERT [dbo].[Recipe] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FullName], [UserName], [Password], [Guid]) VALUES (3, N'Arthur Boris', N'user1', N'user1', N'9b3a3b07-6d89-4bf0-a80c-c1fd4bf1dc35')
INSERT [dbo].[User] ([Id], [FullName], [UserName], [Password], [Guid]) VALUES (4, N'Anastasia Petrov', N'user2', N'user2', N'96ebc448-04c1-4fad-ae33-575b00c7faf9')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Ingredient]  WITH CHECK ADD  CONSTRAINT [FK_Ingredient_Recipe] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipe] ([Id])
GO
ALTER TABLE [dbo].[Ingredient] CHECK CONSTRAINT [FK_Ingredient_Recipe]
GO
ALTER TABLE [dbo].[Recipe]  WITH CHECK ADD  CONSTRAINT [FK_Recipe_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Recipe] CHECK CONSTRAINT [FK_Recipe_User]
GO
USE [master]
GO
ALTER DATABASE [IngredientChecklist] SET  READ_WRITE 
GO
