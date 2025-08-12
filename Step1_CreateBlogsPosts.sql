IF DB_ID('BloggingDb9_Scaffold') IS NULL
    CREATE DATABASE BloggingDb9_Scaffold;
GO
USE BloggingDb9_Scaffold;
GO

IF OBJECT_ID('dbo.Posts','U') IS NOT NULL DROP TABLE dbo.Posts;
IF OBJECT_ID('dbo.Blogs','U') IS NOT NULL DROP TABLE dbo.Blogs;
GO

CREATE TABLE dbo.Blogs(
  BlogId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Name] NVARCHAR(255) NOT NULL
);
GO

CREATE TABLE dbo.Posts(
  PostId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Title NVARCHAR(MAX) NULL,
  [Content] NVARCHAR(MAX) NULL,
  BlogId INT NOT NULL
    CONSTRAINT FK_Posts_Blogs FOREIGN KEY REFERENCES dbo.Blogs(BlogId)
);
GO

INSERT dbo.Blogs([Name]) VALUES (N'Văn hóa'),(N'Xã hội'),(N'Tự nhiên'),(N'Kinh tế');
INSERT dbo.Posts(Title,[Content],BlogId) VALUES
(N'Bóng đá Việt Nam thay huấn luyện viên',N'Ông Nguyễn Hữu Thắng...',1),
(N'Tiêm phòng vắc xin bệnh dại',N'Tiêm phòng ngày 25/02/2012',2),
(N'Tin tự nhiên',N'Tin tự nhiên',2),
(N'ABC',N'DEF',4);
GO
