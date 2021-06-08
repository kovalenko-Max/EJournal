CREATE PROCEDURE [EJournal].[AddCourse] @Name NVARCHAR(100)
AS
INSERT INTO [EJournal].[Courses] (Name)
VALUES (@Name)
