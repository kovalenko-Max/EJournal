CREATE PROCEDURE [dbo].[GetAllComments]
AS
	SELECT Id,
	Comment
	,IdCommentType
FROM Comments
WHERE IsDelete=0