CREATE PROCEDURE UpdateCourse
@Id int,
@Name nvarchar (100)
   AS
   update Courses
   set Name = @Name
   where Id = @Id