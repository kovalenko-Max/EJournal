  CREATE PROCEDURE [dbo].[GroupsWithCources]
  AS
  SELECT c.Id, c.Name,  g.Id, g.Name, g.IsFinish
  FROM Courses c
  INNER Join Groups g ON g.IdCourse = c.Id
