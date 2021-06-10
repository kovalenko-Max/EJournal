CREATE TYPE [EJournal].[StudentExercise] AS TABLE 
(
    [ExerciseId] INT NULL,
    [IdStudent] INT NULL,
    [Points]     INT NULL,
    [IsChecked] bit NULL
);