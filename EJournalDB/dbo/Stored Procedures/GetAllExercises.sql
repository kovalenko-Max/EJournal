CREATE PROCEDURE GetAllExercises
   AS
   SELECT  [Id]
      ,[Description]
      ,[Deadline]
      ,[IdGroup]
  FROM [AcademyDB].[dbo].[Exercises]
  where IsDelete = 0