CREATE PROCEDURE [dbo].[Test]
	@TestVariable as [dbo].[StudentsComment] readonly
AS
	SELECT * from @TestVariable
