CREATE PROCEDURE [EJournal].[GetGroupAndStudentsInIt] @IdGroup INT
AS
SELECT [EJournal].[Groups].[Id]
	,[EJournal].[Students].[Id]
	,[EJournal].[Students].[Name]
	,[EJournal].[Students].[Surname]
	,[EJournal].[Students].[Email]
	,[EJournal].[Students].[Phone]
	,[EJournal].[Students].[Git]
	,[EJournal].[Students].[AgreementNumber]
FROM [EJournal].[GroupStudents]
INNER JOIN [EJournal].[Groups] ON [EJournal].[Groups].[Id] = [EJournal].[GroupStudents].[IdGroup]
INNER JOIN [EJournal].[Students] ON [EJournal].[Students].[Id] = [EJournal].[GroupStudents].[IdStudents]
WHERE [EJournal].[Groups].[Id] = @IdGroup
