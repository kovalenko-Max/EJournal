CREATE TYPE [EJournal].[StudentAttendance] AS TABLE 
(
    [LessonsIds] INT NULL,
    [StudentId] INT NULL,
    [isPresense] bit NULL
);