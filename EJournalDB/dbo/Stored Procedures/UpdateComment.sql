CREATE PROCEDURE [dbo].[UpdateComment] @Id INT
	,@Comments NVARCHAR(255)
	,@IdTeacher INT
	,@IdCommentType INT
AS
UPDATE [dbo].[Comments]
SET Comment = @Comments
	,IdTeacher = @IdTeacher
	,IdCommentType = @IdCommentType
WHERE Id = @Id
