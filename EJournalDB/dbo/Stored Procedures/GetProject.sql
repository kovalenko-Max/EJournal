CREATE PROCEDURE [dbo].[GetProject]
	@Id INT
AS
	SELECT Id
	,Name
	,IdProjectCroup
FROM Projects
WHERE IsDelete =0 AND Id = @Id
