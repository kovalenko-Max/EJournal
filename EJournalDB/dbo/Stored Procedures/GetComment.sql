CREATE PROCEDURE [dbo].[GetComment]
		@Id INT
AS
	SELECT Id,
	Comment
	,IdStudent
	,IdTeacher
	,IdCommentType
FROM Comments
WHERE IsDelete=0 AND Id=@Id