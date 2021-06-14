CREATE PROCEDURE [EJournal].[GetStudent] @Id INT
AS
SELECT [Id]
	,[Name]
	,[Surname]
	,[Email]
	,[Phone]
	,[Git]
	,[City]
	,[TeacherAssessment]
	,[Ranking]
	,[AgreementNumber]
FROM [EJournal].[Students]
WHERE IsDelete = 0
	AND Id = @Id
