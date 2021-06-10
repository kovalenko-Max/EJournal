CREATE PROCEDURE [EJournal].[UpdateGroupStudents]
	@IdGroup int,
	@NameGroup NVARCHAR(100),
	@IdCourse INT,
	@IdsStudent as [EJournal].[GroupIdsStudentsIds] readonly
AS

UPDATE [EJournal].[Groups]
SET Name = @NameGroup
	,IdCourse = @IdCourse
WHERE Id = @IdGroup

DELETE from [EJournal].[GroupStudents]
  where IdGroup = @IdGroup

insert into [EJournal].[GroupStudents] (IdGroup, IdStudents)
select * from @IdsStudent