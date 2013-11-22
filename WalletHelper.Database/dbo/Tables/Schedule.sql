CREATE TABLE [dbo].[Schedule] (
    [Id]            INT  IDENTITY (1, 1) NOT NULL,
    [Date]          DATE NOT NULL,
    [StartDate]     DATE NOT NULL,
    [EndDate]       DATE NULL,
    [PeriodType_Id] INT  NOT NULL,
    [User_Id]       INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Schedule_PeriodType1] FOREIGN KEY ([PeriodType_Id]) REFERENCES [dbo].[PeriodType] ([Id]),
    CONSTRAINT [FK_Schedule_User] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[User] ([Id])
);






