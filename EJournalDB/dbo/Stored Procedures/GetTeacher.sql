CREATE PROCEDURE GetTeacher
@Id int
   AS
   SELECT  [Id]
      ,[Name]
  FROM [AcademyDB].[dbo].[Teachers]
  where Id = @Id and IsDelete = 0