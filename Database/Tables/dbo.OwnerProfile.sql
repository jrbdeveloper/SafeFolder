CREATE TABLE [dbo].[OwnerProfile]
(
	[ProfileId] INT NOT NULL PRIMARY KEY,
	[FirstName] varchar(25) not null,
	[LastName] varchar(25) not null,
	[EmailAddress] varchar(50) not null,
	[Password] varchar(25) not null
)
