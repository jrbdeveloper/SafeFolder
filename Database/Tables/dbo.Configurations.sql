CREATE TABLE [dbo].[Configurations] (
    [Id]            INT          NOT NULL,
    [OwnerId]       INT          NOT NULL,
    [Name]          VARCHAR (50) NOT NULL,
    [LocalFilePath] VARCHAR (50) NOT NULL,
    [ServicePath]   VARCHAR (75) NULL,
    [IsDefault]     BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Configurations_OwnerProfile] FOREIGN KEY ([OwnerId]) REFERENCES [OwnerProfile]([ProfileId])
);

