CREATE PROCEDURE UpdateTeacher
@Id int,
@Name nvarchar (100),
@Surname nvarchar (100)
   AS
   update Teachers
   set Name = @Name, Surname = @Surname
   where Id = @Id