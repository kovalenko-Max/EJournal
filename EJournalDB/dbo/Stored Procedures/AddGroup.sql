﻿CREATE PROCEDURE AddGroup
@Name nvarchar (100),
@IdCourse int
   AS
   insert into Groups (Name, IdCourse)
   values(@Name, @IdCourse)