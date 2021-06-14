CREATE PROCEDURE [EJournal].[SearchByStudentCity]
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
FROM [EJournal].[Students]
WHERE IsDelete = 0
	AND City like ('%' + LTRIM(RTRIM(@City))+ '%')