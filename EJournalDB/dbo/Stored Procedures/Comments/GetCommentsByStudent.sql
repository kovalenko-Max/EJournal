CREATE PROCEDURE [EJournal].[GetCommentsByStudent]
@IdStudent INT
AS
SELECT
[EJournal].[Comments].[Id]
,[EJournal].[Comments].[Comment]
,[EJournal].[CommentTypes].[Id]
,[EJournal].[CommentTypes].[Type]
FROM [EJournal].[StudentsComments]
INNER JOIN [EJournal].[Comments] ON [EJournal].[Comments].[Id] = [EJournal].[StudentsComments].[IdComment]
INNER JOIN	[EJournal].[CommentTypes] ON [EJournal].[CommentTypes].[Id] = [EJournal].[Comments].[IdCommentType]
WHERE [EJournal].[StudentsComments].[IdStudent] = @IdStudent AND [EJournal].[Comments].[IsDelete] = 0