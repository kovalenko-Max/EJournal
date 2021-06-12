CREATE PROCEDURE [EJournal].[DeleteGroup]
	@IdGroup int
AS
	delete from [EJournal].[Groups]
	where Id = @IdGroup