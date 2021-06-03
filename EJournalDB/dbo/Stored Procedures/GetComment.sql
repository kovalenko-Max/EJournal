CREATE PROCEDURE [dbo].[GetComment]
		@Id INT
AS
	SELECT Id,
	Comment
	,IdCommentType
FROM [dbo].[Comments]
WHERE IsDelete=0 AND Id=@Id