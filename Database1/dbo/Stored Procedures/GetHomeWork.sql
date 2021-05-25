CREATE PROCEDURE GetHomeWork
@Id int
   AS
   SELECT  [Id]
      ,[SRS]
      ,[Deadline]
      ,[IdGroup]
  FROM [AcademyDB].[dbo].[HomeWorks]
  where Id = @Id and IsDelete = 0 