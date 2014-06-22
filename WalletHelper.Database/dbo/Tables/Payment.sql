CREATE TABLE [dbo].[Payment] (
    [Id]                     INT           IDENTITY (1, 1) NOT NULL,
    [Date]                   DATETIME      CONSTRAINT [DF__Payment__Date__1DE57479] DEFAULT (getdate()) NOT NULL,
    [Description]            VARCHAR (300) NULL,
    [Value]                  MONEY         CONSTRAINT [DF__Payment__Value__1ED998B2] DEFAULT ((0)) NOT NULL,
    [IsScheduled]            BIT           CONSTRAINT [DF__Payment__IsSched__1FCDBCEB] DEFAULT ((0)) NOT NULL,
    [PaymentType]            INT           NOT NULL,
    [ScheduledPayment_Id]    INT           NULL,
    [PaymentMethodDetail_Id] INT           NOT NULL,
    [User_Id]                INT           NOT NULL,
    [Status_Id]              INT           NOT NULL,
    [Hashtag_Id]             INT           NULL,
    CONSTRAINT [PK__Payment__3214EC07DBD3784A] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Payment_Hashtag] FOREIGN KEY ([Hashtag_Id]) REFERENCES [dbo].[Hashtag] ([Id]),
    CONSTRAINT [FK_Payment_PaymentMethodDetail] FOREIGN KEY ([PaymentMethodDetail_Id]) REFERENCES [dbo].[PaymentMethodDetail] ([Id]),
    CONSTRAINT [FK_Payment_ScheduledPayment] FOREIGN KEY ([ScheduledPayment_Id]) REFERENCES [dbo].[ScheduledPayment] ([Id]),
    CONSTRAINT [FK_Payment_Status] FOREIGN KEY ([Status_Id]) REFERENCES [dbo].[Status] ([Id]),
    CONSTRAINT [FK_Payment_User] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[User] ([Id])
);











GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Income / Expense', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Payment', @level2type = N'COLUMN', @level2name = N'PaymentType';

