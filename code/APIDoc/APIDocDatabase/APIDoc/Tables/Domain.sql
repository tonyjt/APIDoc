﻿CREATE TABLE [dbo].[Domain]
(
	[DomainId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(128) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [RootUrl] NVARCHAR(128) NOT NULL
)