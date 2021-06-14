CREATE PROCEDURE [EJournal].[GetStudentsByGroup] @Id INT
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
FROM [EJournal].[Students] AS S
LEFT JOIN [EJournal].[GroupStudents] GS ON S.Id = GS.IdStudents
WHERE GS.IdGroup = @Id
	AND s.IsDelete = 0
