CREATE PROCEDURE [dbo].[AddComments]
AS
	SELECT Id,
	Comment
	,IdStudent
	,IdTeacher
	,IdCommentType
FROM Comments
WHERE IsDelete=0