CREATE PROCEDURE DeleteTeacher
@Id int
   AS
   update Teachers
   set IsDelete = 1
  where Id = @Id