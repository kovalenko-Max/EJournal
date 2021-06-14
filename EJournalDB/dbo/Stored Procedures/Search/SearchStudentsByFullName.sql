CREATE PROCEDURE [EJournal].[SearchStudentsByFullName]
@Name NVARCHAR(100)
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
WHERE IsDelete = 0 AND 
	([Name] +' '+[Surname]) like ('%' + LTRIM(RTRIM(@Name))+ '%')