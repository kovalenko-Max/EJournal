CREATE PROCEDURE [EJournal].[GetStudentByGroup] @Id INT
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
FROM [EJournal].[Students] AS S
LEFT JOIN [EJournal].[GroupStudents] GS ON S.Id = GS.IdStudents
WHERE GS.IdGroup = @Id
	AND s.IsDelete = 0
