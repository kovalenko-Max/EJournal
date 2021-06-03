CREATE TABLE [dbo].[ProjectGroups] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [IdComments] INT            NOT NULL,
    [IdProject] INT NOT NULL,
    [IsDelete]   BIT            CONSTRAINT [DF__ProjectGroups__IsDele__239E4DCF] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PROJECTGROUPS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [ProjectGroups_Comments_Id] FOREIGN KEY ([IdComments]) REFERENCES [dbo].[Comments] ([Id]),
    CONSTRAINT [ProjectGroups_Projects_Id] FOREIGN KEY ([IdProject]) REFERENCES [dbo].[Projectes] ([Id])
);

