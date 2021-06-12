CREATE PROCEDURE [EJournal].[AddGroupWithStudents]
	@NameGroup NVARCHAR(100),
	@IdCourse INT,
	@IdsStudent as [EJournal].[GroupIdsStudentsIds] readonly
AS

declare @IdGroup int
declare @GroupStudentsCopy as [EJournal].[GroupIdsStudentsIds]

insert into @GroupStudentsCopy
select *
from @IdsStudent

insert into [EJournal].[Groups] (Name, IdCourse)
values (@NameGroup, @IdCourse)
SET @IdGroup = SCOPE_IDENTITY()

update @GroupStudentsCopy
set IdGroup = @IdGroup

insert into [EJournal].[GroupStudents] (IdGroup, IdStudents)
select * from @GroupStudentsCopy

return @IdGroup