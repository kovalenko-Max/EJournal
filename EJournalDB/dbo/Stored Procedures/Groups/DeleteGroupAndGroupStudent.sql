CREATE PROCEDURE [EJournal].[DeleteGroupAndGroupStudent] 
@IdGroup INT
AS
delete from [EJournal].[GroupStudents]
where IdGroup = @IdGroup;
delete from Groups
where Id = @IdGroup