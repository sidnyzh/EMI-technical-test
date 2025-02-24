USE [master]
GO
/****** Object:  Database [EMI_DB]    Script Date: 18/10/2024 1:36:10 a. m. ******/
CREATE DATABASE [EMI_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EMI_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER1\MSSQL\DATA\EMI_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EMI_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER1\MSSQL\DATA\EMI_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EMI_DB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EMI_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EMI_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EMI_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EMI_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EMI_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EMI_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [EMI_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EMI_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EMI_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EMI_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EMI_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EMI_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EMI_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EMI_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EMI_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EMI_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EMI_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EMI_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EMI_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EMI_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EMI_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EMI_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EMI_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EMI_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [EMI_DB] SET  MULTI_USER 
GO
ALTER DATABASE [EMI_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EMI_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EMI_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EMI_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EMI_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EMI_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EMI_DB', N'ON'
GO
ALTER DATABASE [EMI_DB] SET QUERY_STORE = ON
GO
ALTER DATABASE [EMI_DB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EMI_DB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 18/10/2024 1:36:10 a. m. ******/
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
/****** Object:  Table [dbo].[Departments]    Script Date: 18/10/2024 1:36:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeProjects]    Script Date: 18/10/2024 1:36:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeProjects](
	[EmployeeProjectId] [int] IDENTITY(1,1) NOT NULL,
	[Employee] [int] NOT NULL,
	[Project] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeProjects] PRIMARY KEY CLUSTERED 
(
	[EmployeeProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 18/10/2024 1:36:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Department] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CurrentPosition] [int] NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PositionHistory]    Script Date: 18/10/2024 1:36:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionHistory](
	[PositionHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[Employee] [int] NOT NULL,
	[Position] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_PositionHistory] PRIMARY KEY CLUSTERED 
(
	[PositionHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 18/10/2024 1:36:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[positionId] [int] NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[positionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 18/10/2024 1:36:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[Department] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestLogs]    Script Date: 18/10/2024 1:36:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[RequestMethod] [varchar](10) NOT NULL,
	[RequestPath] [varchar](255) NOT NULL,
	[QueryString] [varchar](255) NULL,
	[RequestBody] [text] NULL,
	[Headers] [text] NULL,
	[Email] [varchar](50) NULL,
	[Identifier] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18/10/2024 1:36:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](70) NOT NULL,
	[Name] [varchar](100) NULL,
	[Role] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([DepartmentID], [Name]) VALUES (1, N'Information Technology')
INSERT [dbo].[Departments] ([DepartmentID], [Name]) VALUES (2, N'Human Resources')
INSERT [dbo].[Departments] ([DepartmentID], [Name]) VALUES (3, N'Marketing')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeId], [Department], [Name], [CurrentPosition], [Salary]) VALUES (15, 1, N'Sidny Zapata', 2, CAST(2700.00 AS Decimal(18, 2)))
INSERT [dbo].[Employees] ([EmployeeId], [Department], [Name], [CurrentPosition], [Salary]) VALUES (16, 3, N'Julian Zapata', 8, CAST(1500.00 AS Decimal(18, 2)))
INSERT [dbo].[Employees] ([EmployeeId], [Department], [Name], [CurrentPosition], [Salary]) VALUES (17, 1, N'Camilo Serna', 4, CAST(3453.00 AS Decimal(18, 2)))
INSERT [dbo].[Employees] ([EmployeeId], [Department], [Name], [CurrentPosition], [Salary]) VALUES (18, 1, N'Juan Urrego', 5, CAST(4000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[PositionHistory] ON 

INSERT [dbo].[PositionHistory] ([PositionHistoryID], [Employee], [Position], [StartDate], [EndDate]) VALUES (7, 15, 2, CAST(N'2024-10-18T02:57:58.803' AS DateTime), NULL)
INSERT [dbo].[PositionHistory] ([PositionHistoryID], [Employee], [Position], [StartDate], [EndDate]) VALUES (8, 16, 8, CAST(N'2024-10-18T02:58:40.457' AS DateTime), NULL)
INSERT [dbo].[PositionHistory] ([PositionHistoryID], [Employee], [Position], [StartDate], [EndDate]) VALUES (9, 17, 5, CAST(N'2024-10-18T02:59:17.477' AS DateTime), CAST(N'2024-10-18T03:05:43.093' AS DateTime))
INSERT [dbo].[PositionHistory] ([PositionHistoryID], [Employee], [Position], [StartDate], [EndDate]) VALUES (10, 18, 5, CAST(N'2024-10-18T02:59:18.370' AS DateTime), NULL)
INSERT [dbo].[PositionHistory] ([PositionHistoryID], [Employee], [Position], [StartDate], [EndDate]) VALUES (11, 17, 4, CAST(N'2024-10-18T03:05:43.093' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[PositionHistory] OFF
GO
INSERT [dbo].[Positions] ([positionId], [Name]) VALUES (1, N'Junior Developer')
INSERT [dbo].[Positions] ([positionId], [Name]) VALUES (2, N'Developer')
INSERT [dbo].[Positions] ([positionId], [Name]) VALUES (3, N'SeniorDeveloper')
INSERT [dbo].[Positions] ([positionId], [Name]) VALUES (4, N'TechLead')
INSERT [dbo].[Positions] ([positionId], [Name]) VALUES (5, N'SoftwareArchitect')
INSERT [dbo].[Positions] ([positionId], [Name]) VALUES (6, N'TeamLeader')
INSERT [dbo].[Positions] ([positionId], [Name]) VALUES (7, N'ProjectManager')
INSERT [dbo].[Positions] ([positionId], [Name]) VALUES (8, N'DepartmentManager')
INSERT [dbo].[Positions] ([positionId], [Name]) VALUES (9, N'SeniorManager')
INSERT [dbo].[Positions] ([positionId], [Name]) VALUES (10, N'ExecutiveManager')
GO
SET IDENTITY_INSERT [dbo].[RequestLogs] ON 

INSERT [dbo].[RequestLogs] ([Id], [Timestamp], [RequestMethod], [RequestPath], [QueryString], [RequestBody], [Headers], [Email], [Identifier]) VALUES (1, CAST(N'2024-10-18T04:01:20.380' AS DateTime), N'POST', N'/api/User/Login', NULL, N'{
  "email": "syzapataho@gmail.com",
  "password": "1234"
}', N'{"Accept":"*/*","Host":"localhost:7074","User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36","Accept-Encoding":"gzip, deflate, br, zstd","Accept-Language":"es-ES,es;q=0.9","Content-Type":"application/json","Origin":"https://localhost:7074","Referer":"https://localhost:7074/swagger/index.html","Content-Length":"59","sec-ch-ua-platform":"\u0022Windows\u0022","sec-ch-ua":"\u0022Google Chrome\u0022;v=\u0022129\u0022, \u0022Not=A?Brand\u0022;v=\u00228\u0022, \u0022Chromium\u0022;v=\u0022129\u0022","sec-ch-ua-mobile":"?0","sec-fetch-site":"same-origin","sec-fetch-mode":"cors","sec-fetch-dest":"empty","priority":"u=1, i"}', NULL, N'0HN7F55INQ0EF:00000009')
INSERT [dbo].[RequestLogs] ([Id], [Timestamp], [RequestMethod], [RequestPath], [QueryString], [RequestBody], [Headers], [Email], [Identifier]) VALUES (2, CAST(N'2024-10-18T04:13:51.700' AS DateTime), N'GET', N'/api/Employee', NULL, NULL, N'{"Accept":"*/*","Host":"localhost:7074","User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36","Accept-Encoding":"gzip, deflate, br, zstd","Accept-Language":"es-ES,es;q=0.9","Authorization":"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InN5emFwYXRhaG9AZ21haWwuY29tIiwicm9sZSI6IkFkbWluIiwiZXhwIjoxNzI5MjUyODg5LCJhdWQiOiJFTUkifQ.09WJjIQWzTalzlYB8RjRoEa0qKANKVeL-N35NZChLD4","Referer":"https://localhost:7074/swagger/index.html","sec-ch-ua-platform":"\u0022Windows\u0022","sec-ch-ua":"\u0022Google Chrome\u0022;v=\u0022129\u0022, \u0022Not=A?Brand\u0022;v=\u00228\u0022, \u0022Chromium\u0022;v=\u0022129\u0022","sec-ch-ua-mobile":"?0","sec-fetch-site":"same-origin","sec-fetch-mode":"cors","sec-fetch-dest":"empty","priority":"u=1, i"}', NULL, N'0HN7F5CUI8QLR:00000009')
INSERT [dbo].[RequestLogs] ([Id], [Timestamp], [RequestMethod], [RequestPath], [QueryString], [RequestBody], [Headers], [Email], [Identifier]) VALUES (3, CAST(N'2024-10-18T04:15:12.843' AS DateTime), N'POST', N'/api/User/CreateUser', NULL, N'{
  "email": "jz@gmail.com",
  "password": "1234",
  "role": 2,
  "name": "Julian Zapata"
}', N'{"Accept":"*/*","Host":"localhost:7074","User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36","Accept-Encoding":"gzip, deflate, br, zstd","Accept-Language":"es-ES,es;q=0.9","Authorization":"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InN5emFwYXRhaG9AZ21haWwuY29tIiwicm9sZSI6IkFkbWluIiwiZXhwIjoxNzI5MjUyODg5LCJhdWQiOiJFTUkifQ.09WJjIQWzTalzlYB8RjRoEa0qKANKVeL-N35NZChLD4","Content-Type":"application/json","Origin":"https://localhost:7074","Referer":"https://localhost:7074/swagger/index.html","Content-Length":"91","sec-ch-ua-platform":"\u0022Windows\u0022","sec-ch-ua":"\u0022Google Chrome\u0022;v=\u0022129\u0022, \u0022Not=A?Brand\u0022;v=\u00228\u0022, \u0022Chromium\u0022;v=\u0022129\u0022","sec-ch-ua-mobile":"?0","sec-fetch-site":"same-origin","sec-fetch-mode":"cors","sec-fetch-dest":"empty","priority":"u=1, i"}', NULL, N'0HN7F5CUI8QLR:0000000B')
INSERT [dbo].[RequestLogs] ([Id], [Timestamp], [RequestMethod], [RequestPath], [QueryString], [RequestBody], [Headers], [Email], [Identifier]) VALUES (4, CAST(N'2024-10-18T04:15:45.290' AS DateTime), N'POST', N'/api/User/Login', NULL, N'{
 "email": "jz@gmail.com",
  "password": "1234"
}', N'{"Accept":"*/*","Host":"localhost:7074","User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36","Accept-Encoding":"gzip, deflate, br, zstd","Accept-Language":"es-ES,es;q=0.9","Content-Type":"application/json","Origin":"https://localhost:7074","Referer":"https://localhost:7074/swagger/index.html","Content-Length":"50","sec-ch-ua-platform":"\u0022Windows\u0022","sec-ch-ua":"\u0022Google Chrome\u0022;v=\u0022129\u0022, \u0022Not=A?Brand\u0022;v=\u00228\u0022, \u0022Chromium\u0022;v=\u0022129\u0022","sec-ch-ua-mobile":"?0","sec-fetch-site":"same-origin","sec-fetch-mode":"cors","sec-fetch-dest":"empty","priority":"u=1, i"}', NULL, N'0HN7F5CUI8QLR:0000000D')
INSERT [dbo].[RequestLogs] ([Id], [Timestamp], [RequestMethod], [RequestPath], [QueryString], [RequestBody], [Headers], [Email], [Identifier]) VALUES (5, CAST(N'2024-10-18T04:16:14.460' AS DateTime), N'DELETE', N'/api/Employee/15', NULL, NULL, N'{"Accept":"*/*","Host":"localhost:7074","User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36","Accept-Encoding":"gzip, deflate, br, zstd","Accept-Language":"es-ES,es;q=0.9","Authorization":"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imp6QGdtYWlsLmNvbSIsInJvbGUiOiJVc2VyIiwiZXhwIjoxNzI5MjUzNzUwLCJhdWQiOiJFTUkifQ.cfnXAHzkylamH-kZ2nyy838LlsXw6eOfp9pz7PhviUo","Origin":"https://localhost:7074","Referer":"https://localhost:7074/swagger/index.html","sec-ch-ua-platform":"\u0022Windows\u0022","sec-ch-ua":"\u0022Google Chrome\u0022;v=\u0022129\u0022, \u0022Not=A?Brand\u0022;v=\u00228\u0022, \u0022Chromium\u0022;v=\u0022129\u0022","sec-ch-ua-mobile":"?0","sec-fetch-site":"same-origin","sec-fetch-mode":"cors","sec-fetch-dest":"empty","priority":"u=1, i"}', NULL, N'0HN7F5CUI8QLR:0000000F')
INSERT [dbo].[RequestLogs] ([Id], [Timestamp], [RequestMethod], [RequestPath], [QueryString], [RequestBody], [Headers], [Email], [Identifier]) VALUES (6, CAST(N'2024-10-18T04:30:38.997' AS DateTime), N'GET', N'/api/Employee', NULL, NULL, N'{"Accept":"*/*","Host":"localhost:7074","User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36","Accept-Encoding":"gzip, deflate, br, zstd","Accept-Language":"es-ES,es;q=0.9","Authorization":"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imp6QGdtYWlsLmNvbSIsInJvbGUiOiJVc2VyIiwiZXhwIjoxNzI5MjUzNzUwLCJhdWQiOiJFTUkifQ.cfnXAHzkylamH-kZ2nyy838LlsXw6eOfp9pz7PhviUo","Referer":"https://localhost:7074/swagger/index.html","sec-ch-ua-platform":"\u0022Windows\u0022","sec-ch-ua":"\u0022Google Chrome\u0022;v=\u0022129\u0022, \u0022Not=A?Brand\u0022;v=\u00228\u0022, \u0022Chromium\u0022;v=\u0022129\u0022","sec-ch-ua-mobile":"?0","sec-fetch-site":"same-origin","sec-fetch-mode":"cors","sec-fetch-dest":"empty","priority":"u=1, i"}', NULL, N'0HN7F5KRKN743:00000001')
INSERT [dbo].[RequestLogs] ([Id], [Timestamp], [RequestMethod], [RequestPath], [QueryString], [RequestBody], [Headers], [Email], [Identifier]) VALUES (7, CAST(N'2024-10-18T04:30:53.253' AS DateTime), N'GET', N'/api/Employee/15', NULL, NULL, N'{"Accept":"*/*","Host":"localhost:7074","User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36","Accept-Encoding":"gzip, deflate, br, zstd","Accept-Language":"es-ES,es;q=0.9","Authorization":"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imp6QGdtYWlsLmNvbSIsInJvbGUiOiJVc2VyIiwiZXhwIjoxNzI5MjUzNzUwLCJhdWQiOiJFTUkifQ.cfnXAHzkylamH-kZ2nyy838LlsXw6eOfp9pz7PhviUo","Referer":"https://localhost:7074/swagger/index.html","sec-ch-ua-platform":"\u0022Windows\u0022","sec-ch-ua":"\u0022Google Chrome\u0022;v=\u0022129\u0022, \u0022Not=A?Brand\u0022;v=\u00228\u0022, \u0022Chromium\u0022;v=\u0022129\u0022","sec-ch-ua-mobile":"?0","sec-fetch-site":"same-origin","sec-fetch-mode":"cors","sec-fetch-dest":"empty","priority":"u=1, i"}', NULL, N'0HN7F5KRKN744:00000001')
INSERT [dbo].[RequestLogs] ([Id], [Timestamp], [RequestMethod], [RequestPath], [QueryString], [RequestBody], [Headers], [Email], [Identifier]) VALUES (8, CAST(N'2024-10-18T04:34:40.387' AS DateTime), N'GET', N'/api/Employee/16', NULL, NULL, N'{"Accept":"*/*","Host":"localhost:7074","User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36","Accept-Encoding":"gzip, deflate, br, zstd","Accept-Language":"es-ES,es;q=0.9","Authorization":"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imp6QGdtYWlsLmNvbSIsInJvbGUiOiJVc2VyIiwiZXhwIjoxNzI5MjUzNzUwLCJhdWQiOiJFTUkifQ.cfnXAHzkylamH-kZ2nyy838LlsXw6eOfp9pz7PhviUo","Referer":"https://localhost:7074/swagger/index.html","sec-ch-ua-platform":"\u0022Windows\u0022","sec-ch-ua":"\u0022Google Chrome\u0022;v=\u0022129\u0022, \u0022Not=A?Brand\u0022;v=\u00228\u0022, \u0022Chromium\u0022;v=\u0022129\u0022","sec-ch-ua-mobile":"?0","sec-fetch-site":"same-origin","sec-fetch-mode":"cors","sec-fetch-dest":"empty","priority":"u=1, i"}', NULL, N'0HN7F5KRKN745:00000001')
INSERT [dbo].[RequestLogs] ([Id], [Timestamp], [RequestMethod], [RequestPath], [QueryString], [RequestBody], [Headers], [Email], [Identifier]) VALUES (9, CAST(N'2024-10-18T04:37:27.957' AS DateTime), N'DELETE', N'/api/Employee/18', NULL, NULL, N'{"Accept":"*/*","Host":"localhost:7074","User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36","Accept-Encoding":"gzip, deflate, br, zstd","Accept-Language":"es-ES,es;q=0.9","Authorization":"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imp6QGdtYWlsLmNvbSIsInJvbGUiOiJVc2VyIiwiZXhwIjoxNzI5MjUzNzUwLCJhdWQiOiJFTUkifQ.cfnXAHzkylamH-kZ2nyy838LlsXw6eOfp9pz7PhviUo","Origin":"https://localhost:7074","Referer":"https://localhost:7074/swagger/index.html","sec-ch-ua-platform":"\u0022Windows\u0022","sec-ch-ua":"\u0022Google Chrome\u0022;v=\u0022129\u0022, \u0022Not=A?Brand\u0022;v=\u00228\u0022, \u0022Chromium\u0022;v=\u0022129\u0022","sec-ch-ua-mobile":"?0","sec-fetch-site":"same-origin","sec-fetch-mode":"cors","sec-fetch-dest":"empty","priority":"u=1, i"}', NULL, N'0HN7F5KRKN746:00000001')
INSERT [dbo].[RequestLogs] ([Id], [Timestamp], [RequestMethod], [RequestPath], [QueryString], [RequestBody], [Headers], [Email], [Identifier]) VALUES (10, CAST(N'2024-10-18T05:08:03.160' AS DateTime), N'GET', N'/api/Employee', NULL, NULL, N'{"Accept":"*/*","Host":"localhost:7074","User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36","Accept-Encoding":"gzip, deflate, br, zstd","Accept-Language":"es-ES,es;q=0.9","Authorization":"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imp6QGdtYWlsLmNvbSIsInJvbGUiOiJVc2VyIiwiZXhwIjoxNzI5MjUzNzUwLCJhdWQiOiJFTUkifQ.cfnXAHzkylamH-kZ2nyy838LlsXw6eOfp9pz7PhviUo","Referer":"https://localhost:7074/swagger/index.html","sec-ch-ua-platform":"\u0022Windows\u0022","sec-ch-ua":"\u0022Google Chrome\u0022;v=\u0022129\u0022, \u0022Not=A?Brand\u0022;v=\u00228\u0022, \u0022Chromium\u0022;v=\u0022129\u0022","sec-ch-ua-mobile":"?0","sec-fetch-site":"same-origin","sec-fetch-mode":"cors","sec-fetch-dest":"empty","priority":"u=1, i"}', NULL, N'0HN7F6AFTIH6E:00000001')
SET IDENTITY_INSERT [dbo].[RequestLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Email], [Password], [Name], [Role]) VALUES (1, N'syzapataho@gmail.com', N'$2a$11$at.bQRyVYfK/hTjWZ9na8OnjnkmUGk2nRbwPXqie3SnID9z0QwaDW', NULL, N'Admin')
INSERT [dbo].[Users] ([UserId], [Email], [Password], [Name], [Role]) VALUES (2, N'jz@gmail.com', N'$2a$11$MR2cLCNN6clMribVvynRUOKO1dxSBp8jUD1hrY7Yqfz/qp4Vx8kaW', N'Julian Zapata', N'User')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Email]    Script Date: 18/10/2024 1:36:11 a. m. ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProjects_Employees] FOREIGN KEY([Employee])
REFERENCES [dbo].[Employees] ([EmployeeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeProjects] CHECK CONSTRAINT [FK_EmployeeProjects_Employees]
GO
ALTER TABLE [dbo].[EmployeeProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProjects_Projects] FOREIGN KEY([Project])
REFERENCES [dbo].[Projects] ([ProjectID])
GO
ALTER TABLE [dbo].[EmployeeProjects] CHECK CONSTRAINT [FK_EmployeeProjects_Projects]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments] FOREIGN KEY([Department])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Positions] FOREIGN KEY([CurrentPosition])
REFERENCES [dbo].[Positions] ([positionId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Positions]
GO
ALTER TABLE [dbo].[PositionHistory]  WITH CHECK ADD  CONSTRAINT [FK_PositionHistory_Employees] FOREIGN KEY([Employee])
REFERENCES [dbo].[Employees] ([EmployeeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PositionHistory] CHECK CONSTRAINT [FK_PositionHistory_Employees]
GO
ALTER TABLE [dbo].[PositionHistory]  WITH CHECK ADD  CONSTRAINT [FK_PositionHistory_Positions] FOREIGN KEY([Position])
REFERENCES [dbo].[Positions] ([positionId])
GO
ALTER TABLE [dbo].[PositionHistory] CHECK CONSTRAINT [FK_PositionHistory_Positions]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Departments] FOREIGN KEY([Department])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Departments]
GO
USE [master]
GO
ALTER DATABASE [EMI_DB] SET  READ_WRITE 
GO
