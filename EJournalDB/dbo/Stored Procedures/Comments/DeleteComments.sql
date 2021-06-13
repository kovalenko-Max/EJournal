CREATE PROCEDURE [EJournal].[DeleteComments] @Id INT
AS

delete [EJournal].[Comments]
WHERE Id = @Id

delete [EJournal].[StudentsComments]
where IdComment = @Id