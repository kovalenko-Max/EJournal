CREATE TABLE [dbo].[Courses] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (100) NOT NULL,
    [IsDelete] BIT            DEFAULT ('0') NOT NULL,
    CONSTRAINT [PK_COURSES] PRIMARY KEY CLUSTERED ([Id] ASC)
);

