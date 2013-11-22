CREATE TABLE [dbo].[PeriodType] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (140) NOT NULL
);



GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PeriodType]
    ON [dbo].[PeriodType]([Id] ASC);

