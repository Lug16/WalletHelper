CREATE TABLE [dbo].[PaymentMethod] (
    [Id]          INT NOT NULL,
    [Description] VARCHAR (140) NOT NULL, 
    CONSTRAINT [PK_PaymentMethod] PRIMARY KEY ([Id])
);



GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PaymentMethod]
    ON [dbo].[PaymentMethod]([Id] ASC);

