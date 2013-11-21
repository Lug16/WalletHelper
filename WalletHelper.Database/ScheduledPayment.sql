CREATE TABLE [dbo].[ScheduledPayment] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (140) NULL,
    [Value]       MONEY         DEFAULT ((0)) NULL,
    [PaymentType] INT           NOT NULL,
    [Schedule_Id] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ScheduledPayment_Schedule] FOREIGN KEY ([Schedule_Id]) REFERENCES [dbo].[Schedule] ([Id])
);


