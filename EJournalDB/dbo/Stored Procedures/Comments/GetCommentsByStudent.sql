CREATE PROCEDURE [EJournal].[GetCommentsByStudent]
@IdStudent INT
AS
SELECT
[EJournal].[Comments].[Id]
,[EJournal].[Comments].[Comment]
,[EJournal].[Comments].[CommentType]
FROM [EJournal].[StudentsComments]
INNER JOIN [EJournal].[Comments] ON [EJournal].[Comments].[Id] = [EJournal].[StudentsComments].[IdComment]
WHERE [EJournal].[StudentsComments].[IdStudent] = @IdStudent