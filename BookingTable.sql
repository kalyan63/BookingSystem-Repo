USE [Booking]
GO

/****** Object:  Table [dbo].[BookingTable]    Script Date: 20-03-2021 16:31:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BookingTable](
	[BookID] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemID] [int] NULL,
	[StudentMailID] [varchar](100) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Reason] [varchar](300) NULL,
	[Status] [decimal](1, 0) NULL,
	[RejectReason] [varchar](300) NULL,
 CONSTRAINT [PK_BookingTable] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


