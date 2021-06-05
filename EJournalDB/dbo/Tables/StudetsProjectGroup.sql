CREATE TABLE [dbo].[StudetsProjectGroup] (
    [IdStudent]      INT NOT NULL,
    [IdProjectGroup] INT NOT NULL,
    CONSTRAINT [StudetsProjectGroup_ProjectGroups_Id] FOREIGN KEY ([IdProjectGroup]) REFERENCES [dbo].[ProjectGroups] ([Id]),
    CONSTRAINT [StudetsProjectGroup_Students_Id] FOREIGN KEY ([IdStudent]) REFERENCES [dbo].[Students] ([Id])
);

