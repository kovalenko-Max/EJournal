CREATE PROCEDURE DeleteHomeWork
@Id int
   AS
   update HomeWorks
   set IsDelete = 1
  where Id = @Id
