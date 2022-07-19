USE [Vedomost17]
GO

/****** Object:  Table [dbo].[LeftTable]    Script Date: 12.05.2021 15:32:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LeftTable](
	[LCode] [smallint] NOT NULL,
	[Identity] [numeric](1, 1) NOT NULL,
	[Name] [nchar](10) NULL,
	[Key2] [smallint] NOT NULL,
	[Key3] [smallint] NOT NULL,
	[ой] [nchar](10) NOT NULL,
 CONSTRAINT [PK_LeftTable] PRIMARY KEY CLUSTERED 
(
	[ой] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


