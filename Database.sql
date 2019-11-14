USE [master]
GO

/****** Object:  Database [SRCTravelAgencies]    Script Date: 11/4/2019 12:38:21 PM ******/
CREATE DATABASE [SRCTravelAgencies]
 CONTAINMENT = NONE

   

 GO


IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SRCTravelAgencies].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [SRCTravelAgencies] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET ARITHABORT OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [SRCTravelAgencies] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [SRCTravelAgencies] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET  DISABLE_BROKER 
GO

ALTER DATABASE [SRCTravelAgencies] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [SRCTravelAgencies] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [SRCTravelAgencies] SET  MULTI_USER 
GO

ALTER DATABASE [SRCTravelAgencies] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [SRCTravelAgencies] SET DB_CHAINING OFF 
GO

ALTER DATABASE [SRCTravelAgencies] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [SRCTravelAgencies] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [SRCTravelAgencies] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [SRCTravelAgencies] SET QUERY_STORE = OFF
GO

ALTER DATABASE [SRCTravelAgencies] SET  READ_WRITE 
GO


/****** Object:  Table [dbo].[Account]    Script Date: 11/4/2019 12:41:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

USE [SRCTravelAgencies]
GO

CREATE TABLE [dbo].[Account](
	[aId] [int] IDENTITY(1,1) NOT NULL,
	[aUsername] [nvarchar](30) NOT NULL,
	[aPassword] [nvarchar](30) NOT NULL,
	[aName] [nvarchar](30) NOT NULL,
	[aBirthday] [date] NOT NULL,
	[aEmail] [nvarchar](30) NOT NULL,
	[aPhone] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[aId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 11/4/2019 12:42:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Booking](
	[bkId] [int] IDENTITY(1,1) NOT NULL,
	[payment] [float] NOT NULL,
	[bkStatus] [tinyint] NOT NULL,
	[cancelDateTime] [datetime]  NULL,
	[refund] [float]  NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[bkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[BookingDetails]    Script Date: 11/4/2019 1:09:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BookingDetails](
	[bkdId] [int] IDENTITY(1,1) NOT NULL,
	[bkId] [int] NOT NULL,
	[rId] [int] NOT NULL,
	[cId] [int] NOT NULL,
	[sId] [int] NOT NULL,
	[cAge] [tinyint] NOT NULL,
	[rPrice] [float] NOT NULL,
 CONSTRAINT [PK_BookingDetails] PRIMARY KEY CLUSTERED 
(
	[bkdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[BlockTime]    Script Date: 11/4/2019 1:10:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BlockTime](
	[btId] [int] IDENTITY(1,1) NOT NULL,
	[StartPlace] [int] NOT NULL,
	[Destination] [int] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[btPrice] [float] NOT NULL,
 CONSTRAINT [PK_BlockTime] PRIMARY KEY CLUSTERED 
(
	[btId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[BusSchedule]    Script Date: 11/4/2019 1:10:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BusSchedule](
	[gbtId] [int] IDENTITY(1,1) NOT NULL,
	[btId] [int] NOT NULL,
	[bId] [int] NOT NULL,
 CONSTRAINT [PK_BusSchedule] PRIMARY KEY CLUSTERED 
(
	[gbtId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Bus]    Script Date: 11/4/2019 1:11:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bus](
	[bId] [int] IDENTITY(1,1) NOT NULL,
	[bNumber] [nvarchar](10) NOT NULL,
	[bTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Bus] PRIMARY KEY CLUSTERED 
(
	[bId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[BusDetails]    Script Date: 11/4/2019 1:11:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BusDetails](
	[bdTypeId] [int] IDENTITY(1,1) NOT NULL,
	[bdType] [nvarchar](30) NOT NULL,
	[bdPrice] [float] NOT NULL,
 CONSTRAINT [PK_BusDetails] PRIMARY KEY CLUSTERED 
(
	[bdTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Counter]    Script Date: 11/4/2019 1:12:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Counter](
	[counId] [int] IDENTITY(1,1) NOT NULL,
	[counName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Counter] PRIMARY KEY CLUSTERED 
(
	[counId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Customer]    Script Date: 11/4/2019 1:12:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[cId] [int] IDENTITY(1,1) NOT NULL,
	[cName] [nvarchar](30) NOT NULL,
	[cBirthday] [date] NOT NULL,
	[cPhone] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[cId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Employee]    Script Date: 11/4/2019 1:12:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[eId] [nvarchar](30) NOT NULL,
	[eUsername] [nvarchar](30) NOT NULL,
	[ePassword] [nvarchar](30) NOT NULL,
	[eName] [nvarchar](30) NOT NULL,
	[eBirthday] [datetime] NOT NULL,
	[eAddress] [nvarchar](80) NOT NULL,
	[eEmail] [nvarchar](30) NOT NULL,
	[ePhone] [nvarchar](10) NOT NULL,
	[eCounterId] [int] NOT NULL,
	[eRole] [tinyint] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[eId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[Route]    Script Date: 11/4/2019 1:13:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Route](
	[rId] [int] IDENTITY(1,1) NOT NULL,
	[bId] [int] NOT NULL,
	[btId] [int] NOT NULL,
	[rPrice] [float] NOT NULL,
	[date] [date] NOT NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[rId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[RouteDetails]    Script Date: 11/4/2019 1:13:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RouteDetails](
	[rdId] [int] IDENTITY(1,1) NOT NULL,
	[rId] [int] NOT NULL,
	[sId] [int] NOT NULL,
	[avaibility] [tinyint] NOT NULL,
 CONSTRAINT [PK_RouteDetails] PRIMARY KEY CLUSTERED 
(
	[rdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Seat]    Script Date: 11/4/2019 1:13:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Seat](
	[sId] [int] IDENTITY(1,1) NOT NULL,
	[bId] [int] NOT NULL,
	[sNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Seat] PRIMARY KEY CLUSTERED 
(
	[sId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT INTO [dbo].[Counter] ([counName]) VALUES ('Sai Gon')
INSERT INTO [dbo].[Counter] ([counName]) VALUES ('Dong Nai')
INSERT INTO [dbo].[Counter] ([counName]) VALUES ('Vung Tau')
GO
INSERT INTO [dbo].[BusDetails] ([bdType] ,[bdPrice]) VALUES( 'Express',1)
INSERT INTO [dbo].[BusDetails] ([bdType] ,[bdPrice]) VALUES( 'Luxury',1.5)
INSERT INTO [dbo].[BusDetails] ([bdType] ,[bdPrice]) VALUES( 'Volvo non-AC',1.75)
INSERT INTO [dbo].[BusDetails] ([bdType] ,[bdPrice]) VALUES( 'Volvo AC',2)
GO
INSERT INTO [dbo].[Bus] ([bNumber],[bTypeId]) VALUES('00001',1)
INSERT INTO [dbo].[Bus] ([bNumber],[bTypeId]) VALUES('00002',2)
INSERT INTO [dbo].[Bus] ([bNumber],[bTypeId]) VALUES('00003',2)
INSERT INTO [dbo].[Bus] ([bNumber],[bTypeId]) VALUES('00004',3)
INSERT INTO [dbo].[Bus] ([bNumber],[bTypeId]) VALUES('00005',4)
INSERT INTO [dbo].[Bus] ([bNumber],[bTypeId]) VALUES('00006',4)
GO
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'1')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'2')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'3')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'4')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'5')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'6')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'7')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'8')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'9')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'10')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'11')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'12')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'13')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'14')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'15')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'16')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'17')s
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'18')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'19')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'20')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'21')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'22')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'23')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'24')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'25')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'26')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'27')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'28')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'29')
INSERT INTO [dbo].[Seat] (bId,sNumber) VALUES(1,'30')


ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetails_Booking] FOREIGN KEY([bkId])
REFERENCES [dbo].[Booking] ([bkId])
GO

ALTER TABLE [dbo].[BookingDetails] CHECK CONSTRAINT [FK_BookingDetails_Booking]
GO

ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetails_Customer] FOREIGN KEY([cId])
REFERENCES [dbo].[Customer] ([cId])
GO

ALTER TABLE [dbo].[BookingDetails] CHECK CONSTRAINT [FK_BookingDetails_Customer]
GO

ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetails_Route] FOREIGN KEY([rId])
REFERENCES [dbo].[Route] ([rId])
GO

ALTER TABLE [dbo].[BookingDetails] CHECK CONSTRAINT [FK_BookingDetails_Route]
GO

ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetails_Seat] FOREIGN KEY([sId])
REFERENCES [dbo].[Seat] ([sId])
GO

ALTER TABLE [dbo].[BookingDetails] CHECK CONSTRAINT [FK_BookingDetails_Seat]
GO


ALTER TABLE [dbo].[BlockTime]  WITH CHECK ADD  CONSTRAINT [FK_BlockTime_Counter_Destination] FOREIGN KEY([Destination])
REFERENCES [dbo].[Counter] ([counId])
GO

ALTER TABLE [dbo].[BlockTime] CHECK CONSTRAINT [FK_BlockTime_Counter_Destination]
GO

ALTER TABLE [dbo].[BlockTime]  WITH CHECK ADD  CONSTRAINT [FK_BlockTime_Counter_StartPlace] FOREIGN KEY([StartPlace])
REFERENCES [dbo].[Counter] ([counId])
GO

ALTER TABLE [dbo].[BlockTime] CHECK CONSTRAINT [FK_BlockTime_Counter_StartPlace]
GO

ALTER TABLE [dbo].[BusSchedule]  WITH CHECK ADD  CONSTRAINT [FK_BusSchedule_BlockTime] FOREIGN KEY([btId])
REFERENCES [dbo].[BlockTime] ([btId])
GO

ALTER TABLE [dbo].[BusSchedule] CHECK CONSTRAINT [FK_BusSchedule_BlockTime]
GO
ALTER TABLE [dbo].[BusSchedule]  WITH CHECK ADD  CONSTRAINT [FK_BusSchedule_Bus] FOREIGN KEY([bId])
REFERENCES [dbo].[Bus] ([bId])
GO

ALTER TABLE [dbo].[BusSchedule] CHECK CONSTRAINT [FK_BusSchedule_Bus]
GO
ALTER TABLE [dbo].[Bus]  WITH CHECK ADD  CONSTRAINT [FK_Bus_BusDetails] FOREIGN KEY([bTypeId])
REFERENCES [dbo].[BusDetails] ([bdTypeId])
GO

ALTER TABLE [dbo].[Bus] CHECK CONSTRAINT [FK_Bus_BusDetails]
GO


ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Counter] FOREIGN KEY([eCounterId])
REFERENCES [dbo].[Counter] ([counId])
GO

ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Counter]
GO


ALTER TABLE [dbo].[Route]  WITH CHECK ADD  CONSTRAINT [FK_Route_BlockTime] FOREIGN KEY([btId])
REFERENCES [dbo].[BlockTime] ([btId])
GO

ALTER TABLE [dbo].[Route] CHECK CONSTRAINT [FK_Route_BlockTime]
GO

ALTER TABLE [dbo].[Route]  WITH CHECK ADD  CONSTRAINT [FK_Route_Bus] FOREIGN KEY([bId])
REFERENCES [dbo].[Bus] ([bId])
GO

ALTER TABLE [dbo].[Route] CHECK CONSTRAINT [FK_Route_Bus]
GO


ALTER TABLE [dbo].[RouteDetails]  WITH CHECK ADD  CONSTRAINT [FK_RouteDetails_Route] FOREIGN KEY([rId])
REFERENCES [dbo].[Route] ([rId])
GO

ALTER TABLE [dbo].[RouteDetails] CHECK CONSTRAINT [FK_RouteDetails_Route]
GO

ALTER TABLE [dbo].[RouteDetails]  WITH CHECK ADD  CONSTRAINT [FK_RouteDetails_Seat] FOREIGN KEY([sId])
REFERENCES [dbo].[Seat] ([sId])
GO

ALTER TABLE [dbo].[RouteDetails] CHECK CONSTRAINT [FK_RouteDetails_Seat]
GO



ALTER TABLE [dbo].[Seat]  WITH CHECK ADD  CONSTRAINT [FK_Seat_Bus] FOREIGN KEY([bId])
REFERENCES [dbo].[Bus] ([bId])
GO

ALTER TABLE [dbo].[Seat] CHECK CONSTRAINT [FK_Seat_Bus]
GO



