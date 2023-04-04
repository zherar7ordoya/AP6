USE [master]
GO
/****** Object:  Database [MMABooks]    Script Date: 23/03/2023 10:21:53 a. m. ******/
CREATE DATABASE [MMABooks]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MMABooks', FILENAME = N'C:\Documents\AP6\Database\MMABooks.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MMABooks_log', FILENAME = N'C:\Documents\AP6\Database\MMABooks_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MMABooks] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MMABooks].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MMABooks] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MMABooks] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MMABooks] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MMABooks] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MMABooks] SET ARITHABORT OFF 
GO
ALTER DATABASE [MMABooks] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MMABooks] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MMABooks] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MMABooks] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MMABooks] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MMABooks] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MMABooks] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MMABooks] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MMABooks] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MMABooks] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MMABooks] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MMABooks] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MMABooks] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MMABooks] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MMABooks] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MMABooks] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MMABooks] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MMABooks] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MMABooks] SET  MULTI_USER 
GO
ALTER DATABASE [MMABooks] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MMABooks] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MMABooks] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MMABooks] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MMABooks] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MMABooks] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MMABooks] SET QUERY_STORE = OFF
GO
USE [MMABooks]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 23/03/2023 10:21:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[City] [varchar](20) NOT NULL,
	[State] [char](2) NOT NULL,
	[ZipCode] [char](15) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceLineItems]    Script Date: 23/03/2023 10:21:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceLineItems](
	[InvoiceID] [int] NOT NULL,
	[ProductCode] [char](10) NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ItemTotal] [money] NOT NULL,
 CONSTRAINT [PK_InvoiceLineItems] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC,
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 23/03/2023 10:21:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[ProductTotal] [money] NOT NULL,
	[SalesTax] [money] NOT NULL,
	[Shipping] [money] NOT NULL,
	[InvoiceTotal] [money] NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderOptions]    Script Date: 23/03/2023 10:21:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderOptions](
	[OptionID] [int] IDENTITY(1,1) NOT NULL,
	[SalesTaxRate] [decimal](18, 4) NOT NULL,
	[FirstBookShipCharge] [money] NOT NULL,
	[AdditionalBookShipCharge] [money] NOT NULL,
 CONSTRAINT [PK_OrderOptions] PRIMARY KEY CLUSTERED 
(
	[OptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 23/03/2023 10:21:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductCode] [char](10) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[OnHandQuantity] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 23/03/2023 10:21:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[StateCode] [char](2) NOT NULL,
	[StateName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[StateCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (1, N'Molunguri, A', N'1108 Johanna Bay Drive', N'Birmingham', N'AL', N'35216-6909     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (2, N'Muhinyi, Mauda', N'1420 North Charles Street', N'New York', N'NY', N'10044          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (3, N'Antony, Abdul', N'1109 Powderhorn Drive', N'Fayetteville', N'NC', N'28314          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (4, N'Smith, Ahmad', N'2509 South Crescent', N'Savanna', N'IL', N'61074          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (5, N'Chen, Rabi', N'2273 N. Essex Ln', N'Murfreesboro', N'TN', N'37130          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (6, N'Nuckols, Heather', N'150 Hayes St', N'Elgin', N'IL', N'60120          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (7, N'Lutonsky, Christopher', N'293 Old Holcomb Bridge Way', N'Woodland Hills', N'CA', N'91365          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (8, N'Reddy, Aj', N'P.O. Box 9802', N'Plano', N'TX', N'75025-0587     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (9, N'Rascano, Darrell', N'16 Remington Dr. E', N'Rancho Cordova', N'CA', N'95760          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (10, N'Johnson, Ajith', N'2200 Old Germantown Road', N'McGregor', N'CA', N'55555          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (11, N'Patwardhan, John', N'100 South Main St', N'Bethel Park', N'PA', N'15102          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (12, N'Swenson, Vin', N'102 Forest Drive', N'Albany', N'OR', N'97321          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (13, N'Nichols, Nadine', N'7403 Twin Brooks Blvd', N'Rogers', N'AR', N'72756          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (14, N'Guthrie, Rawle', N'3011 Belden Street', N'Phoenix', N'AZ', N'85023          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (15, N'Nguyen, Allison', N'4100 Coca-Cola Plaza', N'Memphis', N'TN', N'38118          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (16, N'Kandregula, Howard', N'534 Radar Road', N'Oklahoma City', N'OK', N'73132          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (17, N'Yudkevich, Ed', N'1701 E. 12Th Street', N'Olathe', N'KS', N'66062          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (18, N'Jii, N', N'1678 Plateau Dr', N'Dracut', N'MA', N'01826          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (19, N'Schreiber, Nick', N'1815 E. Newberry St', N'Lawrenceville', N'NJ', N'08648          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (20, N'Chamberland, Sarah', N'1942 S. Gaydon Avenue', N'Doraville', N'CA', N'30340          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (21, N'Goldman, Don', N'Po Box 645910', N'Newark', N'NJ', N'07103          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (22, N'Rivas, Brent', N'18242 S. 65Th Ave.', N'Duncanville', N'TX', N'75137          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (23, N'Newlin, Sherman', N'2400 Bel Air, Apt.345', N'Broomfield', N'CO', N'80020          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (24, N'Chavez, Gregory', N'6472 Mll Ct', N'Frederick', N'MD', N'21703          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (25, N'De la fuente, Cathy', N'2213 Abbotsford Dr', N'Dalton', N'GA', N'30720          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (26, N'Lin, Terri', N'280 Briarcliff Rd', N'Springfield', N'IL', N'62702          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (27, N'Mercado, Vincent', N'637 Fulton Rd,  71', N'Boise', N'ID', N'83704          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (28, N'Thornton, Sreedhar', N'2542 N  Mozart', N'Brooklyn', N'NY', N'11229          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (29, N'Johnson, Pradeep', N'P.O. Box 81171', N'Ws', N'RI', N'02890          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (30, N'Leach, Venkat', N'12033 Foundation Place', N'Rowland Hts', N'CA', N'91748          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (31, N'Muru, Eric', N'300 Sixth Avenue', N'Henderson', N'NV', N'89052          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (32, N'Slabicki, Liuy', N'1979 Marcus Ave.', N'Westwood', N'NJ', N'07675          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (33, N'Lair, Andrew', N'28 Marblestone Lane', N'San Francisco', N'CA', N'94122          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (34, N'Johnson, Waylon', N'440 Richmond Park East', N'Hamden', N'CT', N'06517-2703     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (35, N'Morgan, Robert', N'48289 Fremont Blvd', N'Carrollton', N'TX', N'75006          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (36, N'Annamanaidu, Christian', N'213 N. College Dr.', N'Omaha', N'NE', N'68127          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (38, N'Beier, Aneta', N'8204 Anderson Road', N'Temple', N'TX', N'76504          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (39, N'Fernandes, Philip', N'136 Gales Drive', N'Richmond Hts', N'OH', N'44143          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (40, N'Roby, Chris', N'182 Greylock Parkway', N'Sacto', N'CA', N'95814          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (41, N'Kumari, Gopinath', N'35 Manor Dr. Apt# 5-O', N'Queens Village', N'NY', N'11428          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (42, N'Pardo, Harriet', N'141 Summit Street', N'Waldorf', N'MN', N'56091          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (43, N'Haldorai, Brent', N'1427 Valley', N'Huntsville', N'AL', N'35806          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (44, N'Miller, Jeremy', N'625 Woodsmoke', N'Plano', N'TX', N'75023          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (45, N'Jain, Phyllis', N'75 Lexington Court', N'Austin', N'MN', N'55912          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (46, N'Nataraj, Randy', N'1409 Coliseum Blvd', N'Wesley Chapel', N'FL', N'33544          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (47, N'Sellers, Timothy', N'13700 Sutton Park Dr N -- #322', N'Dallas', N'TX', N'75287          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (48, N'Allen, Deanna', N'766 Willow Ridge Dr', N'Demotte', N'IN', N'46310          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (49, N'Huebner, Walter', N'100 Peachtree St.', N'Jacksonville', N'FL', N'32217          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (50, N'Hutcheson, Larry', N'2902 Cannons Lane', N'Coffeyville', N'KS', N'67337          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (51, N'Green, Eduardo', N'1240 E. Diehl Road', N'Columbia', N'SC', N'29209          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (52, N'Azure, Mike', N'304 Combs', N'Mendon', N'NY', N'14606          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (53, N'Dardac, Donald', N'4232 Judah', N'Irving', N'TX', N'75038          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (54, N'Deguzman, Jose', N'4168 Woodland Road', N'Brooklyn', N'NY', N'11226          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (55, N'Wolff, Jonathan', N'7921 Lamar', N'Ann Arbor', N'MI', N'48108          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (56, N'Johnson, Mark', N'1538 Harmon Cove Tower', N'Greenville', N'NC', N'27889          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (57, N'Leach, Alan', N'147 Bear Creek Pike', N'Dallas', N'TX', N'75218-3995     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (58, N'Marlatt, Robert', N'P.P. Box 139', N'Yorktown Heights', N'NY', N'10598          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (59, N'Perlman, Lk', N'505 Ellis Blvd', N'Philadelphia', N'PA', N'19122-6083     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (60, N'Brown, Scott', N'919, 137Th Avenue Ne', N'Kansas City', N'KS', N'66102          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (61, N'Stein, George', N'95 Carleton St', N'New Milford', N'NJ', N'07646          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (62, N'Petway, Robert', N'303 3Rd Ave Se', N'Jacksonville', N'FL', N'32224          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (63, N'Robinson, Timothy', N'3075 Highland Parkway', N'Westland', N'MI', N'48185          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (64, N'Goodwin, Mark', N'6639 Capitol Blvd', N'Montgomery', N'AL', N'36130          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (65, N'Mallipeddi, Rick', N'1876 Woodhollow Dr', N'Milpitas', N'CA', N'95035          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (66, N'Buford, Bry', N'540 W North West Highway', N'New York', N'NY', N'10005          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (67, N'Fritz, Mark', N'16 Erie', N'Hosuton', N'TX', N'77077          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (68, N'Hamilton, Karen', N'18 Marvin Dr., Apt#B-5', N'Cincinnati', N'OH', N'45263          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (69, N'Ybarra, George', N'6 Oneill Ct', N'Detroit', N'MI', N'48206-1775     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (70, N'Varghese, Joanne', N'7178 Talhelm Road', N'Fort Wayne', N'IN', N'46805-1499     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (71, N'Santos, Anita', N'1640 Barrington Lane', N'Barrington', N'IL', N'60448          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (72, N'Kieffer, Jing peng', N'1492 Highland Lakes Trail', N'Ringgold', N'GA', N'30736          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (73, N'Seaver, Glenda', N'23 Holohan Drive', N'Mountlake Terrace', N'WA', N'98043          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (74, N'Knox, Lakshman', N'9074 Estes St', N'Austin', N'TX', N'78759          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (75, N'Wigton, Alex', N'5033 Montego Bay Dr', N'Brooklyn', N'NY', N'11245          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (76, N'Ryan, Jagriti', N'115 Audubon Cove', N'Kingsport', N'TN', N'37663          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (77, N'Latheef, Andrea c.', N'17 Potter Road', N'Jacksonville', N'FL', N'32256          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (78, N'Konow, Andrew', N'25677 Wistereia Ct', N'Greenville', N'SC', N'29607          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (79, N'Chang, Simon', N'8317 Cabin Creek Drive', N'Oshkosh', N'WI', N'54901          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (80, N'Garcia, Chong', N'28000 Dequindre', N'Fairfax', N'VA', N'22033          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (81, N'Schlusselberg, Brandon', N'303 South Second St.', N'Collinsville', N'IL', N'62234-2973     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (82, N'Boan, Dinesh', N'11582 Rusk Cove', N'Charlotte', N'NC', N'28270          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (83, N'Dalton, Tai-yen', N'115 Tower Drive', N'Round Rock', N'TX', N'78681          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (84, N'Wieneke, Frank', N'2111 Bancroft Way', N'Birmingham', N'AL', N'35226          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (85, N'Trujillo, Thell', N'1204 Keller Lane', N'Fairfield', N'IA', N'52556          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (86, N'Ritz, Joe', N'7404 Lomo Alto', N'Plano', N'TX', N'75024          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (87, N'Chen, Becky', N'2605 Hawthorne Ave', N'Southgate', N'MI', N'48195          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (88, N'Monse, Charles', N'5933 6Th Street', N'Somersert', N'NJ', N'08873          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (89, N'Boswell, Joseph', N'3131 E. Holcombe Blvd', N'Shelton', N'CT', N'06484          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (90, N'Johnson, Stewart', N'410 Victory Garden Dr. Apt. 36', N'San Diego', N'CA', N'92111          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (91, N'Cummings, Usha', N'12033 Foundation Place', N'Greenville', N'TX', N'75401          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (92, N'Aguimba, Edward', N'444 Propsect St', N'Streamwood', N'IL', N'60107          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (93, N'Lacey, Kimberly', N'3450 W. Country Club Dr', N'Macomb', N'MI', N'48044          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (94, N'Vega, Bharat', N'3003 N. First St. Ste309', N'Little Elm', N'TX', N'75068          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (95, N'Cheboli, Walter', N'4260 Nw 32 Street', N'Mankato', N'MN', N'56002          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (96, N'Bawa, Jerry', N'315 Newport Lane', N'Rockville', N'MD', N'20850          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (97, N'Yciano, Nicolette', N'1295 State Street', N'Gettysburg', N'PA', N'17325          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (98, N'Duvall, Billy', N'Box 123', N'Fremont', N'CA', N'94536          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (99, N'Trasente, Lucy', N'51783 Se 7Th Street', N'Westerville', N'OH', N'43081          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (100, N'Hodgkins, Giridhar', N'814 East Ivy Street', N'Nyc', N'NY', N'110324         ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (101, N'Goldberg, Seth', N'4647 Stone Avenue', N'Huntsville', N'TX', N'77320          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (102, N'Hernandez, Esta', N'4000 So. 35Th', N'Hagerstown', N'MD', N'21742          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (103, N'Trent, Janet', N'13101 Columbia Pike', N'San Francisco', N'CA', N'94122          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (104, N'Wheatley, Sathyanarayana', N'2226 Spring Dusk Lane', N'Bloomingdale', N'NJ', N'07403          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (105, N'Williams, Eugene', N'805D Columbia St.', N'Flushing', N'NY', N'11355          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (106, N'Smisko, Steven', N'104 Cinnamon Teal Court', N'Warren', N'MI', N'48089          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (107, N'Travis, Jeff', N'3111 Monument Drive', N'Milwaukee', N'WI', N'53218          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (108, N'Broadhurst, Vito', N'300 30Th Ave. N. Apt. 4C', N'Fennimore', N'WI', N'53809          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (109, N'Chansa, Tom', N'123 Sfsdfsdfsdf', N'Sacramento', N'CA', N'95820-4617     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (110, N'Sanjay, Ian', N'517 So. Main Street', N'Gainesville', N'FL', N'32301          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (111, N'Perkins, Wm', N'900 Old Country Rd', N'Grand Prairie', N'TX', N'75052          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (112, N'Paramasivan, Nancy', N'923 Fuchsia Ave', N'Alamo', N'CA', N'94507          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (113, N'Kohli, Carl', N'51 Mercedes Way', N'Hollister', N'CA', N'95023          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (114, N'Nuytten, Kim', N'8908 So 121St', N'Chattanooga', N'TN', N'37404          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (115, N'Gagne, John', N'2156 Glencoe Hills Drive.# 6', N'Sumter', N'SC', N'29154          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (116, N'Sun, Edgar', N'39 Howell Place', N'Parsippany', N'NJ', N'07054          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (117, N'Bounds, Kirk', N'1818 South 43Rd Street', N'Collinsville', N'IL', N'62234          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (118, N'Palanukumarasamy, Dianna', N'1521 W Wolfram', N'Columbia', N'SC', N'29223          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (119, N'Donahoe, Greg', N'P. O. Box 2600', N'St. Paul', N'MN', N'55101          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (120, N'Bucella, Alex', N'3451 Fairway Commons Dr', N'Colorado Springs', N'CO', N'80907          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (121, N'Demith, Bob', N'20 Carlsbad Rd.', N'New York', N'NY', N'10007          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (122, N'Giraka, Eric', N'115 Williams St Se', N'Seatle', N'WA', N'98036          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (123, N'Jackson, Bill', N'25-3 Latham Villiage Lane', N'Parma', N'OH', N'44134          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (124, N'Bruch, Cameron', N'10925 South Bryant', N'Addison', N'TX', N'75001          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (125, N'Chism, Leslie', N'123 Main St', N'Roy', N'UT', N'84067          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (126, N'Beemer, Steve', N'1234 Main St', N'Watertown', N'CT', N'06795          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (127, N'Garcia, Dhananjay', N'9211 Garland', N'Columbus', N'OH', N'43216          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (128, N'Susai, Jo', N'42524 Parkhurst Rd.', N'Mansfield', N'MA', N'02048          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (129, N'Pot, Jonathan', N'14647 S. Peppermill Ct.', N'Madison', N'NJ', N'07940          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (130, N'fedor, sr., Christy', N'Beltline Road', N'Austin', N'TX', N'78745          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (131, N'Wazny, Tina', N'1025 Cadillac Way', N'Birmingham', N'AL', N'35242          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (132, N'Daniel, Jody', N'1 Enterprise Dr', N'Phoenix', N'AZ', N'85032          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (133, N'Binner, Ellis', N'6855 Woodland Ave', N'New Milford', N'CT', N'06776          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (134, N'Rasmussen, Dan', N'1066 Hidden Lake Dr', N'Meriden', N'CT', N'06450          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (135, N'Robinson, Clemente', N'Sis, 550 Banway Building', N'Downers Grove', N'IL', N'60515          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (136, N'Bennett, Gonza', N'2707 Villagerive', N'Baltimore', N'MD', N'21229          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (137, N'Lavallee, Lawrence', N'2634 Timberbrooke Way', N'San Juan', N'PR', N'00936          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (138, N'Harris, Peter', N'3001 S. Congress', N'Indianapolis', N'IN', N'46237          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (139, N'Shukla, Ann', N'20743 Chappell Knoll Dr', N'Appleton', N'WI', N'54913          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (140, N'Look, Christina', N'2014 Widener Place', N'Amarillo', N'TX', N'79102          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (141, N'Seale, Brent', N'1421 Champion Drive Suite 101', N'Carlstadt', N'NJ', N'07072          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (142, N'Tuttle, Richard', N'2829 Bennett Ave', N'East Northport', N'NY', N'11731          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (143, N'Hardin, Bruce', N'669 Woodspring Drive', N'Arlington Hts', N'IL', N'60005          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (144, N'Erpenbach, Lee', N'901 Mission Street', N'Grants Pass', N'OR', N'97526          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (145, N'Tonner, Zheng', N'57 N Plaza Blvd', N'Atlanta', N'GA', N'30339-4024     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (146, N'Wilbon, Albert', N'6035 Parkland', N'Kansas City', N'MO', N'64141          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (147, N'Horner, Henry', N'1206 Applegate Prkwy', N'Indianapolis', N'IN', N'46250          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (148, N'Buckley, Robert', N'26280 Bonnie', N'San Gabriel', N'CA', N'91776-3916     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (149, N'Benedicto, Robert', N'4140 Alpha Road', N'Columbia', N'SC', N'29223          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (150, N'Corbett, Jayagangadhara', N'13050 Dahlia Circle,  122', N'Sherwood', N'AK', N'72120          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (151, N'Bommana, Ilya', N'1310 Brook St #2A', N'San Rafael', N'CA', N'94903          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (152, N'Rimes, George', N'977 N. Rustic Circle', N'Copperas Cove', N'TX', N'76522          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (153, N'Aneshansley, Baskaran', N'6720 Upper York Road', N'Ramona', N'CA', N'92065          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (154, N'Battu, Jeffrey', N'458 Mehaffey Drive', N'Succasunna', N'NJ', N'07876          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (155, N'Brock, David', N'651 Brookfield Pkwy', N'Farmington Hills', N'MI', N'48864          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (156, N'Mogesa, Mohamed', N'9939, Fredericksburg Rd, Apt', N'Overland Park', N'KS', N'66212          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (157, N'Abeyatunge, Derek', N'1414 S. Dairy Ashford', N'North Chili', N'NY', N'14514          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (158, N'Shaffer, Jack', N'1371 Longford Circle', N'Tampa', N'FL', N'33634          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (159, N'Berger, Anil', N'3968 Holly Dr.', N'Edison', N'NJ', N'08830          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (160, N'Desormeaux, Ram', N'1219 Redcliffe Road', N'Sunnyvale', N'CA', N'94087          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (161, N'Smith, Mark', N'89-41 210Th Pl', N'Okc', N'OK', N'73117          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (162, N'Meseguer, Alan', N'311 Sinclair Frontage Rd', N'Houston', N'TX', N'77047          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (163, N'Alexander, Skip', N'15 Gettysburg Square  187', N'West Hartford', N'CT', N'06107          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (164, N'Louie, Guy', N'1601 Schlumberger Dr', N'Baltimore', N'MD', N'21228          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (165, N'Ambati, Greg', N'1605 Candletree Dr. Suite 114', N'Landover', N'MD', N'20785          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (166, N'Perkins, Kosalai', N'1350 Davenport Mill Rd', N'Orlando', N'FL', N'55555          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (167, N'Maksymczak, Timothy', N'8425 Dolfor Cove', N'St Louis', N'MO', N'63138          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (168, N'Billingsley, Carlos', N'123 Sw 32Nd St', N'San Juan Capistrano', N'CA', N'92675          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (169, N'Henry, Benjamin', N'9203 Ivanhoe Road', N'Phoenix', N'AZ', N'85016          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (170, N'Srinivas, Nicholas', N'4792, Apt A, Weybridge Road', N'Hendersonville', N'TN', N'37075          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (171, N'Ashley, Karla', N'108 Randolph Avenue', N'Sunrise', N'FL', N'33351          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (172, N'Arutla, Jerry l.', N'209 Ne 6Th', N'Ontario', N'CA', N'91762          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (173, N'Kiss, Michelle', N'201 Rockview Drive', N'Baton Rouge', N'LA', N'70898          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (174, N'Wipfli, Jenny', N'5502 Elk Hollow Ct', N'Mcfarland', N'WI', N'53558          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (175, N'Perkins, Randy', N'500 Franklin Trpk', N'Bellevue', N'NE', N'68005          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (176, N'Lee, Bruce', N'2388 Springdale Rd., Sw', N'Powder Springs', N'GA', N'30127          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (177, N'Briggs, Greiner', N'10011 Strathfield Ln', N'Vestavia', N'AL', N'35216          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (178, N'Dinan, Kelly', N'875 Taylor Road', N'Bayside', N'NY', N'11361          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (179, N'Molfese, Alexander', N'34 Knox Lane', N'Los Angeles', N'CA', N'90068          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (180, N'Johnson, Neelam', N'37220, Eisen Hoover Ct', N'Addison', N'TX', N'75001          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (181, N'Maberry, Paul', N'1525 Buchanan St., Nw', N'Apex', N'NC', N'27502          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (182, N'Wolfe, Randy', N'3799 Route 46 East', N'Columbus', N'GA', N'31904          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (183, N'Hoffman, Kevin', N'5375 Mariners Cove Drive', N'Everett', N'MA', N'02149          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (184, N'Rogers, Pete', N'906 233Rd Pl Ne', N'Erie', N'PA', N'16505          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (185, N'Arzuza, Alioune', N'113 Railroad Ave.', N'Dallas', N'TX', N'75252          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (186, N'Williams, Greg', N'5400 Gingercovedr', N'Spring Valley', N'NY', N'10977          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (187, N'Holston, B', N'1157 Hampton Way Ne', N'Rancho Cordova', N'CA', N'95670          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (188, N'Sundaram, Kelly', N'4905 Dunckel', N'Oregon', N'WA', N'98121          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (189, N'Karri, Lisa', N'22 Winding Way', N'Phoenix', N'AZ', N'85016          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (190, N'Yarbro, John', N'2320 Mountain Oaks Lane', N'Dayton', N'OH', N'45415          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (191, N'Shah, Dave', N'1251 42Nd St. 4Th Floor', N'Fayetteville', N'AR', N'72701          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (192, N'Piper, Alan', N'341 Carlton Road', N'Blue Bell', N'PA', N'19422          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (193, N'Paramasivam, Greg', N'1013 N. Franklin St', N'Burnsville', N'MN', N'55306          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (194, N'Wallace, Stephen', N'63 N. Victor Ave.', N'Tallahassee', N'FL', N'32399-0450     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (195, N'Zimmer, Jian', N'4633 Tarsall Ct', N'Cinnaminson', N'NJ', N'08077-2308     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (196, N'Barksdale, Karen', N'214 Main St  249', N'Houston', N'TX', N'77021          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (197, N'Bilodeau, Kenendy', N'One Sbc Center', N'Edison', N'NJ', N'08817          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (198, N'Gilliam, James', N'1910 Patricia', N'Matteson', N'IL', N'60443          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (199, N'Abueg, Don', N'901 N. Lake Destiny', N'Montvale', N'NJ', N'07645          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (200, N'Taliaferro, Eric', N'2101 E Coliseum Blvd', N'Westmont', N'IL', N'60559          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (201, N'Hull, Tom', N'301 W. Bay St.', N'Natick', N'MA', N'01760          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (202, N'Beleford, Njansi', N'2136 E Main St', N'Collinsville', N'IL', N'62234          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (203, N'Kanapilly, Bill', N'443 Eldridge Rd', N'Norcross', N'GA', N'30096          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (204, N'Smith, Chris', N'14254 W Center Dr', N'Levittown', N'PA', N'19055          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (205, N'Blasy, Howard', N'10 Blue Ravine', N'Plano', N'TX', N'75074          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (206, N'Szara, Ellen', N'714 P Street', N'Jacksonville', N'FL', N'32202          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (207, N'Montenegro, M.e', N'722 N. Broadway', N'Oakland', N'CA', N'94612          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (208, N'Cullity, Yolanda', N'312 S. Combs', N'Norwood', N'MA', N'02062          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (209, N'Gamba, Jeffrey', N'726 Brender Lane', N'Hermitage', N'TN', N'37076          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (210, N'Salazar, Sidney', N'5845 S. 2325 W.', N'St Louis', N'MO', N'63129          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (211, N'Wheeler, Caroline', N'185 Whiting Lane', N'Madison', N'WI', N'53704          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (212, N'Beck, Mike', N'5316 Easthorpe Drive', N'Nutley', N'NJ', N'07109          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (213, N'Browning, Albert', N'1  E. Telecom Parkway', N'Duluth', N'GA', N'30097          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (214, N'Uchendu, Jim', N'4905 Maffitt Place', N'Ba', N'OK', N'74011          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (215, N'Robersone, Sumanta', N'206 Mc Lain Rd.', N'Atlanta', N'GA', N'30313          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (216, N'Brown, Bob', N'100 Schooner Way', N'Bedford', N'OH', N'44146          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (217, N'Boos, James', N'7647 Ellington Place', N'Holmdel', N'NY', N'07733          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (218, N'Cooke, Arpan', N'9834 Morgan Meadows Cove', N'Brooklyn', N'NY', N'11236          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (219, N'Morisset, Chou', N'14120 Twisting Lane', N'West Palm', N'FL', N'32106          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (220, N'Carroll, Steven', N'560 Main Street   416', N'Rogers', N'AR', N'72756          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (221, N'Lawrence, Nunzio', N'87 Cannon Ridge Drive', N'Woodside', N'NY', N'11377          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (222, N'Suyam, Steve', N'1486 Neil Ave', N'Gilbert', N'AZ', N'85040          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (223, N'Romano, B.j.', N'47715 Freedom Valley', N'Boston', N'MA', N'02116          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (224, N'Daniels, John', N'1417 Deer Spring Court', N'Fairfax', N'VA', N'22031          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (225, N'Milke, Paul', N'Po Box 846', N'Raleigh', N'NC', N'27604          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (226, N'Rocca, Cary', N'8619 W. Summerdale  1', N'Oakland', N'CA', N'94612          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (227, N'Hassan, Robert', N'1221 Idaho St', N'Altoona', N'PA', N'16602          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (228, N'Sadras, Terry', N'43-70, Kissena Blvd.,', N'Belleville', N'IL', N'62223          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (229, N'Rivera, Pramod', N'2203 , Good Shepherd Way', N'Solon', N'OH', N'44139          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (230, N'Walters, Tim', N'9315 Avenue A', N'Akron', N'OH', N'44313          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (231, N'Lee, Andra', N'8831 Park Central Drive', N'Beacon', N'NY', N'12508          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (232, N'Murphy, Dean', N'105 White Lane', N'Phoenix', N'AZ', N'85032          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (233, N'Kittendorf, Joe', N'6430 95th Avenue', N'Naperville', N'IL', N'60623          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (234, N'Liao, Stuart', N'4070 Fisher Road', N'Charlotte', N'NC', N'28215          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (235, N'Tabor, Michael', N'105 Shelley Avenue', N'Beaverton', N'OR', N'97007          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (236, N'Burt, Myron', N'3201 Clayton Road', N'Huntington', N'AR', N'72940          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (237, N'Erikson, David', N'805-D Columbia St', N'Concord', N'NH', N'03301          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (238, N'Rathmann, Mark', N'4107C Carrollton Ct', N'Rancho Cordova', N'CA', N'95670-4502     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (239, N'Anderson, Jeff', N'3625 Duval Rd #223', N'Houston', N'TX', N'77045          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (240, N'Nguyen, Eddie', N'205A E Main St', N'Houston', N'TX', N'77013          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (241, N'Diop, John', N'6318 Towncrest Court', N'South Pasadena', N'CA', N'91030          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (242, N'Hemmer, Deepanjan', N'2020 Oldfields Circle S Dr', N'Dallas', N'TX', N'75208          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (243, N'Gajjela, Jim', N'1001 Avenue Of The Americas', N'Nelsonville', N'OH', N'45764          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (244, N'Gigante, Kathy', N'P O Box 25009', N'Poughkeepsie', N'NY', N'12601          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (245, N'Walker, Walter', N'2415 First Avenue', N'New York', N'NY', N'10018          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (246, N'Viswanathan, Howard', N'37890 Westwood Cir. Apt 205', N'Hindsboro', N'IL', N'61930          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (247, N'Chu, Darren', N'9  Campus Dr.', N'Horsham', N'PA', N'19044          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (248, N'Zmaczynski, Mike', N'3907 78Th Drive E', N'Schaumburg', N'IL', N'60195          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (249, N'Bradley, Raj', N'1115 Huntington Dr.  B', N'Aliquippa', N'PA', N'15001          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (250, N'Drake, Doug', N'846 President St', N'Linden', N'NJ', N'07036          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (251, N'Peng, Roger', N'6201 W Olive Ave', N'Baton Rouge', N'LA', N'70815          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (252, N'Balliet, Steve', N'1 New York Plaza', N'Santa Ana', N'CA', N'92703          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (253, N'Bertone, Robert', N'4627 Blanche Road  #168', N'Austin', N'TX', N'78759          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (254, N'Harding, Shawn', N'3480 W 135Th St', N'Novato', N'CA', N'94947          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (255, N'Boyle, Teresa', N'225 Mt Vernon Dr', N'Cerritos', N'CA', N'90703          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (256, N'Mahodaya, Test', N'351 Crossing Blvd', N'Anywhere', N'CA', N'90210          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (257, N'Koch, Robert', N'222South Riverside Plaza', N'Decatur', N'GA', N'30034          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (258, N'Curless, Darald', N'P.O. Box 866642', N'West Hills', N'CA', N'91304          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (259, N'Rusoff, David', N'3305, Society Drv', N'Lincoln', N'NE', N'68506-4807     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (260, N'Hester, Maurice', N'2576 Sheppard Road', N'Kennewickm', N'WA', N'99336m         ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (261, N'Herbert, Richard', N'542, Maple Dr', N'Charlotte', N'NC', N'28211          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (262, N'Mattson, Debora', N'1701 Telfair Chase Way', N'Sacramento', N'CA', N'95814          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (263, N'Allen, Joel', N'2220 W Mission Ln Apt 1127', N'Hilliard', N'OH', N'43026          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (264, N'King, Radhakrishna', N'901 S. Central Expressway', N'Charleston', N'SC', N'29407          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (265, N'Szydlow, Raymond', N'1624 Brougham Place', N'Columbus', N'GA', N'31904          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (266, N'Lumpkin, Christopher', N'100 Church Street', N'Columbus', N'GA', N'31901          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (267, N'Ostrov, Arnold', N'Box 183', N'Harrisburg', N'PA', N'17110          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (268, N'Chinna, Larry', N'2300 Southeastern Ave', N'Marietta', N'GA', N'30062          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (269, N'Shellabarger, Mark', N'34613 Winslow Ter', N'Bannockburn', N'IL', N'60015          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (270, N'Duncan, Ted', N'1003 N. Delano Ave', N'Westminster', N'CA', N'92683          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (271, N'Harke, Richard', N'300 Mustang St', N'Hazelwood', N'MO', N'63042          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (272, N'Craig, Jj', N'1430 Sw 12Th Ave.  1314', N'Stamford', N'CT', N'06906          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (273, N'Kuiu, Ram', N'229 Strawtown Rd', N'North Bend', N'OH', N'45052          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (274, N'Johnson, Scott', N'14 Horseshoe Lane', N'Carver', N'MA', N'02330          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (275, N'Wicks, David', N'34-52 60Th Street', N'Maryland Heights', N'MO', N'63043-3961     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (276, N'Schuh, Max', N'730 Opening Hill Rd', N'Lauderhill', N'FL', N'33313          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (277, N'Dawson, Srividhya', N'907, Lake Run Cir', N'Falss Church', N'VA', N'22041-2536     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (278, N'Melamud, Tammy', N'1345 Avenue Of The Americas', N'Cleveland', N'OH', N'44111          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (279, N'Woo, Kevin', N'1108 W. Indiana Ave.', N'Elk Grove', N'CA', N'95758          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (280, N'White, Barbara', N'3400 Richmond Parkway #3423', N'Bristol', N'CT', N'06010          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (281, N'Schumer, Richard', N'East Remington Drive', N'Woodstock', N'GA', N'30188          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (282, N'Brownstein, Ruth', N'6142C S. Kensington Ave.', N'Boise', N'ID', N'83278          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (283, N'Demers, Ron', N'4Th Floor  F6-F266-04-1', N'Conyers', N'GA', N'30013          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (284, N'Vennapusa, Rani', N'7895 Surreywood Dr.', N'Dallas', N'TX', N'75218          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (285, N'Jefferies, Gloria', N'Matera St', N'San Bruno', N'CA', N'94066          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (286, N'Underwood, Al', N'3520 Twilight Dr', N'Indianapolis', N'IN', N'46227          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (287, N'Kk, Darnell', N'1121 Tama', N'Middletown', N'RI', N'02842          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (288, N'Douglas, Bikash', N'2220 Canton St  Loft 301', N'Columbus', N'WI', N'53925          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (289, N'Drebenstedt, Thomas', N'11 Main Street', N'Florham Park', N'NJ', N'07932          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (290, N'Turner, Eric', N'1728 S. 15Th', N'Arvada', N'CO', N'80002          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (291, N'Volkov, Jim', N'12033 Foundation Place', N'Chicago', N'IL', N'60618          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (292, N'Westemeier, Linda', N'722 N Broadway', N'Jonesboro', N'AR', N'72401          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (293, N'Disanto, Ben', N'402 Clover Springs Drive', N'Irvine', N'CA', N'92612          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (294, N'Stroede, George', N'14115 Fleetwell', N'Washington', N'DC', N'20065          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (295, N'Long, Leon', N'16 Saint Mary Drive', N'Scappoose', N'OR', N'97056-4484     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (296, N'Parmelee, Robert', N'1810 Berry Ln', N'Commerce', N'TX', N'75428          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (297, N'Smith, Deb', N'985 Michigan Av', N'Lakewood', N'CO', N'80228          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (298, N'Smit, Rekha', N'Computer Science Department', N'Topeka', N'KS', N'66612          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (299, N'Hall, Ann', N'114 12Th Ave Nw', N'Tallahassee', N'FL', N'32301          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (300, N'Shaw, Ronald', N'656 Riverside Dr', N'Tustin', N'CA', N'92780          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (301, N'Gujja, Anthony', N'4747 Mclane Parkway', N'Irving', N'TX', N'75038          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (302, N'Kundargi, Danial', N'57 Nevada Dr.', N'Alpharetta', N'GA', N'30004          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (303, N'Andrews, Ashok', N'949 Rockybrook Drive', N'Raleigh', N'NC', N'27613          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (304, N'Blanchard, Eileen', N'11 Harbor Woods Circle', N'Tallahassee', N'FL', N'32312          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (305, N'Cao, Kelly', N'906 Dryden Ave', N'Atlanta', N'GA', N'30303-3404     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (306, N'Bobson, Manohar', N'2200 Cardinal Drive', N'Hermosa Beach', N'CA', N'90254          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (307, N'Valentin-eggert, Michael', N'140, Broadway', N'Indianapolis', N'IN', N'46221          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (308, N'Pierre, Robert', N'155 Grisseltail Rd', N'Park Ridge', N'IL', N'60056          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (309, N'Grampsas, Jiying', N'1200 Wooded Acres Dr.', N'Ames', N'IA', N'50010          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (310, N'Jeffcoat, Nelson', N'5244 West 139Th Street', N'Portland', N'TX', N'78374          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (311, N'Casoli, Dan', N'5 Conrad Court', N'Prairie Village', N'KS', N'66208          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (312, N'Hidalgo, Fgsdg', N'405 Fayette Pike', N'Austin', N'TX', N'78704          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (313, N'Murphy, Colin', N'3831 Pinetree Dr.', N'Asheville', N'NC', N'28806          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (314, N'Gonzalles, Maiv', N'10610 Morado Circle', N'Joplin', N'MO', N'64801          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (315, N'Reinarz, Craig', N'1339 Contra Costa Drive', N'Bernville', N'PA', N'19506          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (316, N'Appandai, Curtis', N'443 Airpark Rd', N'Grand Prairie', N'TX', N'75052          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (317, N'Brown, Srikanth', N'1155 Warburton Ave', N'Richmond', N'CA', N'94806          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (318, N'Avula, Manuel', N'2217 North Ave', N'Lake Success', N'NY', N'11042          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (319, N'Mcdermott, Clifford', N'162 Quail Run', N'Chicago', N'IL', N'60643          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (320, N'Bernard, Subramaniyan', N'125 Raritan Plaza', N'Birmingham', N'AL', N'35222          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (321, N'Sridar, Ashok', N'5146 Keitts Corner Road', N'Liverpool', N'NY', N'13090          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (322, N'Lorusso, Walt', N'6509 Rosemeadows Dr', N'Las Cruces', N'NM', N'88003          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (323, N'Marshburn, Sridhar reddy', N'1530 Broadway Road', N'Brooklyn', N'NY', N'11219          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (324, N'Brown, Connie', N'10302 Joan Drive', N'Appleton', N'WI', N'54915          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (325, N'Tucker, Bill', N'3003 North First Street', N'Milwaukee', N'WI', N'53202          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (326, N'Howell, Kim', N'4010 Bob Wallace Ave Apt 3', N'Renton', N'WA', N'98056          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (327, N'Bostick, Allen', N'7205 None Rd.', N'Montgomery', N'WV', N'25136          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (328, N'Alsaidi, Jim', N'712 White Oak', N'Apopka', N'FL', N'32712          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (329, N'Delatte, William', N'2521 Old Stone Mill Drive', N'Lewisville', N'TX', N'75067          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (330, N'Krishnamurthy, William', N'1110 Ne 12Th St', N'Cranbury', N'NJ', N'08512          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (331, N'Howard, Denise', N'1517 Wn Carrier Pkwy. Ste. 150', N'Wincester', N'TN', N'37398          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (332, N'Galloway, Mariola', N'P.O. Box 250587', N'New York', N'NY', N'10025          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (333, N'Loyal, Chang', N'R.R. 1  Box 132', N'Jacksonville', N'FL', N'32207-3713     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (334, N'Kaphle, Carlos', N'111 Wall St.', N'Houston', N'TX', N'77221          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (335, N'Srigiri, Greg', N'725 Lake St Ne', N'Wesley Chapel', N'NC', N'28173          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (336, N'Mccue, Sreepathi', N'914 Dundee Ct', N'Tinlry Park', N'IL', N'60477          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (337, N'Morgan, John', N'28 Golden Hill', N'Tampa', N'FL', N'33615          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (338, N'Clegg, Viola', N'3635 Vista', N'Mansfield', N'MO', N'65704          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (339, N'Kanter, Cindy', N'17909 Peru Rd # 37', N'Lawrenceville', N'GA', N'30043-5151     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (340, N'Sahoo, Satish', N'55 Water Street', N'Lansing', N'MI', N'48917          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (341, N'D, Elaine', N'3604 Partridge Path Apt 1', N'Rancho Cordova', N'CA', N'95670          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (342, N'Sase, Claude', N'2963 Jones St.', N'Benicia', N'CA', N'94510          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (343, N'Chanduri, Walter c', N'1331 Jefferson Avenue', N'Delray Beach', N'FL', N'33445          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (344, N'Ibarra, John', N'Pob 65', N'Warminster', N'PA', N'18974          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (345, N'Phillips, Jeff', N'223 Sunlit Way', N'Plymouth', N'MI', N'48170          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (346, N'Randazzo, Alaine', N'Hall St', N'Blue Mounds', N'WI', N'53562          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (347, N'Brown, Toni', N'6050 Crawfordville Rd', N'Houston', N'TX', N'77042          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (348, N'Samala, Avelino', N'117 Beacon Ave', N'Lawrence', N'MI', N'49064          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (349, N'Shanmugasundaram, John', N'6890 Deer Court', N'Glen Ellyn', N'IL', N'60137          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (350, N'Posh, Kevran', N'P.O Box 1452', N'Jonesboro', N'AR', N'72401          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (351, N'Cuento, John', N'5100 Tipperary', N'Little Rock', N'AR', N'72022          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (352, N'Cate, Kim', N'123 Wild Lilac Court', N'San Mateo', N'CA', N'94402-5009     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (353, N'Johnson, John', N'23 Main Street', N'Lawrenceville', N'GA', N'30043          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (354, N'Bhatt, Andregene', N'20533 Sw 2 Nd. Street', N'Westerville Dr W', N'OH', N'43082          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (355, N'Jackson, Alex', N'1234 Main St.', N'Doylestown', N'PA', N'18901          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (356, N'Thelagathoti, Brad', N'2010 Glass Rd. Ne Apt 210', N'Dallas', N'TX', N'75211          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (357, N'Hausner, William', N'2512 N.E. 9 Th St', N'Valparaiso', N'IN', N'46383          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (358, N'Mead, Aquanetta', N'2443 Sunset', N'Kenosha', N'WI', N'53142          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (359, N'Vera, Craig', N'8Th Floor', N'Columbus', N'OH', N'43204          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (360, N'Meek, Frank reyes', N'4804 Deer Lake Dr E', N'Ankeny', N'IA', N'50021          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (361, N'Register, Alan', N'4416 Hartdord Dr.', N'Southfield', N'MI', N'48075          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (362, N'Taraszewski, Michael', N'1000 I Street', N'Ozone Park', N'NY', N'11417          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (363, N'Louis, Leanne', N'606 Savannah Highway', N'Tallahassee', N'FL', N'32304          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (364, N'Lawson, Sriramana', N'14160 Red Hill Ave  106', N'Springfield', N'IL', N'62704          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (365, N'Johnson, Anne', N'4511 Hezekiah Pl', N'Temple', N'TX', N'76504          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (366, N'Bannur, Siva', N'252 - 85 Leith Road', N'Milwaukee', N'WI', N'53202          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (367, N'Foote, Debra', N'15769 Helen', N'Buffalo Grove', N'IL', N'60089          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (368, N'Mcdonnell, Siddharth', N'2616 Beeman', N'New Market', N'MD', N'21774          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (369, N'Lakshmanaraju, Jeff', N'1388 Warner Ave', N'Berkeley', N'CA', N'94720          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (370, N'Womack, Gail', N'109 North Street', N'Philadelphia', N'PA', N'19146-1716     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (371, N'Burger, Michael', N'2325 Keaton Ave., Apt. F', N'Matawan', N'NJ', N'07747          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (372, N'B, Rodney', N'502 N. Jefferson St', N'Itasca', N'IL', N'60143          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (373, N'Funai, Margaret', N'P.O.Box 99220', N'Moorestown', N'NJ', N'08057          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (374, N'Then, George', N'85 Notre Dame Dr', N'Garden Grove', N'CA', N'92840          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (375, N'Toocee, Marie', N'4500 Baymeadows Rd', N'Concord', N'CA', N'94519          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (376, N'Chiru, Nate', N'1609 Ranch View Drive', N'Bellmawr', N'NJ', N'08031          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (377, N'Tester, Steve', N'2232 Ironwood Ridge Ct', N'Lowell', N'MA', N'01854          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (378, N'Das, Robert', N'2662, Scotalnd Green', N'Yonkers', N'NY', N'10701          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (379, N'Paul, Sam', N'3249 S. Oak Park Ave', N'Chicago', N'IL', N'60642          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (380, N'Counts, James', N'W3903 Krueger Rd', N'New Milford', N'NJ', N'07646          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (381, N'Obul, Hari', N'241 Main St', N'Temple Terrace', N'FL', N'33637          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (382, N'Berry, R', N'513 Little Ave.', N'Paw Paw', N'MI', N'49079          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (383, N'Viswanathan, Said', N'5 Woodhollow Rd', N'New York', N'NY', N'10005          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (384, N'Graziano, Bob', N'13101 Columbia Pike', N'Matthews', N'NC', N'28105          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (385, N'Gira, Dava', N'24 Northfield Rd', N'Raymore', N'MO', N'64083          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (386, N'Howe, Samuel', N'927A E. Center St.', N'Pittsburgh', N'PA', N'15239-2324     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (387, N'Cox, Lawrence', N'10 Park Plaza', N'Cloverdale', N'CA', N'95425-5440     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (388, N'Wright, Tanya', N'415 W Golf Rd', N'Lincolnshire', N'IL', N'60069          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (389, N'Matthes, Mark', N'750 Crown Cove', N'Salinas', N'CA', N'93908          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (390, N'Riza, Matthew', N'1263 Greenleaf Loop', N'Lake Oswego', N'OR', N'97035          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (391, N'Castle, Kenneth', N'1536 Chicago Blvd', N'Clearwater', N'FL', N'33756          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (392, N'Walker, Bob', N'2200 S Fort Apache #2029', N'Sunnyvale', N'CA', N'94087          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (393, N'Lockhart, Jagloo', N'6349 Beechwood Drive', N'Des Moines', N'IA', N'50310          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (394, N'Verma, Jose', N'1406 17Th Ave', N'N.M.', N'FL', N'33181          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (395, N'Burchard, Jay', N'17440 N Tatum Blvd', N'Indianapolis', N'IN', N'46206          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (396, N'Loper, Demetria', N'3801 S. Capital Of Texas Hw', N'Hackettstown', N'NJ', N'07840          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (397, N'Hollingsworth, Ed', N'626 Picher', N'Columbus', N'OH', N'43215          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (398, N'Wise, Norm', N'1212 N. Lasalle St., #2201', N'Ft Thomas', N'KY', N'41075          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (399, N'Lipsig, Seth', N'16 Shallowford Rd.', N'Chicago', N'IL', N'60656          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (400, N'Litterson, Anthony', N'901 S. National Ave.', N'Phila.', N'PA', N'19105          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (401, N'Antalocy, S.', N'P.O. Box 336', N'Seattle', N'WA', N'98155          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (402, N'Nair, Phalon', N'214 Angela Ave', N'Jersey City', N'NJ', N'07304          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (403, N'Roush, M', N'5111 Ambergate Ln', N'Chapin', N'SC', N'29036          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (404, N'Williams, Bobby', N'9001 Southbay Drive', N'Bronx', N'NY', N'10467          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (405, N'Burnett, Muralikrishna', N'60 Coppermine Road', N'Naperville', N'IL', N'60540          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (406, N'Agarwala, Troy', N'2308 Fair St.', N'Wapakoneta', N'OH', N'45895          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (407, N'Torr, James', N'465 Buckland Hills Dr. Apt 311', N'Dublin', N'NY', N'90210          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (408, N'Anderson, Alan', N'15650A Vineyard Blvd  143', N'Albuquerque', N'NM', N'87101          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (409, N'Lowery, Shane', N'1127 Herbert J.', N'Philadelphia', N'PA', N'19153          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (410, N'Syed, Mike', N'2501 Mcgee', N'Horn Lake', N'MS', N'38637          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (411, N'Harrison, Jeff', N'2560 W. Shaw Ln', N'Dallas', N'TX', N'75201          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (412, N'Dunlavy, Karen', N'1707 4Th Ave Se', N'Anytown', N'CO', N'80204          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (413, N'Fgsgsg, Senthil', N'2025 E Campbell   #143', N'Indianapolis', N'IN', N'46228-3356     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (414, N'Vang, Karl', N'327 Franklin Street', N'Edina', N'MN', N'55435          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (415, N'Green, Ethan', N'810 First Street Ne', N'Oakland', N'CA', N'94612          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (416, N'Elseman, Felix', N'12 E.31St St. Ste 1205N', N'W. Covina', N'CA', N'91719          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (417, N'Blackman, Armando', N'6333 Mount Ada Rd', N'Alpharetta', N'GA', N'30004          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (418, N'Page, Patrick', N'505 Main St', N'Williamsville', N'NY', N'14221-4520     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (419, N'Vidal, William', N'43 Kraft Ln', N'Springfield', N'MA', N'01111-0001     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (420, N'Schulte, Romi', N'147 Afton Ave.', N'Chicago', N'IL', N'60626          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (421, N'Allen, Craig', N'P.O. Box 50016', N'Pullman', N'WA', N'99164          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (422, N'Sowell, Janet', N'189 Commcerce Court', N'Baltimore', N'MD', N'21201          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (423, N'Rennells, Ram', N'310 N. Willomet Ave.', N'Metairie', N'LA', N'70002          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (424, N'Rao, Christina', N'518 Elmwood Terrace', N'Avenel', N'NJ', N'07001          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (425, N'Phinney, Sue', N'624 Aiello St', N'Comstock Park', N'MI', N'49321-9344     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (426, N'Young, Jacquelyn', N'11550 Florida Blvd', N'Richmond', N'VA', N'23227          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (427, N'Wade, Jp', N'6118 Carnation Road', N'Tallahassee', N'FL', N'32305          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (428, N'Plasha, Joe', N'812 West 13Th Street', N'Akron', N'OH', N'44113          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (429, N'Perez, Terrence', N'2325 West Pensacola Street', N'Farmington Hills', N'MI', N'48335          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (430, N'Moore, Richard', N'78 Mckown Road', N'Cedar Rapids', N'IA', N'52401          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (431, N'Laforest, Don', N'Plntation', N'Atlanta', N'GA', N'30324          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (432, N'Ayyappan, Andrew', N'1671 Hampton Knoll Drive', N'Markham', N'IL', N'60426          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (433, N'Arrington, Mallikarjuna', N'2551 Wideworld', N'Miami', N'FL', N'33173          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (434, N'Oriol, Cecilia', N'1108 Fleming Ct.   103', N'Chandler', N'AZ', N'85225          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (435, N'Garrison, Joel', N'16951, Addison Rd', N'New City', N'NY', N'10956-6815     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (436, N'Cloud, Kevin', N'652 N Sam Houston', N'Jackson', N'MI', N'49202          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (437, N'Little, Walton', N'10566 Tiger Point', N'Downingtown', N'PA', N'19335          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (438, N'Moore, Mv', N'6315 N 16Th St, 229', N'Brooklyn', N'NY', N'11219          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (439, N'Clark, Donald', N'1015 E. 20Th St Apt C', N'Plano', N'TX', N'75086          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (440, N'Vatcheva, Scott', N'315 Court Street', N'Marshall', N'WI', N'53559          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (441, N'Owen, Mark', N'P.O. Box 1537', N'Belleville', N'NJ', N'07109          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (442, N'Meeker, Tsao-shiang', N'2100 Paul Edwin Terr', N'Olathe', N'KS', N'66062          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (443, N'Xiong, J', N'Po Box 8403', N'Topeka', N'KS', N'66604-1877     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (444, N'Truesdale, David', N'Po Box 6459', N'Huntsville', N'AL', N'35805          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (445, N'Miller, Bassam', N'10 Erick Rd #15', N'Hyattsville', N'MD', N'20783          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (446, N'Stone, Milind', N'44 Kinler', N'Saint Paul', N'MN', N'55116          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (447, N'Borskiy, Jamie', N'12301 Warner Dr', N'St. Augustine', N'FL', N'32084          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (448, N'Larson, Heriberto', N'7623 Matera St #103', N'Alpine', N'AL', N'35014          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (449, N'Chandrasekhar, Yagnaraju', N'2149 West Dunlap Avenue', N'Bethalto', N'IL', N'62010          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (450, N'Patthana, Patrick', N'124 Austin Building', N'Peoria', N'IL', N'61614          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (451, N'Balija, Jeff', N'4723. W. Braddock Road', N'Dallas', N'TX', N'75252          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (452, N'Butler, Paul', N'125 Rosewood Drive', N'Florence', N'SC', N'29501          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (453, N'Smith, Uma', N'915 Sw Harrison', N'Kc', N'MO', N'64151          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (454, N'Shakeel, Cynthia', N'120 Blue Ridge Trace', N'Plainsboro', N'NJ', N'08536          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (455, N'Faver, Michael', N'260 Franklin Turnpike Apt 513', N'Lincoln', N'NE', N'68512          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (456, N'Ehardt, Faina', N'4747 Mclane Parkway', N'Redwood City', N'CA', N'94062          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (457, N'Hughes, Steve', N'21555 Oxnard Street', N'Fenton', N'MO', N'63026          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (458, N'Mike, Bill', N'88 Silva Lane', N'Berkeley', N'CA', N'94720          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (459, N'Byker, Samuel', N'2801 East College Way', N'Plano', N'TX', N'75093          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (460, N'Weathers, Sandhya', N'Its - City Hall - Room 6', N'Bowdon', N'GA', N'30108          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (461, N'Bodnovich, Vivek', N'1000 Lakeside Dr.', N'Atlanta', N'GA', N'30339          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (462, N'Cofer, Kathy', N'1441 Schilling Place', N'Burr Ridge', N'IL', N'60527          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (463, N'Pickens, Bumpy', N'729 Woodmere Creek Loop', N'Pittsburgh', N'PA', N'15233          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (464, N'Bagent, Tom', N'1120 N St.', N'Camp Hill', N'PA', N'17011          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (465, N'Sui, Don', N'6607 Brodis Lane  335', N'Parsippany', N'NJ', N'07054          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (466, N'Howard, Harold', N'920 Harvest Dr', N'Grand Prairie', N'TX', N'75050          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (467, N'Myl, Carolyn', N'4343 Warm Springs Rd Apt 1019', N'Butler', N'PA', N'16002          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (468, N'Ross, Kevin', N'1955 Amber Trail Rd', N'Dayton', N'MD', N'21036          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (469, N'Schmitt, Tom', N'12001 Sw 14Th Street', N'Valley Forge', N'PA', N'19482          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (470, N'Thompson, Elsy', N'916 N. Lincoln', N'Troy', N'MI', N'48099          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (471, N'Stapleton, Victor', N'267 Amboy Avenue', N'Muskegon', N'MI', N'49441-4588     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (472, N'Tallada, Raghu', N'128 Greenbriar Dr', N'Madison Heights', N'MI', N'48976          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (473, N'Grant, Murali', N'1344 B Street', N'Queens Village', N'NY', N'11427          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (474, N'Key, David', N'2 Pierce Place', N'Streamwood', N'IL', N'60107          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (475, N'Gupta, Deborah', N'5 Lilly Pond Circle', N'Southboro', N'MA', N'01772          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (476, N'Sharma, Carlo', N'18081 Midway Rd', N'Washington', N'DC', N'20011          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (477, N'Horton, James', N'2455 Paces Ferry Rd.', N'Williamsville', N'NY', N'14221          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (478, N'Millard, Dwayne', N'634 Koehler Road', N'Seattle', N'WA', N'98178          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (479, N'Kattekula, Luis', N'14252 St Rt 65', N'Eden Prairie', N'MN', N'55346          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (480, N'Hanak, Sharan', N'1200 N. Market St.', N'St. Louis', N'MO', N'63113          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (481, N'Young, Chris', N'6705 Harlan Drive', N'Falls Church', N'VA', N'22043          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (482, N'Rampel, John', N'123-12 Gcp', N'Waco', N'TX', N'76710          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (483, N'Kumar, Gary', N'183 Loudon Rd, Apt   4', N'Columbus', N'OH', N'43201          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (484, N'Gallaspy, Bill', N'2794 Blarefield Driev', N'New York', N'NY', N'10041          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (485, N'Kerr, Harper', N'Po Box 2337', N'St Albans', N'VT', N'05478          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (486, N'Rose, Alan', N'P.O. Box 8553', N'St. Petersburg', N'FL', N'33704          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (487, N'Pak, Robert', N'101 Satinwood Drive', N'Mechanicsville', N'VA', N'23111          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (488, N'Howland, Robert', N'5806 Leanne Ln', N'Pittsburg', N'CA', N'94565          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (489, N'Kauffmanm, Lashonda', N'211 Main Street', N'Sarasota', N'FL', N'34243          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (490, N'Johnson, Balasundaram', N'850 Cherry', N'New York', N'NY', N'10292          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (491, N'Grahovek, Stephen', N'12 Booth Street', N'Germantown', N'TN', N'38138          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (492, N'Brown, Nagarjun', N'Po Box 50', N'Poughkeepsie', N'NY', N'12603          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (493, N'Stewart, Christopher', N'1 Court Circle', N'Georgetown', N'TX', N'78628          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (494, N'Barrios, Rajeev', N'471 Regan Ln', N'Northborough', N'MA', N'01532          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (495, N'Smith, Arthur', N'P.O. Box 190886', N'Laurelton', N'NY', N'11413          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (496, N'Conlan, Armstrong', N'3404 Tulane Drive Apt. 21', N'Forestville', N'MD', N'20747          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (497, N'Mccord, Alex', N'1731 Ne 141 St', N'Schaumburg', N'IL', N'60173          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (498, N'Brasher, Ruth', N'4 S. Highview Cir', N'Charlotte', N'NC', N'28211          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (499, N'Mayo, Kevin', N'2882 Tall Oaks Ct', N'Dayton', N'OH', N'45449          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (500, N'Bivans, Paul', N'17B Pauline Street', N'Columbus', N'GA', N'31909          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (501, N'Korde, Shubha', N'1326 Mississippi Street', N'San Jose', N'CA', N'95134          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (502, N'Mauthe, Hipolito', N'1262 11Th Avenue', N'Philadelphia', N'PA', N'19128-4732     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (503, N'Woolf, Ginny', N'16021 N 30Th St Unit 110', N'Houston', N'TX', N'77060          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (504, N'Richards, Kim', N'1800 Harrison St, 9Th Fl', N'Milford', N'CT', N'06460          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (505, N'Larsen, Kristina', N'3325 S Douglas Av', N'San Francisco', N'CA', N'94122          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (506, N'Hacker, Ruben', N'3 Willow Way', N'Cleveland', N'OH', N'44115          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (507, N'Seeley, Joe', N'1101 Monterey Blvd', N'Secaucus', N'NJ', N'07094          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (508, N'Dzialak, Francisco', N'9523 Blake Lane 101', N'Mesquite', N'TX', N'75181-1266     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (509, N'Cassara, Glenn', N'5514 W. Como Ave.', N'Van', N'WA', N'98654          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (510, N'Bassett, Mark', N'12750 Fair Lakes Circle', N'Farmington', N'CT', N'06032          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (511, N'Diggity, Shailesh', N'7 Easton Oval', N'Parsippany', N'NJ', N'07054          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (512, N'Armalie, Dennis', N'50 East 21St Street', N'Salinas', N'CA', N'93907          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (513, N'Miller, Billy', N'1123A Kingbolt Circle Dr', N'Castro Valley', N'CA', N'94552          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (514, N'Caldwell, Luminita', N'170 Big Perry Rd', N'Midlothian', N'VA', N'23114          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (515, N'Herrera, Ken', N'8231 Princeton Sq Blvd', N'Bridgeton', N'MO', N'63044-1785     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (516, N'Tucker, Don', N'25 Abenaki Road', N'Charlotte', N'NC', N'28211          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (517, N'Nair, Reggie', N'4536 Castleton Rd', N'Glastonbury', N'CT', N'06033          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (518, N'Yerrapu, Michele', N'12892 Glendon Street', N'Falls Church', N'VA', N'22043          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (519, N'Julien, Gil', N'59 Clinton St', N'Countryside', N'IL', N'60525-4088     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (520, N'Spencer, Robert', N'P.O. Box 38136', N'Newark', N'NJ', N'07106          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (521, N'Giglio, Ric', N'319 Krams Avenue', N'Pembroke Pines', N'FL', N'33025          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (522, N'Wheatley, Paul', N'295 Firstmerit Circle', N'Allen', N'TX', N'75002          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (523, N'Bommareddy, Richard', N'4415 Canoga Ave', N'New York', N'NY', N'10016-6702     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (524, N'Vera, Kevin', N'9379 ''''N'''' Street', N'Aurora', N'IL', N'60504          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (525, N'Rozenberg, Angela', N'1310, Oakcrest Dr.', N'Falls Church', N'VA', N'22043          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (526, N'Agrawal, Weining', N'1435 Chrome Hill Road', N'Chickasha', N'OK', N'73018          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (527, N'Grottolo, Satya', N'710 1/2 Stark St.', N'Manchester', N'CT', N'06040          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (528, N'Malausky, Scott', N'14000 Hwy 82W', N'Forest', N'VA', N'24551          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (529, N'Erdman, Paul', N'5021 Shinnecock Hills Dr. N.W.', N'Dallas', N'TX', N'75218          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (530, N'Soucie, Kimberly', N'6694 Cottontown Rd', N'Needham', N'MA', N'02494          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (531, N'Lance, Al', N'Admn 122', N'Columbia', N'SC', N'29223          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (532, N'Pat, Ed', N'1601 Bryan St., Suite 27-037', N'Mclean', N'IL', N'61754-7541     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (533, N'Brown, Ashwini', N'821 S Williams', N'Cullman', N'AL', N'35055          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (534, N'Krani, George', N'2014 S 102Nd Street, 210 C', N'Maynard', N'MA', N'01754          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (535, N'Routhu, Mark', N'476 Viola Rd.', N'Franklin', N'TN', N'37067          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (536, N'Johnson, Wendy', N'1223 Cannes Court', N'Mt Horeb', N'WI', N'53572          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (537, N'Justme, David', N'57 Cheshire Dr', N'Jackson', N'MI', N'49202          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (538, N'Nevils, William', N'1200 N. Market St.', N'Centerville', N'MN', N'55038          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (539, N'Mills, Richard', N'8 Glenford Lane', N'Jacksonville,', N'FL', N'32217-4313     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (540, N'Antosca, Andrew', N'485 Duane Terrace', N'Ann Arbor', N'MI', N'48108          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (541, N'Pao, Sidoneo', N'200 Engamore Lane', N'Tallahassee', N'FL', N'32315          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (542, N'Nolan, Joseph', N'13 N San Marcos Rd', N'Camillus', N'NY', N'13031          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (543, N'Otis, Connie', N'165 Timmons Road', N'Columbus', N'IN', N'43231          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (544, N'Val, Zarina begum', N'34-38 71St St', N'Plano', N'TX', N'75024          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (545, N'Wright, Venkat', N'800 Crescent Center Drive, Sui', N'Jamaica', N'NY', N'11435          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (546, N'Mullen, Charles', N'409 Eleventh St.', N'Parsippany', N'NJ', N'07054          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (547, N'Kelly, George', N'7852 Ponce Ave', N'Palatine', N'IL', N'60074          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (548, N'Humble, Jen', N'430 Castle Dr', N'Woodland Hills', N'CA', N'91364          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (549, N'Rogers, L', N'P. O.  Box  53167', N'St. Louis', N'MO', N'63110          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (550, N'Rivera, Joseph', N'12033 Foundation Place', N'Netcong', N'NJ', N'07857          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (551, N'Nelsen, Jim', N'4251 Parkalwn Ave, # 202', N'Ft Washington', N'MD', N'20744          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (552, N'Wilson, Kenneth', N'1011 N 26Th', N'West Des Moines', N'IA', N'50266          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (553, N'Jackson, Sukumar', N'118 Kendrick St.', N'Tampa', N'FL', N'33607          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (554, N'Pukala, James', N'35 W59Th Street', N'Baltimore', N'MD', N'21207          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (555, N'Wen, Wayne', N'1950 Franklin Street', N'Vallejo', N'CA', N'94590          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (556, N'Smth, Lana', N'2567 South 156 Avenue', N'Warren', N'PA', N'16365          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (557, N'Landin, Peggy', N'3011 Woodloop Ln', N'Phoenix', N'AZ', N'85022          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (558, N'Loest, Monica', N'14 Locust Grove Road', N'Lenoir', N'NC', N'28645          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (559, N'Oliveira, Puli', N'3219 S Grace Ave', N'Jersey City', N'NJ', N'07302          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (560, N'Bohra, Mark', N'Brgy. 68, San Francisco,', N'Succasunna', N'NJ', N'07876          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (561, N'Varner, Sangil', N'940 W 131St St', N'Legaspi City', N'PR', N'04500          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (562, N'Reinhart, Terry', N'East Hall, Room 7', N'Toronto', N'TN', N'37415          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (563, N'Kidwell, Suresh', N'4005 Brookhaven Club Drive', N'Houston', N'TX', N'77269-2370     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (564, N'Hogen, Fausitna', N'315 Bart Rd.', N'Leominster', N'MA', N'01453          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (565, N'Tamunday, D', N'1409,Roper Mountain Road, Apt', N'Hopatcong', N'NJ', N'07843          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (566, N'Hunter, Deepa', N'1951 Cypress Street', N'Columbia', N'SC', N'29201          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (567, N'Fuglemsmo, Johnny', N'3543 Simpson Ferry Rd', N'Taylor Mill', N'KY', N'41015-4124     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (568, N'Schaa, Greg', N'821 Azores Cir', N'Austin', N'TX', N'78704          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (569, N'Oakes, Tyrone', N'2383 Akers Mill Road', N'Columbus', N'OH', N'43220          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (570, N'Bingham, Robert', N'44 Boulder Avenue', N'Birmingham', N'AL', N'35215          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (571, N'Paik, Brian', N'2000 Westminster Lane', N'Rochester Hills', N'MI', N'48307          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (572, N'Smith, Lloyd', N'9432 Downing Circle', N'Pullman', N'WA', N'99164          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (573, N'Torres, Peter', N'1102 North 8Th Street', N'Westminster', N'CO', N'80021          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (574, N'Hayes, Dan', N'P.O. Box 777', N'Brooklyn', N'NY', N'11235          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (575, N'Jackson, Laura', N'3570- C, Meadowglenn Apts', N'Le Mars', N'IA', N'51031          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (576, N'Shepherd, Jamie', N'1341 East Thacker Street', N'Highlands Ranch', N'CO', N'80126          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (577, N'Pluff, Mark', N'9420 Key West Avenue', N'Springfield', N'NJ', N'07081          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (578, N'Cefalu, George', N'19 Winchester St #207', N'Milwaukee', N'WI', N'53212          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (579, N'Hines, Enoch', N'2416 Westgate Dr', N'Dallas', N'TX', N'75201          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (580, N'Swartz, Doug', N'405 Pattoon St', N'Irving', N'TX', N'75039          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (581, N'Mccann, Chris', N'Po Box 9041', N'Omaha', N'NE', N'68127          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (582, N'Wilder, Phil', N'210 W. Collins', N'Berkeley', N'CA', N'94720          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (583, N'Denny, Scott', N'707 East Central', N'Oak Park', N'IL', N'60301          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (584, N'Brethauer, Rhonda', N'108 Copperfield Road', N'St Louis', N'MO', N'63101          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (585, N'Heng, Xiaowei', N'800 South Washington Street', N'Clarks Summit', N'PA', N'18411          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (586, N'Vulman, George', N'340 West Miller Street', N'Westminster', N'CO', N'80030          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (587, N'Miller, Robyn', N'3527 Holmead Pl.', N'Saint Louis', N'MO', N'63136          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (588, N'Ibach, Ray', N'43155 Wayne Stevens Rd', N'Pompton Plains', N'NJ', N'07444          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (589, N'Hubbard, Jill', N'128 Pine Hill Avenue', N'Falls Church', N'VA', N'22043          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (590, N'Peterson, Arthur', N'2682 Southmoore Cove', N'Atlatna', N'GA', N'30328          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (591, N'Blow, Raj', N'3100 Expressway Apt. 652', N'Livonia', N'MI', N'48150          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (592, N'Maltais, Sheri', N'3533 Lee Hills Dr.', N'Wyoming', N'MI', N'49509          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (593, N'Reeves, Raleigh', N'15 Forest Street', N'Eden Prairie', N'MN', N'55344          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (594, N'Chavan, Rhonda', N'518 Commanche Tr.', N'Greensboro', N'NC', N'27410          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (595, N'Pineda, Bhargava', N'1146-A Easton Ave', N'Olive Branch', N'MS', N'38654          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (596, N'Mcmillen, G', N'Po Box 459', N'Kirkland', N'WA', N'98033          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (597, N'Hanna, Andrew', N'43 Railroad Av', N'Springboro', N'OH', N'45066          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (598, N'Foreman, Louis', N'138-45 224Th Street', N'Springfield', N'MO', N'65804          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (599, N'Bentley, Kieu', N'1248 N 119Th St', N'Chicago', N'IL', N'60606          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (600, N'Ahmed, Uma', N'110 Jay Dr.', N'Polk City', N'IA', N'50226          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (601, N'Anderson, Randy', N'811 Polo Road', N'Wilmerding', N'PA', N'15148          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (602, N'Harrison, Will', N'100 Half Day Rd.', N'East Brunswik', N'NJ', N'08816          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (603, N'Lind, Bryon', N'219 Grenadier Drive', N'Safety Harbor', N'FL', N'34695          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (604, N'Guzman, Robert', N'194 Crofton Drive', N'Evans', N'GA', N'30809          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (605, N'Bathwater, Venkatesh', N'605 Suwannee St.', N'Burlingame', N'CA', N'94010          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (606, N'Hester, Robert', N'1 Constitution Way', N'Baltimore', N'MD', N'21244          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (607, N'Gross, Ranji', N'26 Mist Hill Drive', N'Madison', N'SD', N'57042          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (608, N'Mukhopadhyay, Kondal rao', N'43 Huntington St', N'Herndon', N'VA', N'20170          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (609, N'Ranieri, Rich', N'118 Huntington Street', N'Houston', N'TX', N'77096          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (610, N'Young, James', N'6368 Andrews Dr W', N'Buffalo', N'NY', N'14203          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (611, N'Coleman, Carl', N'30 S. Wacker Dr', N'Dallas', N'TX', N'75248          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (612, N'Avula, Glenn', N'650 South Front St.', N'Matthews', N'NC', N'28104          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (613, N'Chen, Mary', N'22 Pleasant Street', N'Baltimore', N'MD', N'21214          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (614, N'Hinkley, Martha', N'2111 E. 37Th St. N.', N'Woodland Hills', N'CA', N'91367          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (615, N'Matte, Kris', N'1225 Nw Cooke Ave', N'Austin', N'TX', N'78148          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (616, N'Galvis, Mike', N'4015 Buckingham Road', N'Alexandria', N'VA', N'22311          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (617, N'Dennis, Larry', N'900 Mickley Rd', N'Lafayette', N'LA', N'70506          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (618, N'Murray, Teresa', N'1200 Corporate Systems Center', N'St. Louis', N'MO', N'63103          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (619, N'Prakash, Richie', N'26 Corporate Hill Dr.', N'Carmichael', N'CA', N'95608          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (620, N'Buntin, Ravikumar', N'5087 Sheridan Dr.', N'Grand Forks', N'ND', N'58201          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (621, N'Rehm, Robert', N'1900 E. Oakland St.', N'Cedar Falls', N'IA', N'50613          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (622, N'Sherman, Steve', N'1800 Longcreek Dr.', N'Berwyn', N'IL', N'60402          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (623, N'Bryant, Shilpa', N'21 Meadow Rd.', N'Auburn Hills', N'MI', N'48326          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (624, N'Miranda, Bob', N'154 Apt # H', N'Carmel', N'IN', N'46032          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (625, N'Giragani, Michelle', N'2335 Saint Albans Place', N'North Wales', N'PA', N'19454          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (626, N'Aronov, Mark', N'1000 Cherry Lane', N'Mesa', N'PA', N'85310          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (627, N'Anto, John', N'3500 Savannah Park Ln.', N'Alpharetta', N'GA', N'30022          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (628, N'Mavraedis, Charles', N'1-205 Lamoine Village', N'Cypress', N'TX', N'77429          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (629, N'Tankkar, Boris', N'1049 Creek Hollow Lane', N'Albany', N'NY', N'12203          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (630, N'Blick, Mark', N'1335 Bradyville Pike Apt F206', N'Hopkins', N'MN', N'55343          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (631, N'Mansir, Theresa', N'312 Bishop Rd', N'Greenvile', N'SC', N'29615          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (632, N'Yang, Daniel', N'343 Peach Rd', N'Queens', N'NY', N'11362          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (633, N'Phillips, Louis', N'90-19 211Th Street', N'Salisbury', N'MD', N'21802          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (634, N'Fannin, P.', N'5000 Ellin Rd', N'Mitchellville', N'MD', N'20721          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (635, N'Kondratieff, Bill', N'P.O.Box 245', N'Omaha', N'NE', N'68103-0777     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (636, N'May, Joann', N'Po Box 645910', N'Starkville', N'MS', N'39759          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (637, N'Wainscott, Brent', N'1129 Treeside Ln', N'Mahwah', N'NJ', N'07430          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (638, N'Akkiraju, Mike', N'3811 N. Bell', N'Hazlet', N'NJ', N'07730          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (639, N'Davis, Frank', N'2222 Welborn St.', N'Milwaukee', N'WI', N'53202          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (640, N'Zaslavskaya, Alok', N'2850 24Th Avenue', N'Hacienda Heights', N'CA', N'91745          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (641, N'Burgess, Jonathan', N'5909 Birchbrook', N'Grand Prairie', N'TX', N'75050          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (642, N'Hall, Wayne', N'6 Reservoir Drive', N'Columbia', N'TN', N'38401          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (643, N'Lee, Cindy', N'1000 Middle St', N'Flushing', N'NY', N'11354          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (644, N'Grimm, jr., Ramanathan', N'20 Bernard Road', N'Barrington', N'IL', N'60010          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (645, N'Cable, Clay', N'1463 Timber Ridge Court', N'Gilbert', N'AZ', N'85233          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (646, N'Alderman, James', N'6405 N Mokane Ct', N'Columbia', N'MD', N'21046          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (647, N'Ivy, Erika', N'10433 Sunnybrook Circle', N'Baltimore', N'MD', N'21207          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (648, N'Kota, Connie', N'400 Sir Walter Drive', N'Willingboro', N'NJ', N'08046          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (649, N'Deb, Pio', N'3855 Blair Mill Rd', N'Mentor', N'OH', N'44060          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (650, N'Salazar, Joel', N'1601 1St Ave.', N'El Segundo', N'CA', N'90245-3803     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (651, N'Lynn, Nelson', N'1945 Lindenwood', N'Brooklyn', N'NY', N'11219          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (652, N'Dunn, Ole', N'317 Main Street - Info Sys', N'Birmingham', N'AL', N'35288          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (653, N'Meadows, Joy', N'1429 Senate Street', N'Sacramento', N'CA', N'95818          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (654, N'Milliano, Chuan hwa', N'2150 Wenlok Trail', N'Chicago', N'IL', N'60615          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (655, N'Kamble, Keith', N'27473 Audrey', N'Carrollton', N'TX', N'75006          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (656, N'Lee, Valerie', N'1381 Anderson Avenue', N'Sacramento', N'CA', N'95814          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (657, N'Jachimski, Myron', N'8000 Utopia', N'Glendale', N'AZ', N'85302          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (658, N'Zavrotny, Lisa', N'4905 Muirwood Dr', N'Glen Allen', N'VA', N'23030          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (659, N'Lee, Jeff', N'32 Gatehouse Lane', N'Roseville', N'CA', N'95829          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (660, N'Weckbecker, Asoka', N'4556 Shadowridge Dr', N'Cincinnati', N'OH', N'45238          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (661, N'Ritzcovan, Toocee', N'2828 Tudor Court', N'West Allis', N'WI', N'53227          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (662, N'Chogyoji, Rahul', N'2100 Nursery Rd Apt E1', N'Whitehall', N'PA', N'18052          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (663, N'Vengala, Kim', N'110 Kope Ave', N'Oklahoma City', N'OK', N'73112          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (664, N'Turnquist, Sharon', N'1222 N. Fieldcrest St.', N'Stephenville', N'TX', N'76401          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (665, N'Rodriguez, Earlene', N'537 Mansfield Village', N'Jackson', N'MS', N'39217          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (666, N'Wu, Jeffrey', N'4800 Regent Blvd', N'Como', N'TX', N'75431          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (667, N'Amoroso, Hazel-ann', N'5114 Walnut Haven Ln', N'Tallahassee', N'FL', N'32362          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (668, N'Keeble, John', N'71 Hanover Rd', N'Louisville', N'KY', N'43215          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (669, N'Bozonelos, Pulkit', N'3330 N. Causeway Blvd.', N'Las Vegas', N'NV', N'89117          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (670, N'Cadle, Michael', N'572 Brook Street', N'Van Wert', N'OH', N'45891          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (671, N'Patel, Ramesh', N'194 Wood Ave, South', N'San Diego', N'CA', N'92126          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (672, N'Slivkoff, Scott', N'P.O. Box 524', N'Summerville', N'SC', N'29483          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (673, N'Krish, Munish', N'451 N. Lake Ave.', N'Cedar Rapids', N'IA', N'52404          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (674, N'Arumugam, Hemant', N'4075, Pineset Drive', N'Dallas', N'TX', N'75132          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (675, N'Franklin, Cesar', N'5260 Winchester Road', N'Schaumburg', N'IL', N'60173          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (676, N'Nguyen, Ram', N'1006 Gardens Place', N'Decatur', N'GA', N'30030          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (677, N'Carroll, Sam', N'9379 N Street', N'Long Beach', N'CA', N'90806          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (678, N'Shaw, Warren', N'1741 E. Robin Lane', N'Washington', N'DC', N'20002          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (679, N'Powell, Tony', N'128 Westridge Dr', N'Latham', N'NY', N'12110          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (680, N'Warner, Bala', N'Po Box 335', N'West Hartford', N'CT', N'06119          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (681, N'Vera, Anbusekaran', N'526 Hunterdale Road', N'Columbus', N'OH', N'43231          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (682, N'Oneil, Ri', N'7961 Inwood Ln', N'Olympia', N'WA', N'98504-3123     ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (683, N'Condron, Michael', N'866 Butternut Dr.', N'Salinas', N'CA', N'93901          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (684, N'Yu, Hemant', N'19621 Portsmouth Drive', N'Lanham', N'MD', N'20706          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (685, N'Dutton, Philip', N'225 Summit Avenue', N'Dacula', N'GA', N'30019          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (686, N'Kumar, Manoj', N'756 Crocus Lane', N'Charlotte', N'NC', N'28269          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (687, N'Wolff, Ken', N'820 Club Chase Ct.', N'Edison', N'NJ', N'08837          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (688, N'Collier, Dan', N'7212 Dalewood Dr.', N'Duluth', N'GA', N'30097          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (689, N'Jerome, Beverly', N'3206 Greenhollow Dr', N'Metuchen', N'NJ', N'08840          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (690, N'Leonnig, Timothy', N'1802 Bel Air Dr', N'Columbus', N'OH', N'43229          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (691, N'Mceachen, Art', N'4204 Greencastle Ct.  102', N'Spring', N'TX', N'77373          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (692, N'Czarnik, Mark', N'480 Valley Rd., A15', N'Mankato', N'MN', N'56001          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (694, N'Lowe, Doug', N'3251 W. Ellery', N'Fresno', N'CA', N'93711          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (696, N'Smith, Lawrence', N'2883 Sicamore Street', N'Fresno', N'CA', N'93711          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (697, N'Wilson, Wilson', N'4288 Maple', N'Fresno', N'CA', N'93711          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (698, N'Blake, John', N'388 Sicamore', N'Fresno', N'CA', N'93704          ')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [State], [ZipCode]) VALUES (699, N'Wilkins, Adrian', N'488 Maple', N'Fresno', N'CA', N'92707          ')
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (18, N'JSJQ      ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (18, N'SQLS      ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (18, N'VB        ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (23, N'PYTHON    ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (26, N'ANDROID   ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (27, N'ANDROID   ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (29, N'PYTHON    ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (30, N'JSP       ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (31, N'JSP       ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (32, N'MYSQL     ', 54.5000, 1, 54.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (32, N'ORACLE    ', 54.5000, 1, 54.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (33, N'ASPWEB    ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (33, N'C#        ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (33, N'SQLS      ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (41, N'ANDROID   ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (42, N'ASPWEB    ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (43, N'MYSQL     ', 54.5000, 1, 54.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (44, N'PYTHON    ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (45, N'PYTHON    ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (46, N'ASPWEB    ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (46, N'C#        ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (46, N'HTML      ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (46, N'SQLS      ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (47, N'ASPWEB    ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (47, N'C#        ', 57.5000, 4, 230.0000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (48, N'PYTHON    ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (49, N'JQ        ', 54.5000, 1, 54.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (49, N'JS        ', 54.5000, 1, 54.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (50, N'C++       ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (57, N'ANDROID   ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (58, N'ANDROID   ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (59, N'C++       ', 59.5000, 10, 595.0000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (60, N'PYTHON    ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (62, N'PHP       ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (66, N'PYTHON    ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (68, N'ANDROID   ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (69, N'JSJQ      ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (101, N'JAVA      ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (102, N'ASPWEB    ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (102, N'HTML      ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (102, N'VB        ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (104, N'HTML      ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (105, N'HTML      ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (105, N'JAVA      ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (106, N'ANDROID   ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (106, N'C++       ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (106, N'PYTHON    ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (108, N'JAVA      ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (110, N'JQ        ', 54.5000, 1, 54.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (110, N'JS        ', 54.5000, 1, 54.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (111, N'HTML      ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (111, N'JSJQ      ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (114, N'SQLS      ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (114, N'VB        ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (115, N'HTML      ', 59.5000, 1, 59.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (116, N'C#        ', 57.5000, 1, 57.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (117, N'MYSQL     ', 54.5000, 1, 54.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (117, N'ORACLE    ', 54.5000, 1, 54.5000)
GO
INSERT [dbo].[InvoiceLineItems] ([InvoiceID], [ProductCode], [UnitPrice], [Quantity], [ItemTotal]) VALUES (118, N'C#        ', 57.5000, 1, 57.5000)
GO
SET IDENTITY_INSERT [dbo].[Invoices] ON 
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (18, 20, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 172.5000, 12.9375, 6.2500, 191.6875)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (23, 694, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (26, 35, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (27, 11, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (29, 13, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (30, 15, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (31, 11, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (32, 40, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 109.0000, 8.1750, 5.0000, 122.1750)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (33, 33, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 174.5000, 13.0875, 6.2500, 193.8375)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (41, 333, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (42, 666, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 59.5000, 4.4625, 3.7500, 67.7125)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (43, 332, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 54.5000, 4.0875, 3.7500, 62.3375)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (44, 555, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (45, 213, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (46, 20, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 234.0000, 17.5500, 7.5000, 259.0500)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (47, 10, CAST(N'2020-04-13T00:00:00.000' AS DateTime), 287.5000, 21.5625, 8.7500, 317.8125)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (48, 25, CAST(N'2020-04-14T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (49, 694, CAST(N'2020-04-14T00:00:00.000' AS DateTime), 109.0000, 8.1750, 5.0000, 122.1740)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (50, 20, CAST(N'2020-04-14T00:00:00.000' AS DateTime), 59.5000, 4.4625, 3.7500, 67.7125)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (57, 88, CAST(N'2020-04-14T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (58, 10, CAST(N'2020-04-19T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (59, 50, CAST(N'2020-04-19T00:00:00.000' AS DateTime), 595.0000, 44.6250, 15.0000, 654.6250)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (60, 15, CAST(N'2020-04-19T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (62, 15, CAST(N'2020-04-19T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (66, 10, CAST(N'2020-04-24T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (68, 10, CAST(N'2020-04-26T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (69, 11, CAST(N'2020-04-26T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (101, 10, CAST(N'2020-05-09T00:00:00.000' AS DateTime), 59.5000, 4.4625, 3.7500, 67.7125)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (102, 408, CAST(N'2020-05-09T00:00:00.000' AS DateTime), 176.5000, 13.2375, 6.2500, 195.9875)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (104, 25, CAST(N'2020-05-22T11:04:35.060' AS DateTime), 59.5000, 4.4625, 3.7500, 67.7125)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (105, 239, CAST(N'2020-05-22T14:35:26.913' AS DateTime), 119.0000, 8.9250, 5.0000, 132.9250)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (106, 125, CAST(N'2020-05-23T10:26:25.687' AS DateTime), 174.5000, 13.0875, 6.2500, 193.8375)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (108, 495, CAST(N'2020-05-28T00:00:00.000' AS DateTime), 59.5000, 4.4625, 3.7500, 67.7125)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (110, 470, CAST(N'2020-05-28T00:00:00.000' AS DateTime), 109.0000, 8.1750, 5.0000, 122.1750)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (111, 233, CAST(N'2020-07-19T15:32:51.220' AS DateTime), 117.0000, 8.7750, 5.0000, 130.7750)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (114, 495, CAST(N'2020-07-26T00:00:00.000' AS DateTime), 115.0000, 5.7500, 5.0000, 125.7500)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (115, 200, CAST(N'2020-07-26T00:00:00.000' AS DateTime), 59.5000, 4.4625, 3.7500, 67.7125)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (116, 326, CAST(N'2020-07-26T00:00:00.000' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (117, 601, CAST(N'2020-08-07T00:00:00.000' AS DateTime), 109.0000, 8.1750, 5.0000, 122.1750)
GO
INSERT [dbo].[Invoices] ([InvoiceID], [CustomerID], [InvoiceDate], [ProductTotal], [SalesTax], [Shipping], [InvoiceTotal]) VALUES (118, 523, CAST(N'2020-09-13T14:24:35.530' AS DateTime), 57.5000, 4.3125, 3.7500, 65.5625)
GO
SET IDENTITY_INSERT [dbo].[Invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderOptions] ON 
GO
INSERT [dbo].[OrderOptions] ([OptionID], [SalesTaxRate], [FirstBookShipCharge], [AdditionalBookShipCharge]) VALUES (1, CAST(0.0750 AS Decimal(18, 4)), 3.7500, 1.2500)
GO
SET IDENTITY_INSERT [dbo].[OrderOptions] OFF
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'ANDROID   ', N'Murach''s Android Programming', 57.5000, 3756)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'ASPWEB    ', N'Murach''s ASP.NET Web Forms', 59.5000, 3974)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'C#        ', N'Murach''s C#', 59.5000, 4347)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'C++       ', N'Murach''s C++ Programming', 59.5000, 3874)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'HTML      ', N'Murach''s HTML and CSS', 59.5000, 4637)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'JAVA      ', N'Murach''s Java Programming', 59.5000, 4683)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'JQ        ', N'Murach''s jQuery', 54.5000, 677)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'JS        ', N'Murach''s JavaScript', 54.5000, 2136)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'JSJQ      ', N'Murach''s JavaScript and jQuery', 59.5000, 2791)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'JSP       ', N'Murach''s Java Servlets and JSP', 57.5000, 2161)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'MYSQL     ', N'Murach''s MySQL', 54.5000, 3455)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'ORACLE    ', N'Murach''s Oracle SQL and PL/SQL', 54.5000, 4999)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'PHP       ', N'Murach''s PHP and MySQL', 57.5000, 2381)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'PYTHON    ', N'Murach''s Python Programming', 57.5000, 3684)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'SQLS      ', N'Murach''s SQL Server for Developers', 59.5000, 2465)
GO
INSERT [dbo].[Products] ([ProductCode], [Description], [UnitPrice], [OnHandQuantity]) VALUES (N'VB        ', N'Murach''s Visual Basic', 57.5000, 2193)
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'AK', N'Alaska')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'AL', N'Alabama')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'AR', N'Arkansas')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'AZ', N'Arizona')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'CA', N'California')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'CO', N'Colorado')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'CT', N'Connecticut')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'DC', N'District of Columbia')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'DE', N'Delaware')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'FL', N'Florida')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'GA', N'Georgia')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'HI', N'Hawaii')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'IA', N'Iowa')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'ID', N'Idaho')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'IL', N'Illinois')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'IN', N'Indiana')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'KS', N'Kansas')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'KY', N'Kentucky')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'LA', N'Lousiana')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'MA', N'Massachusetts')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'MD', N'Maryland')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'ME', N'Maine')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'MI', N'Michigan')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'MN', N'Minnesota')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'MO', N'Missouri')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'MS', N'Mississippi')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'MT', N'Montana')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'NC', N'North Carolina')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'ND', N'North Dakota')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'NE', N'Nebraska')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'NH', N'New Hampshire')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'NJ', N'New Jersey')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'NM', N'New Mexico')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'NV', N'Nevada')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'NY', N'New York')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'OH', N'Ohio')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'OK', N'Oklahoma')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'OR', N'Oregon')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'PA', N'Pennsylvania')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'PR', N'Puerto Rico')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'RI', N'Rhode Island')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'SC', N'South Carolina')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'SD', N'South Dakota')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'TN', N'Tennessee')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'TX', N'Texas')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'UT', N'Utah')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'VA', N'Virginia')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'VI', N'Virgin Islands')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'VT', N'Vermont')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'WA', N'Washington')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'WI', N'Wisconsin')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'WV', N'West Virginia')
GO
INSERT [dbo].[States] ([StateCode], [StateName]) VALUES (N'WY', N'Wyoming')
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_OnHandQuantity]  DEFAULT ((0)) FOR [OnHandQuantity]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_States] FOREIGN KEY([State])
REFERENCES [dbo].[States] ([StateCode])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_States]
GO
ALTER TABLE [dbo].[InvoiceLineItems]  WITH NOCHECK ADD  CONSTRAINT [FK_InvoiceLineItems_Invoices] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoices] ([InvoiceID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceLineItems] CHECK CONSTRAINT [FK_InvoiceLineItems_Invoices]
GO
ALTER TABLE [dbo].[InvoiceLineItems]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceLineItems_Products] FOREIGN KEY([ProductCode])
REFERENCES [dbo].[Products] ([ProductCode])
GO
ALTER TABLE [dbo].[InvoiceLineItems] CHECK CONSTRAINT [FK_InvoiceLineItems_Products]
GO
ALTER TABLE [dbo].[Invoices]  WITH NOCHECK ADD  CONSTRAINT [FK_Invoices_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Customers]
GO
USE [master]
GO
ALTER DATABASE [MMABooks] SET  READ_WRITE 
GO
