CREATE PROCEDURE [dbo].[SearchStudentCity]
@City NVARCHAR(100)
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
	AND City = @City