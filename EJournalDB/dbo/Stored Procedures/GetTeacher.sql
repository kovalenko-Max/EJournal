CREATE PROCEDURE [dbo].[GetTeacher] @Id INT
AS
SELECT [Id]
	,[Name]
FROM [dbo].[Teachers]
WHERE Id = @Id
	AND IsDelete = 0
