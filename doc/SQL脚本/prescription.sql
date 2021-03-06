USE [CLZDoctor]
GO
/****** 对象:  Table [dbo].[prescription]    脚本日期: 12/11/2014 21:42:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[prescription](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Name] [varchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[Alias] [varchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[MakeUp] [text] COLLATE Chinese_PRC_CI_AS NULL,
	[Usage] [text] COLLATE Chinese_PRC_CI_AS NULL,
	[Effect] [text] COLLATE Chinese_PRC_CI_AS NULL,
	[Explain] [text] COLLATE Chinese_PRC_CI_AS NULL,
	[FangGe] [varchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[Notes] [varchar](1000) COLLATE Chinese_PRC_CI_AS NULL,
	[Related] [varchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[Similar] [varchar](1000) COLLATE Chinese_PRC_CI_AS NULL,
	[Source] [varchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [text] COLLATE Chinese_PRC_CI_AS NULL,
	[State] [int] NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_prescription] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF