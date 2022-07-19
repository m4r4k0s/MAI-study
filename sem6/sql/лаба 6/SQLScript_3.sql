USE [Vedomost17]
GO

/****** Object:  Table [dbo].[RightTable]    Script Date: 12.05.2021 15:33:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RightTable](
	[RCode] [smallint] NOT NULL,
	[Indentity] [numeric](2, 1) NOT NULL,
	[City] [text] NOT NULL,
	[Key2] [smallint] NOT NULL,
	[ой] [nchar](10) NOT NULL,
 CONSTRAINT [PK_RightTable] PRIMARY KEY CLUSTERED 
(
	[ой] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


