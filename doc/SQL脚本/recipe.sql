USE [CLZDoctor]
GO
/****** 对象:  Table [dbo].[recipe]    脚本日期: 12/11/2014 21:43:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[recipe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrescripId] [int] NULL,
	[MaterialsId] [int] NULL,
	[Name] [varchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[Dosage] [int] NULL,
	[Unit] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[State] [int] NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_recipe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF