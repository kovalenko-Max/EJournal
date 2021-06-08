CREATE PROCEDURE [dbo].[CountGroupsByCourse]
	@Id int
AS
	SELECT Count(G.Id)
	from Groups G
	where G.IdCourse = @Id
