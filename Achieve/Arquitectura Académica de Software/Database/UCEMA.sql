USE [master]
GO
/****** Object:  Database [UCEMA]    Script Date: 23/03/2023 11:28:35 a. m. ******/
CREATE DATABASE [UCEMA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Empresa', FILENAME = N'C:\Documents\AP6\Database\UCEMA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Empresa_log', FILENAME = N'C:\Documents\AP6\Database\UCEMA_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [UCEMA] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UCEMA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UCEMA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UCEMA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UCEMA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UCEMA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UCEMA] SET ARITHABORT OFF 
GO
ALTER DATABASE [UCEMA] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [UCEMA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UCEMA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UCEMA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UCEMA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UCEMA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UCEMA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UCEMA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UCEMA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UCEMA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UCEMA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UCEMA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UCEMA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UCEMA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UCEMA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UCEMA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UCEMA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UCEMA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UCEMA] SET  MULTI_USER 
GO
ALTER DATABASE [UCEMA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UCEMA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UCEMA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UCEMA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UCEMA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UCEMA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [UCEMA] SET QUERY_STORE = OFF
GO
USE [UCEMA]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 23/03/2023 11:28:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](25) NOT NULL,
	[FechaAlta] [date] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 23/03/2023 11:28:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefono](
	[TelefonoId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Numero] [nvarchar](15) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Telefono] PRIMARY KEY CLUSTERED 
(
	[TelefonoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (1, N'Gerardo Tordoya', CAST(N'2023-03-06' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (2, N'Elena Valdéz', CAST(N'2017-12-23' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (3, N'Rodolfo Tordoya', CAST(N'1943-06-26' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (4, N'Andrea Aparicio', CAST(N'2015-06-22' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (5, N'Ana Aramayo', CAST(N'2011-03-10' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (6, N'Azucena Barcelo', CAST(N'2016-01-10' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (7, N'Anahí Fadell', CAST(N'2017-06-17' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (8, N'Alfredo Franco', CAST(N'2016-01-22' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (9, N'Amelia Gutierrez', CAST(N'2010-12-28' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (10, N'Alfredo Mamani', CAST(N'2011-11-24' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (11, N'Augusto Scheurer', CAST(N'2013-11-20' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (12, N'Alfredo Severich', CAST(N'2013-09-22' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (13, N'Alvaro Tejeda', CAST(N'2016-01-09' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (14, N'Abigail Teran', CAST(N'2011-12-15' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (15, N'Blanca Marconiz', CAST(N'2020-02-06' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (16, N'Cristian Aisama', CAST(N'2010-02-13' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (17, N'Carolina Alderete', CAST(N'2014-11-20' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (18, N'Carmen Amador', CAST(N'2011-03-13' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (19, N'Cecilia Bianco', CAST(N'2019-03-27' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (20, N'Carlos Catacata', CAST(N'2015-11-16' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (21, N'Carlos Ferraro', CAST(N'2013-02-21' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (22, N'Carlos Franco', CAST(N'2014-02-24' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (23, N'Claudio Igarzabal', CAST(N'2016-03-05' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (24, N'Cesar Martinez', CAST(N'2017-06-22' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (25, N'Carmen Quispe', CAST(N'2012-06-03' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (26, N'Carlos Ramirez', CAST(N'2012-10-18' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (27, N'Cecilia Reque', CAST(N'2013-11-12' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (28, N'Carolina Segovia', CAST(N'2013-10-15' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (29, N'Dionicio Alvarez', CAST(N'2013-06-12' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (30, N'Dario Bonutto', CAST(N'2011-01-09' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (31, N'Dante Dominguez', CAST(N'2016-01-07' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (32, N'Daniel Echazu', CAST(N'2019-03-31' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (33, N'Diego Reimundin', CAST(N'2010-04-13' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (34, N'Diego Salas', CAST(N'2015-03-14' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (35, N'Diego Suarez', CAST(N'2018-05-29' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (36, N'Daiana Tejerina', CAST(N'2016-02-22' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (37, N'Elizabeth Alfaro', CAST(N'2012-10-16' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (38, N'Enrique Alzogaray', CAST(N'2011-06-25' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (39, N'Edgar Caballero', CAST(N'2020-08-17' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (40, N'Enrique Calisaya', CAST(N'2018-11-20' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (41, N'Erica Cari', CAST(N'2010-02-15' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (42, N'Edith Cruz', CAST(N'2011-12-26' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (43, N'Eduardo Ochoa', CAST(N'2012-11-11' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (44, N'Fabian Alvarez', CAST(N'2010-01-10' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (45, N'Fernando Chavez', CAST(N'2015-07-02' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (46, N'Francisco Corbacho', CAST(N'2014-08-21' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (47, N'Franco Girotti', CAST(N'2011-09-25' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (48, N'Francisco Palacios', CAST(N'2018-06-21' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (49, N'Gustavo Cajal', CAST(N'2019-02-24' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (50, N'German Fernandez', CAST(N'2019-04-23' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (51, N'Guillermo Saavedra', CAST(N'2019-09-02' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (52, N'Gustavo Toconas', CAST(N'2017-01-20' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (53, N'Gerardo Tordoya', CAST(N'2012-01-25' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (54, N'Gustavo Vedia', CAST(N'2015-06-18' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (55, N'Hugo Fernandez', CAST(N'2016-11-08' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (56, N'Hugo Krasnobroda', CAST(N'2014-03-09' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (57, N'Ignacio Igarzabal', CAST(N'2017-11-06' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (58, N'Ivana Juarez', CAST(N'2020-09-14' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (59, N'Julio Achaval', CAST(N'2020-07-07' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (60, N'Jorge Albarracin', CAST(N'2015-12-24' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (61, N'Jorge Ale', CAST(N'2010-09-03' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (62, N'Juan Fernandez', CAST(N'2010-10-22' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (63, N'Juliana Juarez', CAST(N'2014-05-22' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (64, N'Jacqueline Mendez', CAST(N'2014-09-11' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (65, N'Jorge Mir', CAST(N'2014-12-06' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (66, N'Julio Richa', CAST(N'2019-03-14' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (67, N'Juan Rojas', CAST(N'2013-04-08' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (68, N'Juan Saenz', CAST(N'2014-12-02' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (69, N'Laura Ballatore', CAST(N'2019-10-20' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (70, N'Luis Caraballo', CAST(N'2020-11-23' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (71, N'Lucas Delgado', CAST(N'2012-12-11' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (72, N'Luis Herrera', CAST(N'2011-04-22' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (73, N'Luis Lamas', CAST(N'2012-11-02' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (74, N'Liliana Madrid', CAST(N'2018-04-05' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (75, N'Luis Manzara', CAST(N'2010-03-24' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (76, N'Laura Perea', CAST(N'2019-10-01' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (77, N'Luis Sanchez', CAST(N'2014-12-01' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (78, N'Lidia Sueldo', CAST(N'2020-06-08' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (79, N'Luis Tolaba', CAST(N'2013-04-27' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (80, N'Maria Alvarez', CAST(N'2014-04-20' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (81, N'Maria Balzarini', CAST(N'2012-07-03' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (82, N'Marcelo Betinotti', CAST(N'2015-11-11' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (83, N'Manuel Caballero', CAST(N'2019-05-14' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (84, N'Mayra Cardozo', CAST(N'2010-08-31' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (85, N'Maria Cid', CAST(N'2017-10-13' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (86, N'Maria Duran', CAST(N'2017-02-14' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (87, N'Maria Galian', CAST(N'2012-09-10' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (88, N'María Garzon', CAST(N'2010-10-10' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (89, N'Maria Halle', CAST(N'2014-09-24' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (90, N'Maria Haquim', CAST(N'2018-10-15' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (91, N'Mariana Mamani', CAST(N'2018-10-15' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (92, N'Maria Mariscal', CAST(N'2018-07-18' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (93, N'Miguel Montenegro', CAST(N'2017-01-11' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (94, N'Maria Montero', CAST(N'2018-02-03' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (95, N'Marcela Navas', CAST(N'2012-10-19' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (96, N'Mauricio Prinzo', CAST(N'2013-09-04' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (97, N'Mauro Rodriguez', CAST(N'2011-08-22' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (98, N'Mario Sagredo', CAST(N'2013-11-25' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (99, N'Miguel Salazar', CAST(N'2012-07-22' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (100, N'Norma Batallanos', CAST(N'2020-08-23' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (101, N'Napoleon Diaz', CAST(N'2018-09-29' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (102, N'Nestor Paredes', CAST(N'2019-02-14' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (103, N'Nora Ruiz', CAST(N'2013-01-08' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (104, N'Natalia Taborda', CAST(N'2015-04-20' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (105, N'Oscar Aisama', CAST(N'2017-04-09' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (106, N'Oscar Dominguez', CAST(N'2010-09-05' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (107, N'Paula Alanoca', CAST(N'2020-05-30' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (108, N'Pablo Claros', CAST(N'2018-11-15' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (109, N'Patricia Genovese', CAST(N'2016-08-11' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (110, N'Paola Krogulec', CAST(N'2014-05-26' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (111, N'Patricia Subiaurre', CAST(N'2018-09-15' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (112, N'Pamela Tolaba', CAST(N'2012-03-14' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (113, N'Rodrigo Alvarez', CAST(N'2017-02-04' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (114, N'Roberto Amador', CAST(N'2020-07-26' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (115, N'Ricardo Balceda', CAST(N'2017-05-19' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (116, N'Ricardo Dubin', CAST(N'2016-07-25' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (117, N'Rosana Herrera', CAST(N'2019-02-23' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (118, N'Ruben Rivarola', CAST(N'2013-02-04' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (119, N'Rene Salas', CAST(N'2019-06-14' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (120, N'Ricardo Tezanos', CAST(N'2012-01-09' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (121, N'Rodolfo Tordoya', CAST(N'2019-12-19' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (122, N'Silvia Asurduy', CAST(N'2020-07-13' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (123, N'Sebastian Castro', CAST(N'2016-07-20' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (124, N'Silvana Copas', CAST(N'2013-04-07' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (125, N'Silvana Franco', CAST(N'2018-06-30' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (126, N'Silvio Guanuco', CAST(N'2012-07-30' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (127, N'Silvia Herrera', CAST(N'2015-12-10' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (128, N'Sonia Huanuco', CAST(N'2015-10-26' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (129, N'Sergio Mendez', CAST(N'2015-09-08' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (130, N'Silvia Quispe', CAST(N'2015-05-17' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (131, N'Sandra Torrico', CAST(N'2018-04-01' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (132, N'Sergio Velazquez', CAST(N'2015-09-10' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (133, N'Valeria Alfaro', CAST(N'2010-06-16' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (134, N'Victor Azize', CAST(N'2015-03-18' AS Date), 0)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (135, N'Valeria Gaya', CAST(N'2010-04-14' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombre], [FechaAlta], [Activo]) VALUES (136, N'Virginia Quinteros', CAST(N'2017-01-31' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Telefono] ON 
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (1, 126, N'769-474-6805', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (2, 4, N'783-747-1398', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (3, 106, N'920-974-3301', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (4, 84, N'208-600-4571', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (5, 34, N'134-862-6967', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (6, 107, N'399-178-9609', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (7, 124, N'321-477-4909', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (8, 66, N'115-207-3477', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (9, 25, N'275-624-1110', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (10, 21, N'596-120-8052', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (11, 85, N'195-684-8449', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (12, 57, N'472-724-1702', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (13, 43, N'107-942-1547', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (14, 102, N'823-982-3490', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (15, 81, N'820-858-6742', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (16, 122, N'161-356-6783', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (17, 106, N'596-863-9703', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (18, 32, N'284-831-5165', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (19, 122, N'671-291-1332', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (20, 23, N'922-342-6861', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (21, 60, N'117-577-5591', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (22, 9, N'515-962-4716', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (23, 45, N'615-948-3499', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (24, 70, N'995-574-3414', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (25, 85, N'202-993-9097', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (26, 34, N'303-701-5647', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (27, 104, N'923-964-4965', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (28, 73, N'471-484-6805', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (29, 48, N'452-525-5725', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (30, 37, N'658-252-7337', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (31, 66, N'613-961-1785', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (32, 132, N'624-878-4148', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (33, 60, N'754-564-2892', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (34, 19, N'728-673-6870', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (35, 106, N'304-670-7141', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (36, 23, N'590-343-3727', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (37, 88, N'873-687-3668', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (38, 35, N'303-137-2501', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (39, 123, N'115-784-5072', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (40, 116, N'589-706-5959', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (41, 49, N'451-103-7747', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (42, 98, N'410-242-3334', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (43, 19, N'213-396-0543', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (44, 27, N'444-986-1250', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (45, 109, N'149-873-9172', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (46, 62, N'785-485-8067', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (47, 106, N'923-261-9788', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (48, 79, N'832-585-4297', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (49, 79, N'401-947-5555', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (50, 117, N'670-191-8366', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (51, 100, N'739-547-6845', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (52, 70, N'244-303-7971', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (53, 118, N'579-491-4961', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (54, 17, N'705-448-7251', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (55, 76, N'320-312-0882', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (56, 76, N'480-605-3353', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (57, 31, N'478-776-5579', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (58, 47, N'840-313-2534', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (59, 60, N'912-497-3281', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (60, 92, N'861-736-2551', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (61, 29, N'598-792-1280', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (62, 87, N'982-941-8146', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (63, 23, N'327-827-9141', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (64, 26, N'542-532-6795', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (65, 50, N'207-512-8505', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (66, 55, N'377-343-9474', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (67, 70, N'547-564-6607', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (68, 113, N'324-554-9605', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (69, 63, N'415-219-0419', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (70, 61, N'592-321-6670', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (71, 72, N'112-701-8627', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (72, 95, N'711-650-6657', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (73, 132, N'486-582-4914', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (74, 69, N'226-288-1907', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (75, 113, N'575-504-0991', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (76, 102, N'460-541-9541', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (77, 89, N'688-243-8200', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (78, 52, N'493-967-6538', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (79, 49, N'131-144-0281', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (80, 18, N'511-255-1899', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (81, 7, N'864-662-3468', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (82, 42, N'305-145-1667', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (83, 74, N'777-911-5960', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (84, 3, N'202-659-1984', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (85, 58, N'236-426-4210', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (86, 126, N'552-262-5650', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (87, 73, N'707-599-9486', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (88, 73, N'145-542-4919', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (89, 24, N'173-372-4478', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (90, 25, N'866-428-2541', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (91, 129, N'407-904-3727', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (92, 3, N'814-260-7380', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (93, 74, N'872-644-2010', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (94, 108, N'493-651-1932', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (95, 44, N'659-748-9493', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (96, 122, N'474-652-1109', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (97, 105, N'390-197-8856', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (98, 96, N'518-376-6716', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (99, 58, N'459-163-1202', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (100, 33, N'969-697-8480', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (101, 84, N'446-232-8188', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (102, 101, N'272-328-9817', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (103, 13, N'862-741-5108', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (104, 80, N'553-609-9339', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (105, 43, N'664-276-5092', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (106, 9, N'422-494-2380', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (107, 97, N'530-324-8802', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (108, 65, N'615-884-6886', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (109, 79, N'434-730-7513', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (110, 53, N'440-569-3655', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (111, 40, N'221-915-0444', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (112, 90, N'518-347-3668', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (113, 30, N'695-340-4176', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (114, 46, N'594-910-6934', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (115, 89, N'318-623-9421', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (116, 61, N'479-530-7346', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (117, 37, N'792-316-8197', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (118, 59, N'460-944-4417', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (119, 3, N'629-412-1577', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (120, 29, N'797-833-7481', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (121, 104, N'224-168-2520', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (122, 20, N'515-895-2448', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (123, 93, N'632-586-6226', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (124, 54, N'889-751-1352', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (125, 22, N'278-463-3206', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (126, 76, N'943-937-4785', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (127, 119, N'721-174-7843', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (128, 108, N'401-654-0766', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (129, 13, N'310-188-3775', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (130, 128, N'160-540-9542', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (131, 58, N'563-561-4288', 0)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (132, 14, N'654-787-2148', 1)
GO
INSERT [dbo].[Telefono] ([TelefonoId], [ClienteId], [Numero], [Activo]) VALUES (133, 39, N'824-867-2896', 1)
GO
SET IDENTITY_INSERT [dbo].[Telefono] OFF
GO
ALTER TABLE [dbo].[Telefono]  WITH CHECK ADD  CONSTRAINT [FK_Telefono_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Telefono] CHECK CONSTRAINT [FK_Telefono_Cliente]
GO
USE [master]
GO
ALTER DATABASE [UCEMA] SET  READ_WRITE 
GO
