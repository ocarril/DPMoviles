USE MASTER
GO

CREATE DATABASE [DB_9FA6E8_parkingResBD]
GO

USE [DB_9FA6E8_parkingResBD]
GO

/****** Object:  Table [dbo].[user]    Script Date: 04/01/2016 18:01:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
	[userID]		[int]			IDENTITY(1,1)NOT NULL ,
	[name]			[varchar](50)	NULL,
	[lastName]		[varchar](50)	NULL,
	[email]			[varchar](50)	NULL,
	[password]		[varchar](50)	NULL,
	[registerDate]	[datetime]		NULL,
	[status]		[bit]			NOT NULL DEFAULT 1,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (
	PAD_INDEX  = OFF, 
	STATISTICS_NORECOMPUTE  = OFF, 
	IGNORE_DUP_KEY = OFF, 
	ALLOW_ROW_LOCKS  = ON, 
	ALLOW_PAGE_LOCKS  = ON) 
	ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

------------------------------------------------------------------------
/*	INDICES UNIQUE */
------------------------------------------------------------------------
IF EXISTS (SELECT name from sys.indexes WHERE name = N'UNIQUE_user_email')
    DROP INDEX UNIQUE_user_email ON [dbo].[user];
GO
	CREATE UNIQUE INDEX UNIQUE_user_email 
	ON [dbo].[user]([email] );
GO

/****** Object:  Table [dbo].[department]    Script Date: 04/01/2016 18:01:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[department](
	[departmentId]	[int]			IDENTITY(1,1)NOT NULL ,
	[name]			[varchar](100)	NULL,
 CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED 
(
	[departmentId] ASC
)WITH (PAD_INDEX  = OFF, 
	STATISTICS_NORECOMPUTE  = OFF, 
	IGNORE_DUP_KEY = OFF, 
	ALLOW_ROW_LOCKS  = ON, 
	ALLOW_PAGE_LOCKS  = ON) 
	ON [PRIMARY]
) 
ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[province]    Script Date: 04/01/2016 18:01:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[province](
	[provinceId] [int]		IDENTITY(1,1)NOT NULL ,
	[name] [varchar](100) NULL,
	[departmentId] [int]	NULL,
 CONSTRAINT [PK_province] PRIMARY KEY CLUSTERED 
(
	[provinceId] ASC
)WITH (
	PAD_INDEX  = OFF, 
	STATISTICS_NORECOMPUTE  = OFF, 
	IGNORE_DUP_KEY = OFF, 
	ALLOW_ROW_LOCKS  = ON, 
	ALLOW_PAGE_LOCKS  = ON
) 
ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[provider]    Script Date: 04/01/2016 18:01:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[provider](
	[providerID]	[int]			IDENTITY(1,1)NOT NULL ,
	[userID]		[int]			NOT NULL,
	[status]		[bit]			NOT NULL DEFAULT 1,
 CONSTRAINT [PK_provider] PRIMARY KEY CLUSTERED 
(
	[providerID] ASC
)WITH 
(
	PAD_INDEX  = OFF, 
	STATISTICS_NORECOMPUTE  = OFF, 
	IGNORE_DUP_KEY = OFF, 
	ALLOW_ROW_LOCKS  = ON, 
	ALLOW_PAGE_LOCKS  = ON
) 
ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[parkingLot]    Script Date: 04/01/2016 18:01:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[parkingLot](
	[parkingLotID]	[int]			IDENTITY(1,1)NOT NULL ,
	[providerID]	[int]			NOT NULL,
	[name]			[varchar](50)	NOT NULL,
	[address]		[varchar](100)	NOT NULL,
	[districtId]	[int]			NOT NULL,
	[description]	[varchar](200)	NOT NULL,
	[urlPicture]	[varchar](2000) NOT NULL,
	[longitud]		[float]			NOT NULL,
	[latitude]		[float]			NOT NULL,
	[LocalPhone]	[varchar](20)	NOT NULL,
	[openTime]		[nchar](10)		NULL,
	[closeTime]		[nchar](10)		NULL,
	[priceHour]		[float]			NOT NULL,
	[status]		[bit]			NOT NULL DEFAULT 1,
 CONSTRAINT [PK_parkingLot] PRIMARY KEY CLUSTERED 
(
	[parkingLotID] ASC
)WITH (
	PAD_INDEX  = OFF, 
	STATISTICS_NORECOMPUTE  = OFF, 
	IGNORE_DUP_KEY = OFF, 
	ALLOW_ROW_LOCKS  = ON, 
	ALLOW_PAGE_LOCKS  = ON
) 
ON [PRIMARY]
) 
ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[disctrict]    Script Date: 04/01/2016 18:01:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[disctrict](
	[districtId]	[int]			IDENTITY(1,1)NOT NULL ,
	[name]			[varchar](100)	NOT NULL,
	[provinceId]	[int]			NOT NULL,
 CONSTRAINT [PK_disctrict] PRIMARY KEY CLUSTERED 
(
	[districtId] ASC
)WITH (
	PAD_INDEX  = OFF, 
	STATISTICS_NORECOMPUTE  = OFF, 
	IGNORE_DUP_KEY = OFF, 
	ALLOW_ROW_LOCKS  = ON, 
	ALLOW_PAGE_LOCKS  = ON
) 
ON [PRIMARY]
) 
ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[parkingSpace]    Script Date: 04/01/2016 18:01:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[parkingSpace](
	[parkingSpaceID]	[int]			IDENTITY(1,1)NOT NULL ,
	[parkingLotID]		[int]			NOT NULL,
	[shortName]			[varchar](50)	NOT NULL,
	[status]			[bit]			NOT NULL DEFAULT 1,
 CONSTRAINT [PK_parkingSpace] PRIMARY KEY CLUSTERED 
(
	[parkingSpaceID] ASC
)WITH (
	PAD_INDEX  = OFF, 
	STATISTICS_NORECOMPUTE  = OFF, 
	IGNORE_DUP_KEY = OFF, 
	ALLOW_ROW_LOCKS  = ON, 
	ALLOW_PAGE_LOCKS  = ON
) 
ON [PRIMARY]
) 
ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[reservation]    Script Date: 04/01/2016 18:01:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[reservation](
	[reservationID]		[int]			IDENTITY(1,1)NOT NULL ,
	[parkingSpaceID]	[int]			NOT NULL,
	[userID]			[int]			NOT NULL,
	[dateReservation]	[datetime]		NOT NULL,
	[startParking]		[varchar](5)	NOT NULL,
	[finishParking]		[varchar](5)	NOT NULL,
	[status]			[bit]			NOT NULL DEFAULT 1,
 CONSTRAINT [PK_reservation] PRIMARY KEY CLUSTERED 
(
	[reservationID] ASC
)WITH (
	PAD_INDEX  = OFF, 
	STATISTICS_NORECOMPUTE  = OFF, 
	IGNORE_DUP_KEY = OFF, 
	ALLOW_ROW_LOCKS  = ON, 
	ALLOW_PAGE_LOCKS  = ON
) 
ON [PRIMARY]
) 
ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  ForeignKey [FK_disctrict_province]    Script Date: 04/01/2016 18:01:21 ******/
ALTER TABLE [dbo].[disctrict]  WITH CHECK ADD  CONSTRAINT [FK_disctrict_province] FOREIGN KEY([provinceId])
REFERENCES [dbo].[province] ([provinceId])
GO
ALTER TABLE [dbo].[disctrict] CHECK CONSTRAINT [FK_disctrict_province]
GO
/****** Object:  ForeignKey [FK_parkingLot_provider]    Script Date: 04/01/2016 18:01:21 ******/
ALTER TABLE [dbo].[parkingLot]  WITH CHECK ADD  CONSTRAINT [FK_parkingLot_provider] FOREIGN KEY([providerID])
REFERENCES [dbo].[provider] ([providerID])
GO
ALTER TABLE [dbo].[parkingLot] CHECK CONSTRAINT [FK_parkingLot_provider]
GO
/****** Object:  ForeignKey [FK_parkingSpace_parkingLot]    Script Date: 04/01/2016 18:01:21 ******/
ALTER TABLE [dbo].[parkingSpace]  WITH CHECK ADD  CONSTRAINT [FK_parkingSpace_parkingLot] FOREIGN KEY([parkingLotID])
REFERENCES [dbo].[parkingLot] ([parkingLotID])
GO
ALTER TABLE [dbo].[parkingSpace] CHECK CONSTRAINT [FK_parkingSpace_parkingLot]
GO
/****** Object:  ForeignKey [FK_provider_user]    Script Date: 04/01/2016 18:01:21 ******/
ALTER TABLE [dbo].[provider]  WITH CHECK ADD  CONSTRAINT [FK_provider_user] FOREIGN KEY([userID])
REFERENCES [dbo].[user] ([userID])
GO
ALTER TABLE [dbo].[provider] CHECK CONSTRAINT [FK_provider_user]
GO
/****** Object:  ForeignKey [FK_province_department]    Script Date: 04/01/2016 18:01:21 ******/
ALTER TABLE [dbo].[province]  WITH CHECK ADD  CONSTRAINT [FK_province_department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[department] ([departmentId])
GO
ALTER TABLE [dbo].[province] CHECK CONSTRAINT [FK_province_department]
GO
/****** Object:  ForeignKey [FK_reservation_parkingSpace]    Script Date: 04/01/2016 18:01:21 ******/
ALTER TABLE [dbo].[reservation]  WITH CHECK ADD  CONSTRAINT [FK_reservation_parkingSpace] FOREIGN KEY([parkingSpaceID])
REFERENCES [dbo].[parkingSpace] ([parkingSpaceID])
GO
ALTER TABLE [dbo].[reservation] CHECK CONSTRAINT [FK_reservation_parkingSpace]
GO
/****** Object:  ForeignKey [FK_reservation_user]    Script Date: 04/01/2016 18:01:21 ******/
ALTER TABLE [dbo].[reservation]  WITH CHECK ADD  CONSTRAINT [FK_reservation_user] FOREIGN KEY([userID])
REFERENCES [dbo].[user] ([userID])
GO
ALTER TABLE [dbo].[reservation] CHECK CONSTRAINT [FK_reservation_user]
GO


/****** Object:  ForeignKey [FK_disctrict_province]    Script Date: 04/01/2016 18:01:21 ******/
ALTER TABLE [dbo].[parkingLot]  WITH CHECK 
ADD  CONSTRAINT [FK_parkingLot_district] FOREIGN KEY([districtId])
REFERENCES [dbo].[disctrict] ([districtId])
GO
ALTER TABLE [dbo].[parkingLot] CHECK CONSTRAINT [FK_parkingLot_district]
GO
