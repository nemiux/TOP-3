CREATE TABLE [dbo].[Vartotojas]
(
	[VartotojoVardas] NVARCHAR(30) NOT NULL PRIMARY KEY, 
    [Slaptazodis] NVARCHAR(30) NOT NULL, 
    [Miestas] NVARCHAR(20) NOT NULL, 
    [Gatve] NVARCHAR(20) NOT NULL, 
    [Namas] NVARCHAR(5) NOT NULL, 
    [Butas] NVARCHAR(5) NULL
)
