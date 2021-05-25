CREATE PROCEDURE AddCourse
@Name nvarchar (100)
   AS
   insert into Courses (Name)
   values(@Name)