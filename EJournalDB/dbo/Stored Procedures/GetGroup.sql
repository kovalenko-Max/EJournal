CREATE PROCEDURE GetGroup
@Id int
   AS
   SELECT  [Id]
      ,[Name]
      ,[IdCourse]
      ,[IsFinish]
  FROM [AcademyDB].[dbo].[Groups]
  where Id = @Id and IsDelete = 0