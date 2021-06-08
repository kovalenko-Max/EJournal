CREATE PROCEDURE [dbo].[AddCourse] @Name NVARCHAR(100)
AS
INSERT INTO [dbo].[Courses] (Name)
VALUES (@Name)
