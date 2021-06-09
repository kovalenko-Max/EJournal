CREATE PROCEDURE [dbo].[AddCommentType] @Type NVARCHAR(255)
AS
INSERT INTO CommentTypes (Type)
VALUES (@Type)
