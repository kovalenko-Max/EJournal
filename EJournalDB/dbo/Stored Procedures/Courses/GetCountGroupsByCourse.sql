CREATE PROCEDURE [EJournal].[GetCountGroupsByCourse]
	@Id int
AS
	SELECT Count(G.Id)
	from [EJournal].Groups G
	where G.IdCourse = @Id
