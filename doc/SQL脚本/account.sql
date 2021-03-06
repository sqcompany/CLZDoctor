USE [CLZDoctor]
GO
/****** 对象:  Table [dbo].[account]    脚本日期: 12/11/2014 21:39:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[Mobile] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[Password] [varchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[CurrState] [int] NULL,
	[State] [int] NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_ACCOUNT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF