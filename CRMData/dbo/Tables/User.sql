﻿CREATE TABLE [dbo].[User]
(
	[Id] NVARCHAR(128)  NOT NULL PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[EmailAddress] NVARCHAR(256) NOT NULL,
	[CreatedDate] datetime2(7) NOT NULL DEFAULT getutcdate(),
)
