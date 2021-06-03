CREATE PROCEDURE [dbo].[UpdateGroup]
@Id int,
@Name nvarchar (100),
@IdCourse int
   AS
   update [dbo].[Groups]
   set Name = @Name, IdCourse = @IdCourse
   where Id = @Id