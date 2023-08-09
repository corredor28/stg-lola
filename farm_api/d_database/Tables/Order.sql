CREATE TABLE [dbo].[Order] (
        [OrderId]		INT NOT NULL PRIMARY KEY IDENTITY, 
        [TotalQuantity]	INT NOT NULL,
        [ListPrice]		DECIMAL (18, 2) NOT NULL,
        [Freight]		DECIMAL (18, 2) NOT NULL,
		[Discount]		DECIMAL (18, 2) NOT NULL,
        [NetPrice]		DECIMAL (18, 2) NOT NULL
    );