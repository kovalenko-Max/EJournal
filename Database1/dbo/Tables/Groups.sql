CREATE TABLE [dbo].[Groups] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (100) NOT NULL,
    [IdCourse] INT            NOT NULL,
    [IsFinish] BIT            DEFAULT ('0') NOT NULL,
    [IsDelete] BIT            DEFAULT ('0') NOT NULL,
    CONSTRAINT [PK_GROUPS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Groups_fk0] FOREIGN KEY ([IdCourse]) REFERENCES [dbo].[Courses] ([Id])
);

