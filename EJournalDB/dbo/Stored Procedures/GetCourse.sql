CREATE PROCEDURE GetCourse
@Id int
   AS
   SELECT [Id]
      ,[Name]
  FROM [EJournalDB].[dbo].[Courses]
  where Id = @Id and isDelete = 0