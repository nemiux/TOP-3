CREATE TABLE [dbo].[Transakcijos]
(
	[transakcijosID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [VartotojoVardas] VARCHAR(30) NULL, 
    CONSTRAINT [VartotojoV] FOREIGN KEY ([VartotojoVardas]) REFERENCES [Vartotojas]([VartotojoVardas])
)
