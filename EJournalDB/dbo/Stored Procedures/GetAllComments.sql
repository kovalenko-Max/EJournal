CREATE PROCEDURE [dbo].[GetAllComments]
AS
SELECT Id
	,Comment
	,IdTeacher
	,IdCommentType
FROM [dbo].[Comments]
WHERE IsDelete = 0
