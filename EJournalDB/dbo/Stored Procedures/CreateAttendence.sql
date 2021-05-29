CREATE PROCEDURE [dbo].[CreateAttendence]
AS
	Select  Distinct IdLesson, L.Topic, L.DateLesson , IsPresence, IdStudent, S.Name
From Attendances A
INNER JOIN (Select Id, DateLesson, Topic From Lessons ) AS L ON A.IdLesson=L.Id
INNER JOIN (Select Id, (Name + Surname) As Name From Students) AS S ON A.IdStudent = S.Id
Order by IdLesson