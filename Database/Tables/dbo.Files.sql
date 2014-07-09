CREATE TABLE [dbo].[Files]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] varchar(50) not null,
	[Path] varchar(50) not null,
	[CanCopy] bit not null,
	[CanDelete] bit not null,
	[CanModify] bit not null,
	[CanForward] bit not null
)
