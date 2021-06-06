CREATE PROCEDURE GetExercises
@Id int
   AS
   SELECT  [Id]
      ,[Description]
      ,[Deadline]
      ,[IdGroup]
      ,[ExerciseType]
  FROM [dbo].[Exercises]
  where Id = @Id and IsDelete = 0