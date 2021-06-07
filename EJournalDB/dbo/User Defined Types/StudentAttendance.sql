CREATE TYPE [dbo].[StudentAttendance] AS TABLE 
(
    [LessonsIds] INT NULL,
    [StudentId] INT NULL,
    [isPresense] bit NULL
);