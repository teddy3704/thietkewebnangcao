USE BloggingDb9_Scaffold;
GO
IF OBJECT_ID('dbo.Student','U') IS NOT NULL DROP TABLE dbo.Student;
GO
CREATE TABLE dbo.Student(
  StudentID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  StudentName NVARCHAR(50) NOT NULL,
  StudentAddress NVARCHAR(50) NULL
);
GO
