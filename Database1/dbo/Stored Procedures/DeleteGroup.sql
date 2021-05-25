CREATE PROCEDURE DeleteGroup
@Id int
   AS
   update Groups
   set IsDelete = 1
  where Id = @Id