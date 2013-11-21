CREATE TABLE [dbo].[PaymentMethodDetail] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (50)  NOT NULL,
    [ReferenceNumber]  VARCHAR (100) NULL,
    [PaymentMethod_Id] INT           NOT NULL,
    [User_Id]          INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PaymentMethodDetail_PaymentMethod] FOREIGN KEY ([PaymentMethod_Id]) REFERENCES [dbo].[PaymentMethod] ([Id]),
    CONSTRAINT [FK_PaymentMethodDetail_User] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[User] ([Id])
);




