USE [CLZDoctor]
GO
/****** 对象:  Table [dbo].[favorite]    脚本日期: 12/11/2014 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[favorite](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[PrescripId] [int] NULL,
	[PrescripName] [varchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [text] COLLATE Chinese_PRC_CI_AS NULL,
	[State] [int] NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[UserName] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_FAVORITE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF