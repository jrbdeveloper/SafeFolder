CREATE TABLE [dbo].[Files] (
    [Id]         INT          NOT NULL IDENTITY,
    [Name]       VARCHAR (50) NOT NULL,
    [Path]       VARCHAR (50) NOT NULL,
    [CanCopy]    BIT          NOT NULL,
    [CanDelete]  BIT          NOT NULL,
    [CanModify]  BIT          NOT NULL,
    [CanForward] BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

