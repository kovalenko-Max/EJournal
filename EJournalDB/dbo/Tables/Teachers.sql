CREATE TABLE [dbo].[Teachers] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (100) NOT NULL,
    [Surname]  NVARCHAR (100) NOT NULL,
    [IsDelete] BIT            DEFAULT ('0') NOT NULL,
    CONSTRAINT [PK_TEACHERS] PRIMARY KEY CLUSTERED ([Id] ASC)
);

