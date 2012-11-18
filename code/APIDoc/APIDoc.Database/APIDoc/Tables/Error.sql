CREATE TABLE [dbo].[Error]
(
	[ErrorCode] INT NOT NULL PRIMARY KEY, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Message] NVARCHAR(256) NOT NULL, 
    [DomainId] UNIQUEIDENTIFIER NOT NULL
)

GO
