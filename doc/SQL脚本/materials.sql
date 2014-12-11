USE [CLZDoctor]
GO
/****** 对象:  Table [dbo].[materials]    脚本日期: 12/11/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[materials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[Alias] [varchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[State] [int] NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_materials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF