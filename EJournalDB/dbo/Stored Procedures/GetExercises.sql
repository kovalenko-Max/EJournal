CREATE PROCEDURE [EJournal].GetExercises
@Id int
   AS
   SELECT  [Id]
      ,[Description]
      ,[Deadline]
      ,[IdGroup]
  FROM [EJournal].[Exercises]
  where Id = @Id and IsDelete = 0