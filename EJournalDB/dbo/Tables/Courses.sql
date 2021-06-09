CREATE TABLE [EJournal].[Courses] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (100) NOT NULL,
    [IsDelete] BIT            CONSTRAINT [DF__CourseNames__IsDelete] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_COURSENAMES] PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Id] ASC)
);

