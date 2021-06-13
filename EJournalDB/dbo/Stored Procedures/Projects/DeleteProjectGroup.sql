CREATE PROCEDURE [EJournal].[DeleteProjectGroup] @Id INT
AS
Delete [EJournal].[ProjectGroups]
WHERE Id = @Id
