CREATE PROCEDURE [EJournal].[SearchByStudentPhone]
@Phone NVARCHAR(50)
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
	AND [Phone] like ('%' + LTRIM(RTRIM(@Phone))+ '%')