USE [CLZDoctor]
GO
/****** 对象:  Table [dbo].[prescriptype]    脚本日期: 12/11/2014 21:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[prescriptype](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ParentId] [int] NULL,
	[Remark] [text] COLLATE Chinese_PRC_CI_AS NULL,
	[State] [int] NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_prescriptype] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF