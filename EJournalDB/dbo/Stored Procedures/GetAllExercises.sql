CREATE PROCEDURE GetAllExercises
   AS
   SELECT  [Id]
      ,[Description]
      ,[Deadline]
      ,[IdGroup]
  FROM [dbo].[Exercises]
  where IsDelete = 0