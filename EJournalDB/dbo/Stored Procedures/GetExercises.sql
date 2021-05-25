CREATE PROCEDURE GetExercises
@Id int
   AS
   SELECT  [Id]
      ,[Description]
      ,[Deadline]
      ,[IdGroup]
  FROM [AcademyDB].[dbo].[Exercises]
  where Id = @Id and IsDelete = 0