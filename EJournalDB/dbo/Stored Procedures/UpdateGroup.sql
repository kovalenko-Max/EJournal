CREATE PROCEDURE UpdateGroup
@Id int,
@Name nvarchar (100),
@IdCourse int
   AS
   update Groups
   set Name = @Name, IdCourse = @IdCourse
   where Id = @Id