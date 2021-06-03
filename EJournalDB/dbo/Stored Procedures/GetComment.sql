CREATE PROCEDURE [dbo].[GetComment]
		@Id INT
AS
	SELECT Id,
	Comment
	,IdCommentType
FROM Comments
WHERE IsDelete=0 AND Id=@Id