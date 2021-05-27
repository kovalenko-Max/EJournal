CREATE PROCEDURE GetAllExercises
   AS
   SELECT  [Id]
      ,[Description]
      ,[Deadline]
      ,[IdGroup]
  FROM [EJournalDB].[dbo].[Exercises]
  where IsDelete = 0