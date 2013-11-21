CREATE TABLE [dbo].[Payment] (
    [Id]                     INT             IDENTITY (1, 1) NOT NULL,
    [Date]                   DATETIME        DEFAULT (getdate()) NOT NULL,
    [Description]            VARBINARY (300) NULL,
    [Value]                  MONEY           DEFAULT ((0)) NOT NULL,
    [IsScheduled]            BIT             DEFAULT ((0)) NOT NULL,
    [PaymentType]            INT             NOT NULL,
    [ScheduledPayment_Id]    INT             NOT NULL,
    [PaymentMethodDetail_Id] INT             NOT NULL,
    [User_Id]                INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Payment_PaymentMethodDetail] FOREIGN KEY ([PaymentMethodDetail_Id]) REFERENCES [dbo].[PaymentMethodDetail] ([Id]),
    CONSTRAINT [FK_Payment_ScheduledPayment] FOREIGN KEY ([ScheduledPayment_Id]) REFERENCES [dbo].[ScheduledPayment] ([Id]),
    CONSTRAINT [FK_Payment_User] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[User] ([Id])
);




