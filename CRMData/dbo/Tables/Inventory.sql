CREATE TABLE [dbo].[Inventory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL DEFAULT 1, 
    [PurchagePrice] MONEY NOT NULL, 
    [PurchageDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)
