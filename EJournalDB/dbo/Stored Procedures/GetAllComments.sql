CREATE PROCEDURE [dbo].[GetAllComments]
AS
	SELECT Id,
	Comment
	,IdTeacher
	,IdCommentType
FROM Comments
WHERE IsDelete=0