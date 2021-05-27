CREATE PROCEDURE [DeleteCourse]
@Id int
   AS
   update Courses
   set IsDelete = 1
  where Id = @Id