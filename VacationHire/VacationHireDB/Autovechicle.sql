CREATE TABLE [dbo].[Autovechicle]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NULL, 
    [Type] NVARCHAR(MAX) NULL, 
    [Damage] NVARCHAR(MAX) NULL, 
    [Fuel] NVARCHAR(MAX) NULL, 
    [Cargo] NVARCHAR(MAX) NULL, 
    [Availability] NVARCHAR(MAX) NULL, 
    [Price] FLOAT NULL
)
