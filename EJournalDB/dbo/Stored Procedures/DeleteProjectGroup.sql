﻿CREATE PROCEDURE [EJournal].[DeleteProjectGroup] @Id INT
AS
UPDATE [EJournal].[ProjectGroups]
SET IsDelete = 1
WHERE Id = @Id
