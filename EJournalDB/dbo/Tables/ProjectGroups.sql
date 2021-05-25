CREATE TABLE [dbo].[ProjectGroups] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [IdStudent]  INT            NOT NULL,
    [IdComments] INT            NOT NULL,
    [IsDelete]   BIT            DEFAULT ('0') NOT NULL,
    CONSTRAINT [PK_PROJECTGROUPS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [ProjectGroups_fk0] FOREIGN KEY ([IdStudent]) REFERENCES [dbo].[Students] ([Id]),
    CONSTRAINT [ProjectGroups_fk1] FOREIGN KEY ([IdComments]) REFERENCES [dbo].[Comments] ([Id])
);

