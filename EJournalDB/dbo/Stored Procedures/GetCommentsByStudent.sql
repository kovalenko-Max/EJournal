CREATE PROCEDURE [dbo].[GetCommentsByStudent]
@IdStudent INT
AS
SELECT
[dbo].[Comments].[Id]
,[dbo].[Comments].[Comment]
,[dbo].[CommentTypes].[Id]
,[dbo].[CommentTypes].[Type]
FROM [dbo].[StudentsComments]
INNER JOIN [dbo].[Comments] ON [dbo].[Comments].[Id] = [dbo].[StudentsComments].[IdComment]
INNER JOIN	[dbo].[CommentTypes] ON [dbo].[CommentTypes].[Id] = [dbo].[Comments].[IdCommentType]
WHERE [dbo].[StudentsComments].[IdStudent] = @IdStudent AND [dbo].[Comments].[IsDelete] = 0