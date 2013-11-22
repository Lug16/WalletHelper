CREATE TABLE [dbo].[Recording] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [Recording]  VARBINARY (MAX) NOT NULL,
    [Payment_Id] INT             NOT NULL,
    CONSTRAINT [PK_Recording] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Recording_Payment] FOREIGN KEY ([Payment_Id]) REFERENCES [dbo].[Payment] ([Id])
);

