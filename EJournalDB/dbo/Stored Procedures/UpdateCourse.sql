CREATE PROCEDURE [dbo].[UpdateCourse]
@Id int,
@Name nvarchar (100)
   AS
   update [dbo].[Courses]
   set Name = @Name
   where Id = @Id