USE [Booking]
GO

/****** Object:  Table [dbo].[ItemTable]    Script Date: 20-03-2021 16:31:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemTable](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](150) NOT NULL,
	[ItemType] [varchar](50) NOT NULL,
	[BookingType] [bit] NOT NULL,
	[InchargemailID] [varchar](100) NULL,
	[Location] [varchar](150) NOT NULL,
 CONSTRAINT [PK_ItemTable1] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


