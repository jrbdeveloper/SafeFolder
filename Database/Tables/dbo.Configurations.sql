CREATE TABLE [dbo].[Configurations] (
    [Id]            INT          NOT NULL,
    [OwnerId]       INT          NOT NULL,
    [Name]          VARCHAR (50) NOT NULL,
    [LocalFilePath] VARCHAR (50) NOT NULL,
    [ServicePath]   VARCHAR (75) NULL,
    [IsDefault]     BIT          NOT NULL,
    [ProfileId] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Configurations_ToOwnerProfile] FOREIGN KEY ([ProfileId]) REFERENCES [OwnerProfile]([ProfileId])
);

