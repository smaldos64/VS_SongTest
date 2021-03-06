USE [TestFromScript]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 03-01-2019 14:23:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[GenreTitle] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Genres] PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Songs]    Script Date: 03-01-2019 14:23:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Songs](
	[SongID] [int] IDENTITY(1,1) NOT NULL,
	[SongTitle] [nvarchar](max) NOT NULL,
	[GenreID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Songs] PRIMARY KEY CLUSTERED 
(
	[SongID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([GenreID], [GenreTitle]) VALUES (1, N'Pop')
INSERT [dbo].[Genres] ([GenreID], [GenreTitle]) VALUES (2, N'Country')
INSERT [dbo].[Genres] ([GenreID], [GenreTitle]) VALUES (3, N'Rock')
SET IDENTITY_INSERT [dbo].[Genres] OFF
SET IDENTITY_INSERT [dbo].[Songs] ON 

INSERT [dbo].[Songs] ([SongID], [SongTitle], [GenreID]) VALUES (1, N'Walk of Life', 1)
INSERT [dbo].[Songs] ([SongID], [SongTitle], [GenreID]) VALUES (3, N'Money for Nothing', 1)
INSERT [dbo].[Songs] ([SongID], [SongTitle], [GenreID]) VALUES (5, N'Take me home country road', 2)
SET IDENTITY_INSERT [dbo].[Songs] OFF
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Songs_dbo.Genres_GenreID] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([GenreID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_dbo.Songs_dbo.Genres_GenreID]
GO
