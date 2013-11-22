CREATE TABLE [dbo].[PaymentMethod] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (140) NOT NULL
);



GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PaymentMethod]
    ON [dbo].[PaymentMethod]([Id] ASC);

