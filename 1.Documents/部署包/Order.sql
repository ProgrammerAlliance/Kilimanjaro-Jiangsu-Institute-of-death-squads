USE [master]
GO
/****** Object:  Database [Order]    Script Date: 02/08/2018 18:48:26 ******/
CREATE DATABASE [Order] ON  PRIMARY 
( NAME = N'Order', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Order.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Order_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Order_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Order] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Order].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Order] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Order] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Order] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Order] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Order] SET ARITHABORT OFF
GO
ALTER DATABASE [Order] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Order] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Order] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Order] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Order] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Order] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Order] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Order] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Order] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Order] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Order] SET  DISABLE_BROKER
GO
ALTER DATABASE [Order] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Order] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Order] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Order] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Order] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Order] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Order] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Order] SET  READ_WRITE
GO
ALTER DATABASE [Order] SET RECOVERY FULL
GO
ALTER DATABASE [Order] SET  MULTI_USER
GO
ALTER DATABASE [Order] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Order] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Order', N'ON'
GO
USE [Order]
GO
/****** Object:  Table [dbo].[Deptment]    Script Date: 02/08/2018 18:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Deptment](
	[DeptNo] [int] NOT NULL,
	[DeptName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DEPTMENT] PRIMARY KEY CLUSTERED 
(
	[DeptNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Deptment] ([DeptNo], [DeptName]) VALUES (1, N'技术部')
INSERT [dbo].[Deptment] ([DeptNo], [DeptName]) VALUES (2, N'财务部')
INSERT [dbo].[Deptment] ([DeptNo], [DeptName]) VALUES (3, N'工程部')
INSERT [dbo].[Deptment] ([DeptNo], [DeptName]) VALUES (4, N'人事部')
INSERT [dbo].[Deptment] ([DeptNo], [DeptName]) VALUES (5, N'销售部')
INSERT [dbo].[Deptment] ([DeptNo], [DeptName]) VALUES (6, N'测试部')
INSERT [dbo].[Deptment] ([DeptNo], [DeptName]) VALUES (7, N'法规部')
INSERT [dbo].[Deptment] ([DeptNo], [DeptName]) VALUES (8, N'商务部')
INSERT [dbo].[Deptment] ([DeptNo], [DeptName]) VALUES (9, N'生产部')
INSERT [dbo].[Deptment] ([DeptNo], [DeptName]) VALUES (10, N'行政部')
INSERT [dbo].[Deptment] ([DeptNo], [DeptName]) VALUES (11, N'质量管理部')
/****** Object:  Table [dbo].[UserType]    Script Date: 02/08/2018 18:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserType](
	[Type] [int] NOT NULL,
	[Typename] [varchar](50) NOT NULL,
 CONSTRAINT [PK_USERTYPE] PRIMARY KEY CLUSTERED 
(
	[Type] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[UserType] ([Type], [Typename]) VALUES (1, N'管理员')
INSERT [dbo].[UserType] ([Type], [Typename]) VALUES (2, N'普通用户')
/****** Object:  Table [dbo].[Restaurant]    Script Date: 02/08/2018 18:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Restaurant](
	[RestaurantId] [int] NOT NULL,
	[RestaurantName] [varchar](16) NOT NULL,
 CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED 
(
	[RestaurantId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Restaurant] ([RestaurantId], [RestaurantName]) VALUES (1, N'纳龙饭店')
INSERT [dbo].[Restaurant] ([RestaurantId], [RestaurantName]) VALUES (2, N'麻辣香锅')
INSERT [dbo].[Restaurant] ([RestaurantId], [RestaurantName]) VALUES (3, N'黄焖鸡米饭')
INSERT [dbo].[Restaurant] ([RestaurantId], [RestaurantName]) VALUES (4, N'湘菜馆')
INSERT [dbo].[Restaurant] ([RestaurantId], [RestaurantName]) VALUES (5, N'兰州国际')
INSERT [dbo].[Restaurant] ([RestaurantId], [RestaurantName]) VALUES (6, N'沙县大酒店')
/****** Object:  Table [dbo].[OrderTable]    Script Date: 02/08/2018 18:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderTable](
	[OrderNo] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CreateTime] [datetime] NULL,
	[Clean] [int] NULL,
	[Remark] [varchar](50) NULL,
 CONSTRAINT [PK_OrderTable] PRIMARY KEY CLUSTERED 
(
	[OrderNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[OrderTable] ON
INSERT [dbo].[OrderTable] ([OrderNo], [UserId], [CreateTime], [Clean], [Remark]) VALUES (2, 1009, CAST(0x0000A87E00B91034 AS DateTime), 0, N'不要辣')
INSERT [dbo].[OrderTable] ([OrderNo], [UserId], [CreateTime], [Clean], [Remark]) VALUES (7, 1010, CAST(0x0000A88100C5565C AS DateTime), 0, N'不要酸')
INSERT [dbo].[OrderTable] ([OrderNo], [UserId], [CreateTime], [Clean], [Remark]) VALUES (9, 1012, CAST(0x0000A88100C5565C AS DateTime), 0, N'不要苦')
INSERT [dbo].[OrderTable] ([OrderNo], [UserId], [CreateTime], [Clean], [Remark]) VALUES (10, 1013, CAST(0x0000A88100C5565C AS DateTime), 0, N'不要香菜')
INSERT [dbo].[OrderTable] ([OrderNo], [UserId], [CreateTime], [Clean], [Remark]) VALUES (11, 1014, CAST(0x0000A88100C5565C AS DateTime), 0, N'不要香菜')
INSERT [dbo].[OrderTable] ([OrderNo], [UserId], [CreateTime], [Clean], [Remark]) VALUES (12, 1015, CAST(0x0000A88100C5565C AS DateTime), 0, N'不要香菜')
INSERT [dbo].[OrderTable] ([OrderNo], [UserId], [CreateTime], [Clean], [Remark]) VALUES (13, 1016, CAST(0x0000A88100C5565C AS DateTime), 1, N'不要香菜')
INSERT [dbo].[OrderTable] ([OrderNo], [UserId], [CreateTime], [Clean], [Remark]) VALUES (14, 1017, CAST(0x0000A88100C5565C AS DateTime), 1, N'不要香菜')
INSERT [dbo].[OrderTable] ([OrderNo], [UserId], [CreateTime], [Clean], [Remark]) VALUES (17, 1047, CAST(0x0000A88100C5565C AS DateTime), 0, N'不要香菜')
INSERT [dbo].[OrderTable] ([OrderNo], [UserId], [CreateTime], [Clean], [Remark]) VALUES (18, 1046, CAST(0x0000A88100C5565C AS DateTime), 0, N'不要香菜')
INSERT [dbo].[OrderTable] ([OrderNo], [UserId], [CreateTime], [Clean], [Remark]) VALUES (31, 1045, CAST(0x0000A88100C5565C AS DateTime), 0, N'不要香菜')
INSERT [dbo].[OrderTable] ([OrderNo], [UserId], [CreateTime], [Clean], [Remark]) VALUES (34, 1023, CAST(0x0000A88000B925A8 AS DateTime), 0, N'不要香菜')
INSERT [dbo].[OrderTable] ([OrderNo], [UserId], [CreateTime], [Clean], [Remark]) VALUES (39, 2002, CAST(0x0000A88100C5565C AS DateTime), 0, N'不要香菜')
INSERT [dbo].[OrderTable] ([OrderNo], [UserId], [CreateTime], [Clean], [Remark]) VALUES (61, 1005, CAST(0x0000A88100C5565C AS DateTime), 0, N'terwtwetwert')
SET IDENTITY_INSERT [dbo].[OrderTable] OFF
/****** Object:  Table [dbo].[Menu]    Script Date: 02/08/2018 18:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Menu](
	[RestaurantId] [int] NOT NULL,
	[FoodId] [int] IDENTITY(1,1) NOT NULL,
	[FoodName] [varchar](50) NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_MENU] PRIMARY KEY CLUSTERED 
(
	[FoodId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON
INSERT [dbo].[Menu] ([RestaurantId], [FoodId], [FoodName], [Price]) VALUES (1, 1, N'竹笋烤肉', 25)
INSERT [dbo].[Menu] ([RestaurantId], [FoodId], [FoodName], [Price]) VALUES (1, 2, N'心电套餐', 188)
INSERT [dbo].[Menu] ([RestaurantId], [FoodId], [FoodName], [Price]) VALUES (1, 3, N'急诊套餐', 288)
INSERT [dbo].[Menu] ([RestaurantId], [FoodId], [FoodName], [Price]) VALUES (2, 4, N'肥牛香锅', 18)
SET IDENTITY_INSERT [dbo].[Menu] OFF
/****** Object:  Table [dbo].[Emp]    Script Date: 02/08/2018 18:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Emp](
	[UserId] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserType] [int] NOT NULL,
	[UserPwd] [varchar](16) NOT NULL,
	[Deptno] [int] NOT NULL,
	[Gender] [char](4) NOT NULL,
 CONSTRAINT [PK_EMP] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1001, N'管理员', 1, N'123', 2, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1002, N'魏晓峰', 2, N'111', 5, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1003, N'小李', 2, N'111', 3, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1004, N'小风', 2, N'111', 4, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1006, N'小宏', 2, N'111', 6, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1008, N'彰武', 2, N'111', 8, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1010, N'张伟', 2, N'111', 10, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1011, N'沈大炮', 2, N'111', 1, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1012, N'王大苟', 2, N'111', 3, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1013, N'墨蒙牛', 2, N'111', 6, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1014, N'小星星', 2, N'111', 8, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1015, N'饼干', 2, N'111', 2, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1016, N'牛奶', 2, N'111', 4, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1017, N'巧克力', 2, N'111', 5, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1018, N'曲奇', 2, N'111', 3, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1019, N'夹心饼', 2, N'111', 6, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1020, N'苹果派', 2, N'111', 7, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1021, N'薯条', 2, N'111', 5, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1022, N'汉堡', 2, N'111', 8, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1023, N'可乐', 2, N'111', 9, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1024, N'雪顶咖啡', 2, N'111', 10, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1025, N'真果粒', 2, N'111', 5, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1026, N'雪碧', 2, N'111', 6, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1027, N'酸奶', 2, N'111', 1, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1028, N'饺子', 2, N'111', 2, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1029, N'咖喱', 2, N'111', 6, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1031, N'一心', 2, N'111', 5, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1032, N'一意', 2, N'111', 6, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1033, N'三星', 2, N'111', 7, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1034, N'二意', 2, N'111', 8, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1035, N'华为', 2, N'111', 4, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1036, N'小米', 2, N'111', 2, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1037, N'餐具', 2, N'111', 4, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1038, N'杯具', 2, N'111', 8, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1039, N'刀叉', 2, N'111', 10, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1040, N'万福', 2, N'111', 9, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1041, N'金安', 2, N'111', 10, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1042, N'早生', 2, N'111', 6, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1043, N'贵子', 2, N'111', 7, N'女  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1044, N'团团', 2, N'111', 8, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1045, N'圆圆', 2, N'111', 9, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1046, N'高高', 2, N'111', 5, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (1088, N'备兄', 2, N'111', 9, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (2002, N'沈大炮', 2, N'111', 1, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (2505, N'123', 2, N'111', 1, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (2536, N'撒旦法', 2, N'111', 1, N'男  ')
INSERT [dbo].[Emp] ([UserId], [UserName], [UserType], [UserPwd], [Deptno], [Gender]) VALUES (2555, N'阿斯蒂芬', 2, N'111', 1, N'男  ')
/****** Object:  Default [DF_OrderTable_CreateTime]    Script Date: 02/08/2018 18:48:29 ******/
ALTER TABLE [dbo].[OrderTable] ADD  CONSTRAINT [DF_OrderTable_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  ForeignKey [FK_EMP_REFERENCE_DEPTMENT]    Script Date: 02/08/2018 18:48:29 ******/
ALTER TABLE [dbo].[Emp]  WITH CHECK ADD  CONSTRAINT [FK_EMP_REFERENCE_DEPTMENT] FOREIGN KEY([Deptno])
REFERENCES [dbo].[Deptment] ([DeptNo])
GO
ALTER TABLE [dbo].[Emp] CHECK CONSTRAINT [FK_EMP_REFERENCE_DEPTMENT]
GO
/****** Object:  ForeignKey [FK_EMP_REFERENCE_USERTYPE]    Script Date: 02/08/2018 18:48:29 ******/
ALTER TABLE [dbo].[Emp]  WITH CHECK ADD  CONSTRAINT [FK_EMP_REFERENCE_USERTYPE] FOREIGN KEY([UserType])
REFERENCES [dbo].[UserType] ([Type])
GO
ALTER TABLE [dbo].[Emp] CHECK CONSTRAINT [FK_EMP_REFERENCE_USERTYPE]
GO
