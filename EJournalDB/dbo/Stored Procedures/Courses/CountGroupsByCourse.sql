CREATE PROCEDURE [EJournal].[CountGroupsByCourse]
	@Id int
AS
	SELECT Count(G.Id)
	from [EJournal].Groups G
	where G.IdCourse = @Id
