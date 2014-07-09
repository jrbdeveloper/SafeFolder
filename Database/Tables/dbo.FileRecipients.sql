CREATE TABLE [dbo].[FileRecipients]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[FileId] int not null,
	[AddressBookId] int not null, 
    CONSTRAINT [FK_FileRecipients_Files] FOREIGN KEY ([FileId]) REFERENCES [Files]([Id]), 
    CONSTRAINT [FK_FileRecipients_AddressBook] FOREIGN KEY ([AddressBookId]) REFERENCES [AddressBook]([Id])
)
