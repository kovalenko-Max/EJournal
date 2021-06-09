CREATE PROCEDURE [dbo].[UpdateProjectGroup] 
    @Id INT
	,@Name NVARCHAR(100)
	,@Students as [dbo].[StudentsIds] READONLY
AS
UPDATE [dbo].[ProjectGroups]
SET Name = @Name
WHERE Id = @Id

delete from StudetsProjectGroup
where IdProjectGroup = @Id

insert into StudetsProjectGroup ( IdProjectGroup, IdStudent)
select IdProjectGroup, Idstudent
from @Students