CREATE TABLE [dbo].[OwnerProfile] (
    [ProfileId]    INT          NOT NULL IDENTITY,
    [FirstName]    VARCHAR (25) NOT NULL,
    [LastName]     VARCHAR (25) NOT NULL,
    [EmailAddress] VARCHAR (50) NOT NULL,
    [Password]     VARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([ProfileId] ASC)
);

