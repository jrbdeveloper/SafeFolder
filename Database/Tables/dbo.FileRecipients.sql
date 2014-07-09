CREATE TABLE [dbo].[FileRecipients] (
    [Id]            INT NOT NULL IDENTITY,
    [FileId]        INT NOT NULL,
    [AddressBookId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FileRecipients_AddressBook] FOREIGN KEY ([AddressBookId]) REFERENCES [dbo].[AddressBook] ([Id]),
    CONSTRAINT [FK_FileRecipients_Files] FOREIGN KEY ([FileId]) REFERENCES [dbo].[Files] ([Id])
);

