CREATE PROCEDURE GetExercise
@Id int
   AS
   SELECT  [Id]
      ,[Description]
      ,[Deadline]
      ,[IdGroup]
  FROM [dbo].[Exercises]
  where Id = @Id and IsDelete = 0