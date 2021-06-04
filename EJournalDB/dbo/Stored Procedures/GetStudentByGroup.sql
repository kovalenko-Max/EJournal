CREATE PROCEDURE [dbo].[GetStudentByGroup] @Id INT
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
FROM [dbo].[Students] AS S
LEFT JOIN [dbo].[GroupStudents] GS ON S.Id = GS.IdStudents
WHERE GS.IdGroup = @Id
	AND s.IsDelete = 0
