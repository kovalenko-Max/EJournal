CREATE PROCEDURE [EJournal].[UpdateGroupStudents]
	@IdGroup int,
	@IdsStudent as [EJournal].[GroupIdsStudentsIds] readonly
AS

DELETE from [EJournal].[GroupStudents]
  where IdGroup = @IdGroup

insert into [EJournal].[GroupStudents] (IdGroup, IdStudents)
select * from @IdsStudent