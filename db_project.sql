USE [master]
GO
/****** Object:  Database [db_project]    Script Date: 07/12/2022 08:26:52 ******/
CREATE DATABASE [db_project]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_project', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_project.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_project_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_project_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_project] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_project] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_project] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_project] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_project] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_project] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_project] SET RECOVERY FULL 
GO
ALTER DATABASE [db_project] SET  MULTI_USER 
GO
ALTER DATABASE [db_project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_project] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_project] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_project] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_project] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_project] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_project', N'ON'
GO
ALTER DATABASE [db_project] SET QUERY_STORE = OFF
GO
USE [db_project]
GO
/****** Object:  Table [dbo].[Detailorder]    Script Date: 07/12/2022 08:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detailorder](
	[Detailid] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [nchar](10) NOT NULL,
	[MenuID] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Detailorder] PRIMARY KEY CLUSTERED 
(
	[Detailid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Headerorder]    Script Date: 07/12/2022 08:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Headerorder](
	[OrderID] [nchar](10) NOT NULL,
	[EmpeloyeeID] [nchar](6) NULL,
	[MemberID] [nchar](8) NULL,
	[Date] [date] NULL,
	[Payment] [int] NULL,
	[kembali] [int] NULL,
	[bayar] [int] NULL,
 CONSTRAINT [PK_Headerorder] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Msemployee]    Script Date: 07/12/2022 08:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Msemployee](
	[EmployeeID] [nchar](6) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[Handphone] [nvarchar](13) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Msemployee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Msmember]    Script Date: 07/12/2022 08:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Msmember](
	[MemberID] [nchar](6) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Handphone] [nvarchar](13) NOT NULL,
	[JoinDate] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Msmenu]    Script Date: 07/12/2022 08:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Msmenu](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Price] [int] NULL,
	[Photo] [nvarchar](100) NULL,
 CONSTRAINT [PK_Msmenu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Msemployee] ([EmployeeID], [Name], [Email], [password], [Handphone], [Position]) VALUES (N'ADM001', N'Ucup', N'admin@gmail.com', N'321', N'087889297', N'admin')
INSERT [dbo].[Msemployee] ([EmployeeID], [Name], [Email], [password], [Handphone], [Position]) VALUES (N'CHR001', N'Tony', N'tony@gmail.com', N'123', N'0878898672', N'cashier')
INSERT [dbo].[Msemployee] ([EmployeeID], [Name], [Email], [password], [Handphone], [Position]) VALUES (N'CHR002', N'Fakhri', N'fakhrizain9@gmail.com', N'123', N'087884984112', N'admin')
GO
INSERT [dbo].[Msmember] ([MemberID], [Name], [Email], [Handphone], [JoinDate]) VALUES (N'MBR001', N'Abim', N'abim@gmail.com', N'087884984112', CAST(N'2022-12-06' AS Date))
INSERT [dbo].[Msmember] ([MemberID], [Name], [Email], [Handphone], [JoinDate]) VALUES (N'MBR002', N'Gibran', N'gibran@gmail.com', N'092929922', CAST(N'2022-12-06' AS Date))
INSERT [dbo].[Msmember] ([MemberID], [Name], [Email], [Handphone], [JoinDate]) VALUES (N'MBR003', N'Wisnu', N'wisnu@gmail.com', N'087887827872', CAST(N'2022-12-07' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Msmenu] ON 

INSERT [dbo].[Msmenu] ([MenuID], [Name], [Price], [Photo]) VALUES (3, N'Mie Ayam', 10000, N'C:\Users\fakhr\Downloads\fotoProject\mieAyam.jpeg')
INSERT [dbo].[Msmenu] ([MenuID], [Name], [Price], [Photo]) VALUES (4, N'Bakso', 12000, N'C:\Users\fakhr\Downloads\fotoProject\bakso.jpg')
INSERT [dbo].[Msmenu] ([MenuID], [Name], [Price], [Photo]) VALUES (6, N'Nasi Goreng', 13000, N'C:\Users\fakhr\Downloads\fotoProject\nasiGoreng.jpeg')
INSERT [dbo].[Msmenu] ([MenuID], [Name], [Price], [Photo]) VALUES (7, N'Milkshake Coklat', 8000, N'C:\Users\fakhr\Downloads\fotoProject\milkshakeCoklat.jpg')
SET IDENTITY_INSERT [dbo].[Msmenu] OFF
GO
USE [master]
GO
ALTER DATABASE [db_project] SET  READ_WRITE 
GO
