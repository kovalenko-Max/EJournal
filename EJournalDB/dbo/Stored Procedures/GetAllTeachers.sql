CREATE PROCEDURE [dbo].[GetAllTeachers]
AS
SELECT [Id]
	,[Name]
FROM [dbo].[Teachers]
WHERE IsDelete = 0
