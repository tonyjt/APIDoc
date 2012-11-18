CREATE TABLE [dbo].[ResponseDemo]
(
	[APIDocId] UNIQUEIDENTIFIER NOT NULL , 
    [ResponseType] TINYINT NOT NULL, 
    [Demo] NVARCHAR(MAX) NOT NULL, 
    PRIMARY KEY ([APIDocId], [ResponseType]), 
    CONSTRAINT [FK_ResponseDemo_APIDoc] FOREIGN KEY ([APIDocId]) REFERENCES [APIDoc]([APIDocId])
)

GO
