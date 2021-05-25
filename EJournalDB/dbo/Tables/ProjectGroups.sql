CREATE TABLE [dbo].[ProjectGroups] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [IdStudent]  INT            NOT NULL,
    [IdComments] INT            NOT NULL,
    [IsDelete]   BIT            CONSTRAINT [DF__ProjectGroups__IsDele__239E4DCF] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PROJECTGROUPS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [ProjectGroups_Comments_Id] FOREIGN KEY ([IdComments]) REFERENCES [dbo].[Comments] ([Id]),
    CONSTRAINT [ProjectGroups_Students_Id] FOREIGN KEY ([IdStudent]) REFERENCES [dbo].[Students] ([Id])
);

