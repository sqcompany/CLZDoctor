USE [CLZDoctor]
GO
/****** 对象:  Table [dbo].[medical]    脚本日期: 12/11/2014 21:42:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[medical](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[State] [int] NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[Patient] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Age] [int] NULL,
	[Gender] [int] NULL,
	[Diagnose] [varchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[Treatment] [varchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[Contract] [varchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[IsVisit] [int] NULL,
	[VisitResult] [varchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[Prescription] [varchar](500) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_medical] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF