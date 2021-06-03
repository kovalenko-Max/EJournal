CREATE PROCEDURE [dbo].[GetGroup]
@Id int
   AS
   SELECT  [Id]
      ,[Name]
      ,[IdCourse]
      ,[IsFinish]
  FROM [dbo].[Groups]
  where Id = @Id and IsDelete = 0