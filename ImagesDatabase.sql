USE [master]
GO
/****** Object:  Database [ImagesDatabase]    Script Date: 2/17/2016 2:04:18 PM ******/
CREATE DATABASE [ImagesDatabase] ON  PRIMARY 
( NAME = N'ImagesDatabase', FILENAME = N'D:\work\MSSQLDatabases\ImagesDatabase.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ImagesDatabase_log', FILENAME = N'D:\work\MSSQLDatabases\ImagesDatabase_log.ldf' , SIZE = 3456KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ImagesDatabase] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ImagesDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ImagesDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ImagesDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ImagesDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ImagesDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ImagesDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [ImagesDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ImagesDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ImagesDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ImagesDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ImagesDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ImagesDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ImagesDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ImagesDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ImagesDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ImagesDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ImagesDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ImagesDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ImagesDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ImagesDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ImagesDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ImagesDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ImagesDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ImagesDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [ImagesDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [ImagesDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ImagesDatabase] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ImagesDatabase', N'ON'
GO
USE [ImagesDatabase]
GO
/****** Object:  User [ImagesUser]    Script Date: 2/17/2016 2:04:18 PM ******/
CREATE USER [ImagesUser] FOR LOGIN [ImagesUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [ImagesUser]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 2/17/2016 2:04:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [uniqueidentifier] NOT NULL,
	[ImageName] [nvarchar](max) NOT NULL,
	[Thumbnail] [image] NULL,
	[Data] [image] NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [ImagesDatabase] SET  READ_WRITE 
GO
