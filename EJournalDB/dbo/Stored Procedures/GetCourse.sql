CREATE PROCEDURE GetCourse
@Id int
   AS
   SELECT [Id]
      ,[Name]
  FROM [AcademyDB].[dbo].[Courses]
  where Id = @Id and isDelete = 0
