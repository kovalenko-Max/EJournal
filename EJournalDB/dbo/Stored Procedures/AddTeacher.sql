CREATE PROCEDURE AddTeacher
@Name nvarchar (100),
@Surname nvarchar (100)
   AS
   insert into Teachers (Name, Surname)
   values(@Name, @Surname)
