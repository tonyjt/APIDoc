CREATE TABLE [dbo].[APIDocErrorCode]
(
	[APIDocId] UNIQUEIDENTIFIER NOT NULL , 
    [ErrorCode] INT NOT NULL, 
    PRIMARY KEY ([ErrorCode], [APIDocId]), 
    CONSTRAINT [FK_APIDocErrorCode_APIDoc] FOREIGN KEY ([APIDocId]) REFERENCES [APIDoc]([APIDocId]), 
    CONSTRAINT [FK_APIDocErrorCode_ErrorCode] FOREIGN KEY ([ErrorCode]) REFERENCES [Error]([ErrorCode]) 
)

GO
