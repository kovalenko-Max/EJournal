CREATE TABLE [dbo].[Projectes] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50)  NOT NULL,
    [Description]    NVARCHAR (255) NOT NULL,
    [IdProjectCroup] INT            NOT NULL,
    [IsDelete]       BIT            DEFAULT ('0') NOT NULL,
    CONSTRAINT [PK_PROJECTES] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Projectes_fk0] FOREIGN KEY ([IdProjectCroup]) REFERENCES [dbo].[ProjectGroups] ([Id])
);

