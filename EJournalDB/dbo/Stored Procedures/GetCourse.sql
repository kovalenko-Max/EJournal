CREATE PROCEDURE GetCourse
@Id int
   AS
   SELECT [Id]
      ,[Name]
  FROM [dbo].[Courses]
  where Id = @Id and isDelete = 0