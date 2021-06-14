CREATE PROCEDURE [EJournal].[DeleteComment] @Id INT
AS

delete [EJournal].[Comments]
WHERE Id = @Id

delete [EJournal].[StudentsComments]
where IdComment = @Id