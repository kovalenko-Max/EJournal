CREATE TABLE [dbo].[StudentsExercises]
(
    [Points] INT NULL,
	[IdExercise] INT NOT NULL,
    [IdStudents] INT NOT NULL,
    [IsChecked]  BIT NOT NULL,
    CONSTRAINT [StudentsHomeWorkes_Exercises_Id] FOREIGN KEY ([IdExercise]) REFERENCES [dbo].[Exercises] ([Id]),
    CONSTRAINT [StudentsHomeWorkes_Students_Id] FOREIGN KEY ([IdStudents]) REFERENCES [dbo].[Students] ([Id])
);
