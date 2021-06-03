CREATE PROCEDURE [dbo].[GetAllStudents]
AS
SELECT [Id]
	,[Name]
	,[Surname]
	,[Email]
	,[Phone]
	,[Git]
	,[City]
	,[Ranking]
	,[AgreementNumber]
FROM [dbo].[Students]
WHERE IsDelete = 0
